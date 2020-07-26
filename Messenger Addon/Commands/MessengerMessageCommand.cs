using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using OpenQA.Selenium;

namespace G1ANT.Addon.Messenger
{
    [Addon(Name = "messenger.msg", Tooltip = "This command will send message on Messenger.")]
    class MessengerMessageCommand : Command
    {
        public MessengerMessageCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : MessengerCommandArguments
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
                arguments.Search.Value = "/html/body/div[1]/div/div/div[1]/div[1]/a[2]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div/div/div[2]/span/div[1]/div[2]/div[1]/div/div/div/span[1]/label/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.TypeText(arguments.recipient.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[5]/div/div/div/div/div[1]/div/div/div/div/div[1]/ul";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div/div/div[2]/span/div[2]/div/div[2]/div[2]/div[3]/div/div/div[1]/div/div[2]/div";
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

