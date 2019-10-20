using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var mailBuilder = new StartMailBuilder("Vasya Sidorov");
            var mail = mailBuilder.SetTheme("Hello!")
                .AppendText("Hi, Vasya!")
                .GetResult();

            Console.WriteLine("Recipients: " + string.Join(", ", mail.Recipients));
            Console.WriteLine("Theme: " + string.Join(", ", mail.Theme));
            Console.WriteLine("Body: " + string.Join(", ", mail.Body));
        }
    }
}
