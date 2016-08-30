using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
//using IronPython.Hosting;
//using Microsoft.Scripting.Hosting;

namespace _1_StartFromSimpleDataType
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList products = Product.GetSampleProducts();
            products.Sort(new ProductNameComparer());
            foreach (Product product in products)
            {
                if (product.Price > 10m)
                {
                    Console.WriteLine(product);
                }
            }
            Console.WriteLine("***C#1***");
            Console.WriteLine();

            List<Product2> product2s = Product2.GetSampleProducts();
            product2s.Sort(delegate(Product2 x, Product2 y)
            {
                return x.Name.CompareTo(y.Name);
            });
            foreach (var product2 in product2s)
            {
                Console.WriteLine(product2);
            }
            Console.WriteLine("***Query***");
            Predicate<Product2> test = delegate(Product2 p2) { return p2.Price > 10m; };
            List<Product2> matches = product2s.FindAll(test);
            Action<Product2> print = Console.WriteLine;
            matches.ForEach(print);
            Console.WriteLine("***C#2***");
            Console.WriteLine();

            List<Product3> product3s = Product3.GetSampleProducts();
            List<Supplier> suppliers = Supplier.GetSampleSupplier();
            //product3s.Sort((x, y) => x.Name.CompareTo(y.Name));
            var filtered = from p in product3s
                join s in suppliers
                    on p.Id equals s.Id
                where p.Price > 10
                orderby s.Name, p.Name
                select new { SupplierName = s.Name, ProductName = p.Name };
            foreach (var v in filtered)
            {
                Console.WriteLine("Supplier={0}; Product={1}", v.SupplierName, v.ProductName);
            }
            Console.WriteLine("***Linq***");
            foreach (var product3 in product3s.OrderByDescending(p => p.Date))
            {
                Console.WriteLine(product3);
            }
            Console.WriteLine("***Query***");
            foreach (var product3 in product3s.Where(p => p.Price > 10))
            {
                Console.WriteLine(product3);
            }
            Console.WriteLine("***C#3***");
            Console.WriteLine();

            //ScriptEngine engine = Python.CreateEngine();
            //ScriptScope scope = engine.ExecuteFile("FindProducts.py");
            //dynamic ps = scope.GetVariable("products");
            //foreach (var p in ps)
            //{
            //    Console.WriteLine("{0}, {1}", p.ProductName, p.Price);
            //}
            

            Console.ReadKey();
        }
    }
}
