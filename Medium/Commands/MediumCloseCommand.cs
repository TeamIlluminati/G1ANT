using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Medium
{
    [Command(Name = "medium.close", Tooltip = "This closes the instance of Medium")]
    class MediumCloseCommand : Command
    {
        public MediumCloseCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : MediumCommandArguments 
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
