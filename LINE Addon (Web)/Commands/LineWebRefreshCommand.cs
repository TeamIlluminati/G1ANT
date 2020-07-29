using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Line
{
    [Command(Name = "line.refresh", Tooltip = "Refreshes the page")]
    class LineWebRefreshCommand : Command
    {
        public LineWebRefreshCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : LineCommandArguments
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
                throw new ApplicationException($"Error occured while refreshing selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
