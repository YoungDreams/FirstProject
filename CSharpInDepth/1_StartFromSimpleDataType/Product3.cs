using System;
using System.Collections.Generic;
using Community.CsharpSqlite;

namespace _1_StartFromSimpleDataType
{
    public class Product3
    {
        public int Id { get; private set; }
        public string Name {get; private set;}
        public decimal Price { get; private set; }
        public DateTime Date { get; private set; }

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
            return new List<Product3> {
                new Product3 { Name = "West Side Story", Price = 9.99m, Id = 1, Date = DateTime.Now },
                new Product3 { Name = "Assassins", Price = 14.99m, Id = 2, Date = DateTime.Now.AddDays(-1) },
                new Product3 { Name = "Frogs", Price = 13.99m, Id = 3, Date = DateTime.Now.AddDays(-2) },
                new Product3 { Name = "Sweeney Todd", Price = 10.99m, Id = 4, Date = DateTime.Now.AddDays(-3) }
            };
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}, {2}, {3}", Name, Price, Id, Date);
        }
    }

    public class Supplier
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name;}
            set { name = value; }
        }

        public Supplier(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public static List<Supplier> GetSampleSupplier()
        {
            return new List<Supplier> { 
                new Supplier ( name : "Supplier 1", id : 1),
                new Supplier ( name : "Supplier 2", id : 2),
                new Supplier ( name : "Supplier 3", id : 3),
                new Supplier ( name : "Supplier 4", id : 4)
                }; 
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", id, name);
        }
    }
}