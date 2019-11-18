using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class HideNamesDecorator : ChatDecoratorBase
    {
        public HideNamesDecorator(IChatClient chatClient) : base(chatClient)
        {
        }

        public override string SendMessage(string sender, string reciever, string message)
        {
            sender = sender.GetHashCode().ToString();
            reciever = reciever.GetHashCode().ToString();
            return _chatClient.SendMessage(sender, reciever, message);
        }
    }
}
