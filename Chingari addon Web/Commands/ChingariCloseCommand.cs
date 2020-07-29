using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Chinagri
{
    [Command(Name = "chingari.close", Tooltip = "Closes the web application")]
    class ChingariCloseCommand: Command
    {
        public ChingariCloseCommand(AbstractScripter scripter): base(scripter)
        {

        }
        public class Arguments : ChinagriCommandArguments
        {

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.QuitCurrentWrapper();
            }
            catch(Exception ex)
            {
                throw new ApplicationException($"Error occured while closing selenium instance. Message: {ex.Message}", ex);
            }

        }
    }
}
