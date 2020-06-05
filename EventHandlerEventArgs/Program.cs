using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerEventArgs
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Laptop", 50);
            product.StockControlEvent += delegate (object sender, StockControlEventArgs _args)
            {
                Product senderProduct = sender as Product;
                Console.WriteLine("\t{0} stoklar azaldı {1} güncel stok",_args.ProductName, senderProduct.Stock);
            };
            for (int i = 0; i < 5; i++)
            {
                Console.ReadKey();
                product.Sell(10);
            }
            Console.ReadKey();
        }
    }
    public delegate void StockControl(object sender, StockControlEventArgs args);//yöntem 1
    public class Product
    {
        int _stock;
        public event StockControl StockControlEvent;//yöntem 1
        public event EventHandler<StockControlEventArgs> StockControlEvent2;//Delegate tanımlamadan bu şekilde de event tanımlaya biliriz(yöntem 2)
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
                if (value <= 15)
                {
                    if (StockControlEvent != null)
                        StockControlEvent(this, new StockControlEventArgs(ProductName));//yöntem 1
                    if (StockControlEvent2 != null)
                        StockControlEvent2(this, new StockControlEventArgs(ProductName));//yöntem 2
                }
            }
        }

        public void Sell(int amount)
        {
            Stock -= amount;
            Console.WriteLine(string.Format("{0} satıldı", ProductName));
        }
    }
    public class StockControlEventArgs : EventArgs
    {
        public string ProductName { get; set; }
        public StockControlEventArgs(string ProductName)
        {
            this.ProductName = ProductName;
        }
    }
}
