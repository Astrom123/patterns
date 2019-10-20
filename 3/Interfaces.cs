using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public interface IStartMailBuilder
    {
        IStartMailBuilder AddRecipient(string recipient);
        IStartMailBuilder SetTheme(string theme);
        IFinalMailBuilder AppendText(string text);
    }

    public interface IFinalMailBuilder
    {
        IFinalMailBuilder AddRecipient(string recipient);
        IFinalMailBuilder SetTheme(string theme);
        IFinalMailBuilder AppendText(string text);
        Mail GetResult();
    }
}
