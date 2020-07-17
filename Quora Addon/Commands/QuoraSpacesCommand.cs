using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using G1ANT.Addon.Quora;

namespace G1ANT.Addon.Quora
{
    [Command(Name = "quora.space", Tooltip = "Allows user to explore his spaces")]
    class QuoraSpacesCommand : Command
    {
        public QuoraSpacesCommand(AbstractScripter scripter): base(scripter)
        {

        }
        public class Arguments:QuoraCommandArguments
        {
            [Argument(DefaultVariable = "timeoutquora", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "/html/body/div[1]/div/div/div[2]/div/div/div[2]/div/div/div/div/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div/div/div[2]/div/div/div[2]/div/div[2]/div/div[1]/div/div[1]/a/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div/div/div[4]/div/div[1]/div[1]/div[2]/button[2]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
            }
            catch(Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
