using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example_06.ChainOfResponsibility;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var bancomat = new Bancomat();
            var banknotes = bancomat.GiveMoney(1700, CurrencyType.Ruble);

            Console.WriteLine("Ваши наличные: ");
            foreach (var banknote in banknotes)
            {
                Console.Write(banknote + " "); // 1000 200 200 200 10 10 10 10 10 10 10 10 10 10
            }

            banknotes = bancomat.GiveMoney(121, CurrencyType.Dollar); // System.Exception: Невозможно выдать данную сумму
        }
    }
}
