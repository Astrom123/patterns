using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class ChatDecoratorBase : IChatClient
    {
        protected readonly IChatClient _chatClient;

        public ChatDecoratorBase(IChatClient chatClient)
        {
            _chatClient = chatClient;
        }

        public virtual string SendMessage(string sender, string reciever, string message)
        {
            return _chatClient.SendMessage(sender, reciever, message);
        }

        public virtual string RecieveMessages(string[] messages)
        {
            return _chatClient.RecieveMessages(messages);
        }
    }
}
