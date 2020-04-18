using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Archz.modules
{
    public class BasicFileSorter : core.IModule
    {
        BasicFileSorterSettings settings;

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
            CheckAndCreateCategoryFolders();
        }

        public void Start()
        {
            
        }

        public void Terminate()
        {
            
        }

        public void Update()
        {
            ScanFolders();
        }

        public void Disable()
        {
            
        }

        public void Enable()
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

        public void AddExtensionDefinition(object ext, object category)
        {
            core.SettingsManager.AddNodeWithAttributeAndInnerText("/Settings/BasicFileSorter/ExtensionsDefinition",
                "ext", ext.ToString(), "category", ((FileCategory)category).ToString());
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
