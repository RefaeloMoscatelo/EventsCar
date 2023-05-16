using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCar
{
    class Program
    {
        public class Car
        {
            private int price;

            public int Price
            {
                get { return price; }
                set { price = value; }
            }
            private string name;

            public string  Name
            {
                get { return name; }
                set { name = value; }
            }
            
            public Car(int p)
            {
                Price = p;
            }
            public void UpdatePrice(int p)
            {
                Price = Price+Price * p / 100;
            }

        }
        public delegate void UpDatePrice_del(int percent);

        public class PriceManager
        {
            public event UpDatePrice_del UpDatePrice_Handeller;
            public void UpdateAllPrice(int per)
            {
                if (UpDatePrice_Handeller!=null)
                {
                    UpDatePrice_Handeller(per);
                }
            }

        }
       

        static void Main(string[] args)
        {
            PriceManager pm = new PriceManager();
            Car a = new Car(123);
            Car b = new Car(467);
            Car c = new Car(890);

            pm.UpDatePrice_Handeller+=new UpDatePrice_del(a.UpdatePrice);
            pm.UpDatePrice_Handeller += new UpDatePrice_del(b.UpdatePrice);
            pm.UpDatePrice_Handeller += new UpDatePrice_del(c.UpdatePrice);

            pm.UpdateAllPrice(50);
        }
    }
}
