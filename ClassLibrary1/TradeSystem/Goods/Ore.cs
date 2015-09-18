using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeSystem.Goods
{
    class Ore
    {
        //параметры ресурсов:
        //  цена, редкость, продуктивность, скорость переработки
        //  потребность, спрос, предложение, трудозатраты, наименование
        private int price;
        private decimal rarity;
        private decimal product;
        private decimal refTime;
        private decimal need;
        private decimal demand;
        private decimal supply;
        private decimal labor;
        private string name;

        public Ore(int p, decimal r, decimal pr, decimal rT, decimal n,
            decimal d, decimal s, decimal l, string name)
        {
            this.setPrice(p);
            this.setRarity(r);
            this.setProduct(pr);
            this.setRefTime(rT);
            this.setNeed(n);
            this.setDemand(d);
            this.setSupply(s);
            this.setLabor(l);
            this.setName(name);
        }

        //сеттеры
        //добавить проверки
        public void setPrice(int a)
        {
            price = a;
        }
        public void setRarity(decimal a)
        {
            rarity = a;
        }
        public void setProduct(decimal a)
        {
            product = a;
        }
        public void setRefTime(decimal a)
        {
            refTime = a;
        }
        public void setNeed(decimal a)
        {
            need = a;
        }
        public void setDemand(decimal a)
        {
            demand = a;
        }
        public void setSupply(decimal a)
        {
            supply = a;
        }
        public void setLabor(decimal a)
        {
            labor = a;
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
        public decimal getRarity()
        {
            return rarity;
        }
        public decimal getProduct()
        {
            return product;
        }
        public decimal getRefTime()
        {
            return refTime;
        }
        public decimal getNeed()
        {
            return need;
        }
        public decimal getDemand()
        {
            return demand;
        }
        public decimal getSupply()
        {
            return supply;
        }
        public decimal getLabor()
        {
            return labor;
        }
        public string getName()
        {
            return name;
        }
    }
}
