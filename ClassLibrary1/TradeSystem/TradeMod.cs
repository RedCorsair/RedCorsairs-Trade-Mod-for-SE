using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sandbox.ModAPI;
using Sandbox.ModAPI.Interfaces;
using Sandbox.Definitions;
using Sandbox.Common;
using Sandbox.Common.ObjectBuilders;
using Sandbox.Common.Components;
using VRage.ModAPI;
using VRage.ObjectBuilders;
using VRageMath;

namespace TradeSystem
{
    [Sandbox.Common.MySessionComponentDescriptor(Sandbox.Common.MyUpdateOrder.BeforeSimulation)]
    class TradeMod : MySessionComponentBase
    {
        public int _loaded = 0;
        private void Init()
        {
            _loaded += 1;
            TradeSystem.Actions.TestAction t = new TradeSystem.Actions.TestAction();
            t.doAction();
        }

        public override void UpdateBeforeSimulation()
        {
            if (_loaded == 0)
            {
                Init();
            }
        }

        protected override void UnloadData()
        {
            base.UnloadData();
        }

    }
}
