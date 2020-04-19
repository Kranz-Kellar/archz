using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Timers;

namespace Archz.modules
{
    public class BasicFileSorter : core.IModule
    {
        BasicFileSorterSettings settings;
        Timer timer;

        public enum FileCategory
        {
            executable,
            image,
            compressed,
            font,
            video,
            text,
            torrent
        }

        #region Module methods

        public void Init()
        {
            settings = core.SettingsManager.LoadSettingsForBasicFileSorter();
            core.CommandExecuter.AddCommand("fs_add_observer_folder", AddObserverFolder);
            core.CommandExecuter.AddCommand("fs_add_extension_definition", AddExtensionDefinition);
            core.CommandExecuter.AddCommand("fs_enable", Enable);
            core.CommandExecuter.AddCommand("fs_disable", Disable);
            core.CommandExecuter.AddCommand("fs_set_scan_freq", SetScanFrequency);

            CheckAndCreateCategoryFolders();

            timer = new Timer(settings.GetScanFrequencyInMillisec());
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ScanFolders();
        }

        public void Start()
        {
            timer.Start();
        }

        public void Update()
        {
        }

        public void Disable()
        {
            if(timer.Enabled)
            {
                timer.Stop();
            }
        }

        public void Enable()
        {
            if(!timer.Enabled)
            {
                timer.Start();
            }
        }

        public void Terminate()
        {

        }

        public void Restart()
        {
            settings = core.SettingsManager.LoadSettingsForBasicFileSorter();
        }

        #endregion

        #region Public Methods
        public void AddObserverFolder(object path)
        {
            core.SettingsManager.AddNodeWithInnerText("/Settings/BasicFileSorter/ObservedFolders",
                "folder", path.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ext"></param>
        /// <param name="category">Must be in FileCategory enum values</param>
        public void AddExtensionDefinition(object ext, object category)
        {
            try
            {
                var parsedCategory = (FileCategory)Enum.Parse(typeof(FileCategory), category.ToString(), true);
                core.SettingsManager.AddNodeWithAttributeAndInnerText("/Settings/BasicFileSorter/ExtensionsDefinition",
                    "ext", ext.ToString(), "category", parsedCategory.ToString());
            }
            catch(ArgumentException)
            {
                core.Logger.Log(core.LogStatus.ERROR, $"File category '{category.ToString()}' doesn't exist");
            }
        }

        public void SetScanFrequency(object newScanFreq)
        {

        }

        #endregion

        #region Private Methods

        private void CheckAndCreateCategoryFolders()
        {
            foreach(var folder in settings.CategoryFolders)
            {
                if (!Directory.Exists(folder.Value))
                {
                    Directory.CreateDirectory(folder.Value);
                }
            }
        }
        private void ScanFolders()
        {
            foreach (var path in settings.ObservedFolders)
            {
                //Scan every file and classify
                //Classification includes images, soundes, archives, executable files, folders and others
                string[] files = Directory.GetFiles(path);
                string[] folders = Directory.GetDirectories(path);

                foreach (var file in files)
                {
                    ProcessFile(file);
                }

                foreach (var folder in folders)
                {
                    core.Logger.Log(core.LogStatus.DEBUG, $"Folder {folder} was found");
                }
            }
        }

        private void ProcessFile(string pathToFile)
        {
            try
            {
                string fileExtension = Path.GetExtension(pathToFile).ToLower();
                string typeOfFile = settings.ExtensionsDefinition[fileExtension];

                MoveFileToTypedFolder(pathToFile, settings.CategoryFolders[typeOfFile]);
            }
            catch(KeyNotFoundException)
            {
                core.Logger.Log(core.LogStatus.ERROR, $"Extension {Path.GetExtension(pathToFile).ToLower()} is not found");
            }
        }

        private void MoveFileToTypedFolder(string pathToFile, string typedFolderPath)
        {
            if(!Directory.Exists(typedFolderPath))
            {
                Directory.CreateDirectory(typedFolderPath);
            }
            string destinationPath = $"{typedFolderPath}\\{Path.GetFileName(pathToFile)}";
            File.Move(pathToFile, destinationPath);

            core.Logger.Log(core.LogStatus.INFO, $"File {Path.GetFileName(pathToFile)} has been moved to {typedFolderPath}");
        }

        #endregion
    }
}
