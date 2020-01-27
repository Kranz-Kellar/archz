using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Archz.core
{
    public class Archz
    {
        private List<Module> modulesList;
        private ConsoleUI consoleUI;
        private bool isOnline;

        public void Run()
        {
            try
            {
                //Init();
                //Start();
                //Update();
                //Terminate();

               
                
            }
            catch(Exception e)
            {
                Logger.Log(LogStatus.ERROR, $"Error was occured \"{e.Message}\"");
            }

            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            consoleUI = new ConsoleUI();
            var textArea = new ConsoleTextArea(0, 0, Console.WindowWidth / 3 * 2, Console.WindowHeight - 1, '+', ConsoleColor.Red, ConsoleColor.White);
            textArea.WriteText("test\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\ntext\nsomeImportantInfo\n");
            //consoleUI.RenderTextArea(textArea);
            textArea.Render();
        }

        private void Init()
        {
            Logger.Log(LogStatus.INFO, $"SESSION INIT =============================================");
            SettingsManager.Init();
            modulesList = ModuleReflector.GetAllModules();
            modulesList.ForEach(x => x.Init());
            //isOnline = true;
            Logger.Log(LogStatus.INFO, $"SESSION INIT COMPLETE ====================================");
        }

        private void Start()
        {
            modulesList.ForEach(x => x.Start());
            Logger.Log(LogStatus.INFO, $"SESSION STARTED ===========================================");
        }

        private void Update()
        {
            while (isOnline)
            {
                modulesList.ForEach(x => x.Update());
            }
        }

        private void Terminate()
        {
            modulesList.ForEach(x => x.Terminate());
            isOnline = false;
            Logger.Log(LogStatus.INFO, $"SESSION TERMINATED ==========================================");
        }
    }
}
