using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public interface IChatClient
    {
        string SendMessage(string sender, string reciever, string message);
        string RecieveMessages(string[] messages);
    }

    public class ChatClient : IChatClient
    {
        public string SendMessage(string sender, string reciever, string message)
        {
            return $"{sender} said to {reciever}: {message}";
        }

        public string RecieveMessages(string[] messages)
        {
            return string.Join("\n", messages);
        }
    }
}
