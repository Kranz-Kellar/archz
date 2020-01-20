using System;
using System.Collections.Generic;
using System.Text;

namespace Archz.modules
{
    class vkBot : core.IModule
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
            Console.WriteLine("vkBot init");
        }

        public void Start()
        {
            Console.WriteLine("vkBot Start");
        }

        public void Terminate()
        {
            Console.WriteLine("vkBot Terminate");
        }

        public void Update()
        {
            Console.WriteLine("vkBot Update");
        }
    }
}
