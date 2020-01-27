using System;
using System.Collections.Generic;
using System.Text;

namespace Archz.modules
{
    public class vkBot : core.Module
    {

        public override void Init()
        {
            core.Logger.Log(core.LogStatus.INFO, "vskBot Init");
        }

        public override void Start()
        {
            core.Logger.Log(core.LogStatus.INFO, "vskBot Start");
        }

        public override void Terminate()
        {
            core.Logger.Log(core.LogStatus.INFO, "vskBot Terminate");
        }

        public override void Update()
        {
            core.Logger.Log(core.LogStatus.INFO, "vskBot Update");
        }
    }
}
