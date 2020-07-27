using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using OpenQA.Selenium;

namespace G1ANT.Addon.Ola
{
    [Command(Name = "ola.search", Tooltip = "This command will search cabs on Ola")]
    class OlaSearchCommand : Command
    {
        public OlaSearchCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : OlaCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the pick up point")]
            public TextStructure pickup { get; set; }
            [Argument(Required = true, Tooltip = "Enter the drop location")]
            public TextStructure drop { get; set; }
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "/html/body/div/div/div[2]/div/div[2]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.TypeText(arguments.pickup.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div/div/div[6]/div/div/div[2]/div/div/div[5]/div/div[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div/div/div[3]/div/div[2]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.TypeText(arguments.drop.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div/div/div[6]/div/div/div[2]/div/div/div[5]/div/div[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div/div/div[5]/button";
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
