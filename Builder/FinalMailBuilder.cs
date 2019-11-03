using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class FinalMailBuilder : IFinalMailBuilder
    {
        private readonly Mail mail;
        private readonly StringBuilder message;

        public FinalMailBuilder(Mail mail, StringBuilder message)
        {
            this.mail = mail;
            this.message = message;
        }

        public IFinalMailBuilder AddRecipient(string recipient)
        {
            mail.AddRecipient(recipient);
            return this;
        }

        public IFinalMailBuilder SetTheme(string theme)
        {
            mail.Theme = theme;
            return this;
        }

        public IFinalMailBuilder AppendText(string text)
        {
            message.Append(text);
            return this;
        }

        public Mail GetResult()
        {
            mail.Body = message.ToString();
            return mail;
        }
    }
}
