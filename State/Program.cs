using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            var copyMachine = new CopyMachineContext();

            copyMachine.GetChange(); // Wrong operation

            copyMachine.PutMoney(100);
            copyMachine.SelectDevice("USB");
            copyMachine.SelectFile("Cats.jpg");
            copyMachine.Print(); // Printing Cats.jpg from USB...
            copyMachine.PrintMore(true);
            copyMachine.SelectFile("AnotherCats.jpg");
            copyMachine.Print(); // Printing AnotherCats.jpg from USB...
            copyMachine.PrintMore(false);
            copyMachine.GetChange(); // Your change is 80
        }
    }
}
