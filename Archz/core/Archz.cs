using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Archz.core
{
    public class Archz
    {
        private List<IModule> modulesList;
        private Container container;

        public void Run()
        {
            Init();
            Start();
            Update();
            Terminate();
        }

        private void Init()
        {
            modulesList = ModuleReflector.GetAllModules();
            modulesList.ForEach(x => x.Init());
        }

        private void Start()
        {
            modulesList.ForEach(x => x.Start());
        }

        private void Update()
        {
            modulesList.ForEach(x => x.Update());
        }

        private void Terminate()
        {
            modulesList.ForEach(x => x.Terminate());
        }
    }
}
