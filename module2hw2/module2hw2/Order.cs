using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2hw2
{
    public class Order
    {
        private static int _orderId = 0;
        public Order()
        {
            _orderId += 1;
            OrderDate = DateTime.Now;
        }

        public Order(Product[] products, string customerName, string customerAddress, string customerNumber)
        {
            Products = products;
            TotalPrice = CountPrice(products);
            OrderDate = DateTime.Now;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerNumber = customerNumber;
            _orderId += 1;
        }

        public Product[] Products { get; set; }
        public float TotalPrice { get; }
        public DateTime OrderDate { get; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerNumber { get; set; }
        public override string ToString()
        {
            string result = "\nYour order with number " + _orderId + " has been created:\n\n Products: ";
            foreach (var product in Products)
            {
                result += product.Name.ToString() + " " + product.Price.ToString() + ", ";
            }

            result += "\n Total price: " + TotalPrice.ToString() + "\n Personal data: " + CustomerName.ToString() + "\n "
                + CustomerAddress.ToString() + "\n " + CustomerNumber.ToString() + "\n " + OrderDate.ToString() + "\n\n";

            return result;
        }

        public int GetId()
        {
            return _orderId;
        }

        private float CountPrice(Product[] products)
        {
            float result = 0;
            foreach (Product product in products)
            {
                result += product.Price;
            }

            return result;
        }
    }
}
