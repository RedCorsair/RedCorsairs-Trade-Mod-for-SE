using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TradeSystem.Utility
{
    class dbXML
    {
        private Dictionary<string, TradeSystem.Goods.Ore> oreList;
        private Dictionary<string, TradeSystem.Goods.Ignots> ignotsList;
        private Dictionary<string, TradeSystem.Goods.Components> ComponentsList;
       
        //конструктор
        public dbXML(Dictionary<string, TradeSystem.Goods.Ore> _oreList, Dictionary<string, TradeSystem.Goods.Ignots> _ignotsList, Dictionary<string, TradeSystem.Goods.Components> _ComponentsList)
        {
            this.oreList = _oreList;
            this.ignotsList = _ignotsList;
            this.ComponentsList = _ComponentsList;
        }

        private void createXML()
        {
            XmlTextWriter textWritter;
            XmlDocument document;
            XmlNode element;
            XmlAttribute attribute;
            XmlNode subElement;

            #region ore.xml
            //создание ore.xml
            textWritter = new XmlTextWriter("ore.xml", Encoding.UTF8);
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("head");
            textWritter.WriteEndElement();

            //запись в ore.xml
            document = new XmlDocument();
            document.Load("ore.xml");

            //заполнение ore.xml
            foreach (KeyValuePair<string, TradeSystem.Goods.Ore> pair in oreList)
            {
                element = document.CreateElement("ore");
                document.DocumentElement.AppendChild(element);          
                attribute = document.CreateAttribute("Имя");           
                attribute.Value = pair.Value.getName();                
                element.Attributes.Append(attribute);
                   
                subElement = document.CreateElement("price");
                subElement.InnerText = pair.Value.getPrice().ToString();                                
                element.AppendChild(subElement);

                subElement = document.CreateElement("rarity");
                subElement.InnerText = pair.Value.getRarity().ToString();
                element.AppendChild(subElement);

                subElement = document.CreateElement("product");
                subElement.InnerText = pair.Value.getProduct().ToString();
                element.AppendChild(subElement);

                subElement = document.CreateElement("refTime");
                subElement.InnerText = pair.Value.getRefTime().ToString();
                element.AppendChild(subElement);

                subElement = document.CreateElement("need");
                subElement.InnerText = pair.Value.getNeed().ToString();
                element.AppendChild(subElement);

                subElement = document.CreateElement("demand");
                subElement.InnerText = pair.Value.getDemand().ToString();
                element.AppendChild(subElement);

                subElement = document.CreateElement("supply");
                subElement.InnerText = pair.Value.getSupply().ToString();
                element.AppendChild(subElement);

                subElement = document.CreateElement("labor");
                subElement.InnerText = pair.Value.getLabor().ToString();
                element.AppendChild(subElement); 
            }
            document.Save("ore.xml");
            textWritter.Close();
            textWritter.Dispose();
            #endregion

            #region ignots.xml
            textWritter = new XmlTextWriter("ignots.xml", Encoding.UTF8);
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("head");
            textWritter.WriteEndElement();
            document = new XmlDocument();
            document.Load("ignots.xml");
              
            foreach (KeyValuePair<string, TradeSystem.Goods.Ignots> pair in ignotsList)
            {
                element = document.CreateElement("ignot");
                document.DocumentElement.AppendChild(element);
                attribute = document.CreateAttribute("Имя");
                attribute.Value = pair.Value.getName();
                element.Attributes.Append(attribute);

                subElement = document.CreateElement("price");
                subElement.InnerText = pair.Value.getPrice().ToString();
                element.AppendChild(subElement);
            }
            document.Save("ignots.xml");
            textWritter.Close();
            textWritter.Dispose();
            #endregion
        }
        
    }
}
