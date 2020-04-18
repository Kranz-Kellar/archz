using System;
using System.Collections.Generic;
using System.Text;

namespace Archz.core
{

    public interface IModule
    {
        void Init();
        void Start();
        void Update();
        void Disable();
        void Enable();
        void Terminate();
        void Restart();
    }
}
