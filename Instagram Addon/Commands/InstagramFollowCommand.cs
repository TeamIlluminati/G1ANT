using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using OpenQA.Selenium;

namespace G1ANT.Addon.Instagram
{
    [Command(Name = "instagram.follow", Tooltip = "This command will send a follow request on instagram")]
    class InstagramFollowCommand : Command
    {
        public InstagramFollowCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : InstagramCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the recipient you want to send follow request")]
            public TextStructure recipient { get; set; }
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "/html/body/div[1]/section/nav/div[2]/div/div/div[2]/div/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.TypeText(arguments.recipient.Value, arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/section/main/div/header/section/div[1]/button";
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
