using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Kassasystem0._5
{
    public class SwitchMenu
    {
        private readonly Menu _menu;
        private readonly ProductList _productList;

        public SwitchMenu(Menu menu, ProductList productList)
        {
            this._menu = menu;
            this._productList = productList;
        }



        public void SwitchCase(int userChoice, Transaction transaction)
        {
            var date = DateTime.Now.ToString("yyyyMMdd");
            var filePath = $"../../../KassaSystem/RECEIPT_{date}.txt";
            var customerCart = new List<Product>();


            switch (userChoice)
            {
                case 1:
                    transaction.ProcessTransaction(filePath, customerCart, _menu, this);
                    break;

                case 2:
                    _productList.StringList();

                    int UserChoice = _menu.StartMenu();
                    SwitchCase(UserChoice, transaction);
                    break;

                case 0:
                    Console.Clear();
                    Console.WriteLine("Programmet Avslutas..");
                    break;

                default:
                    Console.WriteLine("Ogiltigt val.");
                    break;
            }
        }
    }
}
