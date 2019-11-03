using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Mail
    {
        public List<string> Recipients { get; }
        public string Theme { get; set; }
        public string Body { get; set; }

        public Mail(string recipient)
        {
            Recipients = new List<string>
            {
                recipient
            };
        }

        public void AddRecipient(string recipient)
        {
            Recipients.Add(recipient);
        }
    }
}
