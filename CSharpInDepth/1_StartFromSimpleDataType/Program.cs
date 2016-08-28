using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_StartFromSimpleDataType
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList products = Product.GetSampleProducts();
            //products.Sort(new ProductNameComparer());
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
            //product3s.Sort((x, y) => x.Name.CompareTo(y.Name));
            foreach (var product3 in product3s.OrderBy(p => p.Name))
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

            Console.ReadKey();
        }
    }
}
