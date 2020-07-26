using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using OpenQA.Selenium;

namespace G1ANT.Addon.Messenger
{
    [Command(Name = "messenger.voicecall", Tooltip = "You can Voice call a recipient on Messenger using this command")]
    class MessengerVoicecallCommand : Command
    {
        public MessengerVoicecallCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : MessengerCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the recipient you want to send message")]
            public TextStructure recipient { get; set; }
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "/html/body/div[1]/div/div/div[1]/div[2]/div[3]/div/div[1]/div/div/div[1]/span[1]/label/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.TypeText(arguments.recipient.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div/div/div[1]/div[2]/div[3]/div/div[1]/div/div/div[1]/span[1]/div/div/div[2]/ul";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div/div/div[2]/span/div[1]/ul/li[1]/a";
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
