using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem0._5
{
    public class Transaction
    {
        public void ProcessTransaction(string filePath, List<Product> customerCart, Menu menu, SwitchMenu switchMenu)
        {
            using (StreamWriter kvittoStream = new StreamWriter(filePath, append: true))
            {
                decimal totalcost = 0;
                

                while (true)
                {
                    totalcost = 0;

                    Console.Clear();
                    Console.WriteLine("KASSA");
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"KVITTO    {DateTime.Now}");

                    foreach (var product in customerCart)
                    {
                        Console.WriteLine($"{product.Name} {product.Ammount} * {product.Price} = {product.Ammount * product.Price}");
                        totalcost += product.Price * product.Ammount;
                    }

                    Console.WriteLine($"Total: {totalcost}");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("kommandon:");
                    Console.WriteLine("<productid> <antal>");
                    Console.WriteLine("PAY");
                    Console.Write("Kommando: ");
                    string kommando = Console.ReadLine().ToUpper();

                    if (kommando == "PAY")
                    {
                        Reciept(customerCart, kvittoStream, totalcost);
                        break;
                    }

                    AddProductToCart(kommando, customerCart);
                }
            }

            int newUserChoice = menu.StartMenu();
            switchMenu.SwitchCase(newUserChoice, this);
        }


        public void AddProductToCart(string kommando, List<Product> customerCart)
        {
            int ConvID;
            int ConvAntal;
            string[] strings = kommando.Split(' ');

            if (strings.Length == 2)
            {
                bool isIdValid = int.TryParse(strings[0], out ConvID);
                bool isAmountValid = int.TryParse(strings[1], out ConvAntal);

                if (isIdValid && isAmountValid && ConvAntal > 0)
                {
                    var productToAdd = ProductList.Products.FirstOrDefault(p => p.IDnumber == ConvID);

                    if (productToAdd != null)
                    {
                        var existingProduct = customerCart.FirstOrDefault(p => p.IDnumber == productToAdd.IDnumber);

                        if (existingProduct != null)
                        {
                            existingProduct.Ammount += ConvAntal;
                        }
                        else
                        {
                            productToAdd.Ammount = ConvAntal;
                            customerCart.Add(productToAdd);
                        }
                    }
                }
            }
        }

        public void Reciept(List<Product> customerCart, StreamWriter kvittoStream, decimal totalcost)
        {
            Console.Clear();
            kvittoStream.WriteLine("_________________________");
            kvittoStream.WriteLine($"{DateTime.Now}");
            kvittoStream.WriteLine("--------------------------");
            foreach (var product in customerCart)
            {
                kvittoStream.WriteLine($"{product.Name} {product.Ammount} * {product.Price} = {product.Ammount * product.Price}");
            }
            kvittoStream.WriteLine("==========================");
            kvittoStream.WriteLine($"Total Price: {totalcost}");
            kvittoStream.WriteLine("_________________________");
            kvittoStream.WriteLine();
            
        }
    }
}
