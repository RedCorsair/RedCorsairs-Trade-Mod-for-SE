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

namespace TradeSystem.Actions
{
    class TestAction
    {
        private string motdText = "В данном моде будет торговля" + "\n" + "тест приветственного окна" + "\n" + "тут будет описание серва";
        public void doAction()
        {
            MyAPIGateway.Utilities.ShowMessage("W00T", "STARTANUL!!");
            MyAPIGateway.Utilities.ShowNotification("Сработало, мать его за ногу", 3000, Sandbox.Common.MyFontEnum.Green);
            MyAPIGateway.Utilities.ShowMissionScreen("Добро пожаловать!", "", "MOTD", motdText, null, "OK");
        }
    }
}
