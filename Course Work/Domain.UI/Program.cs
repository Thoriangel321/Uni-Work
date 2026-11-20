using System;
using System.Text;
using Domain.Core.Services;
using Domain.UI;

namespace Domain.UI
{
    internal class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            var service = new RepairShopService();
            var menu = new ConsoleMenu(service);
            menu.Run();
        }
    }
}