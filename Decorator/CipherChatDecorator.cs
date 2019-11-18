using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class CipherChatDecorator : ChatDecoratorBase
    {
        public CipherChatDecorator(IChatClient chatClient) : base(chatClient)
        {
        }

        public override string SendMessage(string sender, string reciever, string message)
        {
            return "<Зашифровано>" + _chatClient.SendMessage(sender, reciever, message) + "<Зашифровано>";
        }

        public override string RecieveMessages(string[] messages)
        {
            messages = messages.Select(s => s.Replace("<Зашифровано>", "")).ToArray();
            return _chatClient.RecieveMessages(messages);
        }
    }
}
