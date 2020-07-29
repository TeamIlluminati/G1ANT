using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Line
{
    [Command(Name = "line.close", Tooltip = "Closes the line application for the web")]
    class LineCloseWebCommand : Command
    {
        public LineCloseWebCommand(AbstractScripter scripter): base(scripter)
        {

        }
        public class Arguments: LineCommandArguments
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
                throw new ApplicationException($"Error occured while closing selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
