using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.CiscoWebEx
{
    [Command(Name = "ciscowebex.close", Tooltip = "Closes the webpage")]
    class CiscoWebExCloseCommand : Command
    {
        public CiscoWebExCloseCommand(AbstractScripter scripter): base(scripter)
        {

        }
        public class Arguments : CiscoWebExCommandArguments
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
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);

            }
        }
    }
}
