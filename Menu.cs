using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem0._5
{
    public class Menu
    {
        public int StartMenu()
        {
            int userInput;
            Console.WriteLine("KASSA");
            Console.WriteLine("1. Ny kund");
            Console.WriteLine("2. Produktlista");
            Console.WriteLine("0. Avsluta");
            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 0 || userInput > 2)
            {
                Console.WriteLine("Felaktig inmatning, försök igen");
            }
            return userInput;
        }
    }
}
