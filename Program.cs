using System.Transactions;

namespace Kassasystem0._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            var productList = new ProductList();
            var switchMenu = new SwitchMenu(menu, productList);
            var transaction = new Transaction();
            var productPath = $"../../../KassaSystem/ProductListText.txt";



            ProductList.WriteDefaultProducts(productPath);
            ProductList.ReadProducts(productPath);


            var userChoice = menu.StartMenu();
            switchMenu.SwitchCase(userChoice, transaction);
        }
    }
}
