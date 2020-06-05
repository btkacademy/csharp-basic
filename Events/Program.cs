using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {   
            Product product = new Product("Laptop", 50);
            Product product2 = new Product("Phone", 100);
            product.StockControlEvent += Product_StockControlEvent;
            product2.StockControlEvent += Product_StockControlEvent;
            for (int i = 0; i < 5; i++)
            {
                Console.ReadKey();
                product.Sell(10);
                product2.Sell(10);
            }
            Console.ReadKey();
        }

        private static void Product_StockControlEvent(string ProductName)
        {
            Console.WriteLine(string.Format("\t{0} stokları azaldı", ProductName));
        }
    }
    public delegate void StockControl(string ProductName);
    public class Product
    {
        int _stock;
        public event StockControl StockControlEvent;
        public string ProductName { get; set; }
        public Product(string ProductName, int stock)
        {
            _stock = stock;
            this.ProductName = ProductName;
        }

        public int Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                if (value <= 15 && StockControlEvent != null)
                    StockControlEvent(ProductName);
            }
        }

        public void Sell(int amount)
        {
            Stock -= amount;
            Console.WriteLine(string.Format("{0} PreStock Amount :{1} Stock amount : {2}", ProductName, (Stock + amount), Stock));
        }
    }
}
