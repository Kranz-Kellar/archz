using System;
using System.Collections.Generic;
using System.Text;

namespace Archz.modules
{
    class BasicFileSorter : core.IModule
    {
        public void Disable()
        {
            throw new NotImplementedException();
        }

        public void Enable()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            Console.WriteLine("BasicFileSorter init");
        }

        public void Start()
        {
            Console.WriteLine("BasicFileSorter Start");
        }

        public void Terminate()
        {
            Console.WriteLine("BasicFileSorter Terminate");
        }

        public void Update()
        {
            Console.WriteLine("BasicFileSorter Update");
        }
    }
}
