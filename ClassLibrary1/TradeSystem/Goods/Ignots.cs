using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeSystem.Goods
{
    class Ignots
    {
        private int price;
        private string name;

        public Ignots(int p, string name)
        {
            this.setPrice(p);
            this.setName(name);
        }

        //сеттеры
        public void setPrice(int a)
        {
            price = a;
        }

        public void setName(string a)
        {
            name = a;
        }

        //геттеры
        public int getPrice()
        {
            return price;
        }

        public string getName()
        {
            return name;
        }
    }
}
