using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Chinagri
{
    [Command(Name = "chingari.refresh", Tooltip = "Refresh the page")]
    class ChingariRefreshCommand: Command
    {
        public ChingariRefreshCommand(AbstractScripter scripter): base(scripter)
        {

        }
        public class Arguments: ChinagriCommandArguments
        {

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.Refresh();
            }
            catch(Exception ex)
            {
                throw new ApplicationException($"Error occured while closing selenium instance. Message: {ex.Message}", ex);
            }
        }
  

    }
}
