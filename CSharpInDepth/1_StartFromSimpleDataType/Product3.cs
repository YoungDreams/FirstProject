using System.Collections.Generic;

namespace _1_StartFromSimpleDataType
{
    public class Product3
    {
        public string Name {get; private set;}
        public decimal Price { get; private set; }

        public Product3(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        Product3()
        {
        }

        public static List<Product3> GetSampleProducts()
        {
            return new List<Product3>{
                new Product3 { Name = "West Side Story", Price = 9.99m },
                new Product3 { Name = "Assassins", Price = 14.99m },
                new Product3 { Name = "Frogs", Price = 13.99m },
                new Product3 { Name = "Sweeney Todd", Price = 10.99m }
            };
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Name, Price);
        }
    }
}