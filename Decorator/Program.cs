using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var chatClient = new ChatClient();
            var hideDecorator = new HideNamesDecorator(chatClient);
            var cipherAndHideDecorator = new CipherChatDecorator(hideDecorator);

            var message = cipherAndHideDecorator.SendMessage("Вася", "Петя", "Привет");
            Console.WriteLine(message); // <Зашифровано>-267533453 said to -1833945071: Привет<Зашифровано>"
            Console.WriteLine(cipherAndHideDecorator.RecieveMessages(new String[1] {message})); // -267533453 said to -1833945071: Привет
        }
    }
}
