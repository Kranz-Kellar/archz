﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Archz.core
{
    public class Archz
    {
        private List<IModule> modulesList;
        private bool isRunning;

        public void Run()
        {
            Init();
            Start();
            Update();
            Terminate();
        }

        private void Init()
        {
            Logger.Log(LogStatus.INFO, $"SESSION STARTED =============================================");
            SettingsManager.Init();
            CommandExecuter.Init();
            modulesList = ModuleReflector.GetAllModules();
            modulesList.ForEach(x => x.Init());
        }

        private void Start()
        {
            isRunning = true;
            modulesList.ForEach(x => x.Start());
        }

        private void Update()
        {
            while (isRunning)
            {
                lock (modulesList)
                {
                    modulesList.ForEach(x => x.Update());
                }
            }
        }

        private void Terminate()
        {
            modulesList.ForEach(x => x.Terminate());
            Logger.Log(LogStatus.INFO, $"SESSION TERMINATED ==========================================");
        }
    }
}