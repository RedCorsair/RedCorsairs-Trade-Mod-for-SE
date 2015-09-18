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
        private int _loaded = 0;
        private string motdText = "В данном моде будет торговля" + "\n" + "тест приветственного окна" + "\n" + "тут будет описание серва";
        public Dictionary<string, TradeSystem.Goods.Ore> oreList;
        public Dictionary<string, TradeSystem.Goods.Ignots> ignotsList;
        public Dictionary<string, TradeSystem.Goods.Components> ComponentsList;

        //инициализация 
        private void Init()
        {
            #region resources def
            //списки с рудой слитками и т.д
            oreList = new Dictionary<string, TradeSystem.Goods.Ore>();
            ignotsList = new Dictionary<string, TradeSystem.Goods.Ignots>();
            ComponentsList = new Dictionary<string, TradeSystem.Goods.Components>();
            
            //инициализация руд слитков и т.д если нет xml
            TradeSystem.Goods.Ore uraniumOre = new TradeSystem.Goods.Ore(1, 1m, 0.007m, 40m, 1m, 1m, 1m, 5714.3m, "Уран");
            TradeSystem.Goods.Ore ironOre = new TradeSystem.Goods.Ore(1, 11.36364m, 0.7m, 0.05m, 0.25m, 1m, 1m, 0.1m, "Железо");
            TradeSystem.Goods.Ore nickelOre = new TradeSystem.Goods.Ore(1, 0.454545m, 0.4m, 2m, 0.55m, 1m, 1m, 5m, "Никель");
            TradeSystem.Goods.Ore cobaltOre = new TradeSystem.Goods.Ore(1, 0.5m, 0.3m, 4m, 0.4m, 1m, 1m, 13.3m, "Кобальт");
            TradeSystem.Goods.Ore stoneOre = new TradeSystem.Goods.Ore(1, 22.72727273m, 0.001m, 0.001m, 0.12m, 1m, 1m, 1m, "Камень");
            TradeSystem.Goods.Ore magnesiumOre = new TradeSystem.Goods.Ore(1, 0.5454m, 0.007m, 40m, 0.65m, 1m, 1m, 5714.3m, "Магний");
            TradeSystem.Goods.Ore siliciumOre = new TradeSystem.Goods.Ore(1, 0.4545m, 0.7m, 0.6m, 0.35m, 1m, 1m, 0.9m, "Кремний");
            TradeSystem.Goods.Ore argentumOre = new TradeSystem.Goods.Ore(1, 0.4545m, 0.1m, 1m, 0.20m, 1m, 1m, 10m, "Серебро");
            TradeSystem.Goods.Ore aurumOre = new TradeSystem.Goods.Ore(1, 0.4545m, 0.01m, 0.4m, 0.22m, 1m, 1m, 40m, "Золото");
            TradeSystem.Goods.Ore platinumOre = new TradeSystem.Goods.Ore(1, 0.4545m, 0.005m, 4m, 0.20m, 1m, 1m, 800m, "Платина");
            TradeSystem.Goods.Ore iceOre = new TradeSystem.Goods.Ore(1, 0.4545m, 0.9m, 0.1m, 0.10m, 1m, 1m, 0.1m, "Лёд");

            TradeSystem.Goods.Ignots uraniumIgnot = new TradeSystem.Goods.Ignots(1, "Слиток урана");
            TradeSystem.Goods.Ignots ironIgnot = new TradeSystem.Goods.Ignots(1, "Железный слиток");
            TradeSystem.Goods.Ignots nickelIgnot = new TradeSystem.Goods.Ignots(1, "Никелевый слиток");
            TradeSystem.Goods.Ignots cobaltIgnot = new TradeSystem.Goods.Ignots(1, "Кобальтовый слиток");
            TradeSystem.Goods.Ignots stoneIgnot = new TradeSystem.Goods.Ignots(1, "Гравий");
            TradeSystem.Goods.Ignots magnesiumIgnot = new TradeSystem.Goods.Ignots(1, "Порошок магния");
            TradeSystem.Goods.Ignots siliciumIgnot = new TradeSystem.Goods.Ignots(1, "Кремниевая пластина");
            TradeSystem.Goods.Ignots argentumIgnot = new TradeSystem.Goods.Ignots(1, "Серебряный слиток");
            TradeSystem.Goods.Ignots aurumIgnot = new TradeSystem.Goods.Ignots(1, "Золотой слиток");
            TradeSystem.Goods.Ignots platinumIgnot = new TradeSystem.Goods.Ignots(1, "Платиновый слиток");

            //добавление в списки
            oreList.Add(uraniumOre.getName(), uraniumOre);
            oreList.Add(ironOre.getName(), ironOre);
            oreList.Add(nickelOre.getName(), nickelOre);
            oreList.Add(cobaltOre.getName(), cobaltOre);
            oreList.Add(stoneOre.getName(), stoneOre);
            oreList.Add(magnesiumOre.getName(), magnesiumOre);
            oreList.Add(siliciumOre.getName(), siliciumOre);
            oreList.Add(argentumOre.getName(), argentumOre);
            oreList.Add(aurumOre.getName(), aurumOre);
            oreList.Add(platinumOre.getName(), platinumOre);
            oreList.Add(iceOre.getName(), iceOre);

            ignotsList.Add(uraniumIgnot.getName(), uraniumIgnot);
            ignotsList.Add(ironIgnot.getName(), ironIgnot);
            ignotsList.Add(nickelIgnot.getName(), nickelIgnot);
            ignotsList.Add(cobaltIgnot.getName(), cobaltIgnot);
            ignotsList.Add(stoneIgnot.getName(), stoneIgnot);
            ignotsList.Add(magnesiumIgnot.getName(), magnesiumIgnot);
            ignotsList.Add(siliciumIgnot.getName(), siliciumIgnot);
            ignotsList.Add(argentumIgnot.getName(), argentumIgnot);
            ignotsList.Add(aurumIgnot.getName(), aurumIgnot);
            ignotsList.Add(platinumIgnot.getName(), platinumIgnot);
            #endregion

            _loaded += 1;
            TradeSystem.Actions.TestAction t = new TradeSystem.Actions.TestAction();
            t.doAction();
            //мод загружен и инфо о сервере
            MyAPIGateway.Utilities.ShowMessage("Red Corsairs Trade Mod", "started!");
            MyAPIGateway.Utilities.ShowMissionScreen("Добро пожаловать!", "", "Информация о сервере", motdText, null, "OK");
        }

        //вызывается каждый раз когда сервер что-либо обсчитывает
        public override void UpdateBeforeSimulation()
        {
            if (_loaded == 0)
            {
                Init();
            }
        }

        //выгрузка мода
        protected override void UnloadData()
        {
            base.UnloadData();
        }

    }
}
