using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Quora
{
    [Command(Name = "quora.close", Tooltip = "This closes the instance of Quora Web Browser")]
    class QuoraCloseCommand : Command
    {
        public QuoraCloseCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : QuoraCommandArguments
        {

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.QuitCurrentWrapper();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
