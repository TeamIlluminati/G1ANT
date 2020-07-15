using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Addon.Quora;
using G1ANT.Language;


namespace G1ANT.Addon.Quora
{
    [Command(Name = "searchquora", Tooltip = "This will be used to search for a particular question")]
    class QuorasearchCommand : Command
    {
        public QuorasearchCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : QuoraCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the value to be searched ")]
            public TextStructure keyword { get; set; }
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        { 
            try
            {
                arguments.Search.Value = "/html/body/div[1]/div/div/div[2]/div/div/div[3]/form/div/div/div/div/div/div/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.keyword.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
            }

            catch(Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}

