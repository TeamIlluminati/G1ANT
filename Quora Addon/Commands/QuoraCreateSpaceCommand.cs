using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using G1ANT.Addon.Quora;

namespace G1ANT.Addon.Quora
{
    [Command(Name = "quora.createspace", Tooltip = "Helps a user create their own space in Quora")]
    class QuoraCreateSpaceCommand : Command
    {
        public object Value { get; private set; }

        public QuoraCreateSpaceCommand(AbstractScripter scripter): base(scripter)
        {

        }
        public class Arguments : QuoraCommandArguments
        {
            [Argument(Required = true, Tooltip = "Write a name to the space")]
            public TextStructure aboutname { get; set;}
            [Argument(Required = true, Tooltip = "Write a 1 line statement to your space")]
            public TextStructure about { get; set; }
            [Argument(DefaultVariable = "timeoutquora", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments )
        {
            try
            {
                arguments.Search.Value = "/html/body/div[1]/div/div/div[2]/div/div/div[2]/div/div/div/div/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div/div/div[4]/div/div[1]/div[1]/div[2]/button[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div/div[1]/div/div/div/div/div[2]/div/div[3]/div[1]/div[2]/div/div/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.aboutname.Value,arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div/div[1]/div/div/div/div/div[2]/div/div[3]/div[1]/div[4]/div[2]/div/div/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.about.Value, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div/div[1]/div/div/div/div/div[2]/div/div[3]/div[2]/div/div/span";
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
