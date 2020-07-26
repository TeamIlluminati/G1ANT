using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using OpenQA.Selenium;

namespace G1ANT.Addon.Pinterest
{
    [Command(Name = "pinterest.sendmsg", Tooltip = "This command will send message on Pinterest")]
    class PinterestMessageCommand : Command
    {
        public PinterestMessageCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : PinterestCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the recipient you want to send message")]
            public TextStructure recipient { get; set; }
            [Argument(Required = true, Tooltip = "Enter the content of the message you want to send")]
            public TextStructure content { get; set; }
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

        }

        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "/html/body/div[1]/div[1]/div[2]/header/div/div/div[2]/div/div/div/div[6]/div[3]/div/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div[1]/div[3]/div[2]/div/div/div/div[2]/div[3]/div[1]/div/div/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.TypeText(arguments.recipient.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div[1]/div[3]/div[2]/div/div/div[2]/div[1]/div/div/div[2]/div[2]/div[2]/div/div[1]/div/div/div/div[2]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div[1]/div[3]/div[2]/div/div/div[2]/div[2]/div/div/div/div[1]/div[1]/div/textarea";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.TypeText(arguments.content.Value, arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
