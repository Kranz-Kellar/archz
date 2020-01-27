using System;
using System.Collections.Generic;
using System.Text;

namespace Archz.core
{

    public abstract class Module
    {
        private bool isEnabled;
        public abstract void Init();
        public abstract void Start();
        public abstract void Update();
        public abstract void Terminate();

        public virtual void Disable()
        {
            isEnabled = false;
        }

        public virtual void Enable()
        {
            isEnabled = true;
        }

        public virtual bool IsEnabled()
        {
            return isEnabled;
        }
    }
}
