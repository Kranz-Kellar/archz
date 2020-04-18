using System;
using System.Collections.Generic;
using System.Text;

namespace Archz.modules
{
    public class vkBot 
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
            core.Logger.Log(core.LogStatus.INFO, "vskBot Init");
        }

        public void Start()
        {
            core.Logger.Log(core.LogStatus.INFO, "vskBot Start");
        }

        public void Terminate()
        {
            core.Logger.Log(core.LogStatus.INFO, "vskBot Terminate");
        }

        public void Update()
        {
            core.Logger.Log(core.LogStatus.INFO, "vskBot Update");
        }

        public void Restart()
        {

        }
    }
}
