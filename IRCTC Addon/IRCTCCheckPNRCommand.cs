using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using System.Threading;


namespace G1ANT.Addon.IRCTC
{
    [Command(Name = "irctc.pnrstatus", Tooltip = "This command checks the pnr status of user's booking on  irctc ")]
    public class IRCTCCheckPNRCommand : Command
    {
        public IRCTCCheckPNRCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {

            [Argument(Required = true, Tooltip = "Enter the pnr number to check")]
            public TextStructure pnr { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "/html/body/app-root/app-home/div[2]/div/app-main-page/div[1]/div/div[1]/div/div/div[1]/div/app-jp-input/div[5]/div[1]/a/label";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(5000);

                arguments.Search.Value = "/html/body/div[2]/div[2]/div[2]/div[6]/div/div[2]/div/div[2]/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.pnr.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[2]/div[2]/div[2]/div[6]/div/div[3]/div/div[2]/div/input[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }


}