using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Module2hw2
{
    public class Product
    {
        public Product(int id, string name, string description, float price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public Product(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public override string ToString()
        {
            return "Id: " + Id.ToString() + ", Name: " + Name.ToString() + ",  Desctiption: " + Description.ToString() + ", Price: " + Price.ToString() + "\n";
        }
    }
}
