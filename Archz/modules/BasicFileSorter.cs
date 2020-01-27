using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Archz.modules
{
    public class BasicFileSorter : core.Module
    {
        BasicFileSorterSettings settings;

        public override void Init()
        {
            settings = core.SettingsManager.LoadSettingsForBasicFileSorter();
            CheckAndCreateCategoryFolders();
            Enable();
        }

        public override void Start()
        {
            
        }

        public override void Terminate()
        {
        }

        public override void Update()
        {
            ScanFolders();
        }


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
            catch(KeyNotFoundException e)
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
