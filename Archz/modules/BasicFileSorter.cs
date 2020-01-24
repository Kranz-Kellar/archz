using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Archz.modules
{
    public class BasicFileSorter : core.IModule
    {
        Dictionary<string, string> typesOfExtensions;
        Dictionary<string, string> targetFolders;
        List<string> foldersForSorting;


        public void Init()
        {
            //Getting folders to sort 
            typesOfExtensions = new Dictionary<string, string>();
            targetFolders = new Dictionary<string, string>();
            foldersForSorting = new List<string>();
            AddTestFolders();
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
            throw new NotImplementedException();
        }

        public void Enable()
        {
            throw new NotImplementedException();
        }

        private void AddTestFolders()
        {
            typesOfExtensions[".docx"] = "text";
            typesOfExtensions[".png"] = "image";
            typesOfExtensions[".jpg"] = "image";

            targetFolders["image"] = "images";
            targetFolders["music"] = "music";
            targetFolders["text"] = "text";
            targetFolders["general"] = "general";

            foldersForSorting.Add("C:\\Users\\Дмитрий\\Desktop\\testForSortingBot");
        }

        #region Private Methods
        private void ScanFolders()
        {
            foreach (var path in foldersForSorting)
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
                string fileExtension = Path.GetExtension(pathToFile);
                string typeOfFile = typesOfExtensions[fileExtension];

                MoveFileToTypedFolder(pathToFile, targetFolders[typeOfFile]);
            }
            catch(KeyNotFoundException)
            {
                MoveFileToGeneralFolder(pathToFile);
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

        private void MoveFileToGeneralFolder(string pathToFile)
        {
            if (!Directory.Exists(targetFolders["general"]))
            {
                Directory.CreateDirectory(targetFolders["general"]);
            }
            string destinationPath = $"{targetFolders["general"]}\\{Path.GetFileName(pathToFile)}";
            File.Move(pathToFile, destinationPath);

            core.Logger.Log(core.LogStatus.INFO, $"File {Path.GetFileName(pathToFile)} has been moved to {destinationPath}");
        }

        #endregion
    }
}
