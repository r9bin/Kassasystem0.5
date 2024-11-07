using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem0._5
{
    public class ProductList
    {
        public static List<Product> Products = new List<Product>();


        public static void WriteDefaultProducts(string productFilePath)
        {
            if (File.Exists(productFilePath)) return;

            string text = "Apple_300_10,50_each\n" +
                          "Banana_301_15_each\n" +
                          "Orange_302_20_each\n" +
                          "Kiwi_303_9,25_per kg\n" +
                          "Milk_304_7_each\n" +
                          "Chocolate_305_14_each\n" +
                          "Butter_306_13_each";

            File.WriteAllText(productFilePath, text);
        }

        public static void ReadProducts(string productFilePath)
        {
            if (!File.Exists(productFilePath))
            {
                Console.WriteLine("Filen finns inte.");
                return;
            }

            List<string> lines = File.ReadAllLines(productFilePath).ToList();
            foreach (string line in lines)
            {
                Product product = new Product();
                string[] strings = line.Split('_');
                product.Name = strings[0];
                product.IDnumber = Convert.ToInt32(strings[1]);
                product.Price = Convert.ToDecimal(strings[2]);
                product.PriceTypeKg = strings[3];

                Products.Add(product);
            }
        }

        public void StringList()
        {
            Console.Clear();
            Console.WriteLine("Apple ID: 300 Price: 10,50/each\n" +
                              "Banana ID: 301 Price: 15/each\n" +
                              "Orange ID: 302 Price: 20/each\n" +
                              "Kiwi ID: 303 Price: 9,25/kg\n" +
                              "Milk ID: 304 Price 7/each\n" +
                              "Chocolate ID: 305 Price: 14/each\n" +
                              "Butter ID: 306 Price: 13/each\n");        
            Console.WriteLine("Tryck på Valfri knapp för att återgå till Meny..");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
