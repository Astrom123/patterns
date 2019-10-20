using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class StartMailBuilder : IStartMailBuilder
    {
        private readonly Mail mail;
        private readonly StringBuilder message;

        public StartMailBuilder(String recipient)
        {
            mail = new Mail(recipient);
            message = new StringBuilder();
        }

        public IStartMailBuilder AddRecipient(string recipient)
        {
            mail.AddRecipient(recipient);
            return this;
        }

        public IFinalMailBuilder AppendText(string text)
        {
            message.Append(text);
            return new FinalMailBuilder(mail, message);
        }

        public IStartMailBuilder SetTheme(string theme)
        {
            mail.Theme = theme;
            return this;
        }
    }
}
