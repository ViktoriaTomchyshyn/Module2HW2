using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Module2hw2
{
    public class Store
    {
        private static Store _instance;
        private Product[] _products;

        public Store()
        {
            _products = null;
        }

        public static Store GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Store();
            }

            return _instance;
        }

        public void AddProduct(int id, string name, string description, float price)
        {
            if (_products == null)
            {
                _products = new Product[1] { new Product(id, name, description, price) };
            }
            else
            {
                Array.Resize<Product>(ref _products, _products.Length + 1);
                _products[_products.Length - 1] = new Product(id, name, description, price);
            }
        }

        public Product[] GetProducts()
        {
            return _products;
        }

        public Product GetProduct(int id)
        {
            return _products[id - 1];
        }

        public override string ToString()
        {
            string result = "Products available in the store:\n";
            foreach (var item in _products)
            {
                result += item.ToString();
            }

            return result;
        }
    }
}
