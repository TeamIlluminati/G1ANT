using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using OpenQA.Selenium;

namespace G1ANT.Addon.Messenger
{
    [Command(Name = "messenger.login", Tooltip = "You can login on Messenger using this command")]
    class MessengerLoginCommand : Command
    {
        public MessengerLoginCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : MessengerCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the Login e-mail ID here")]
            public TextStructure email { get; set; }

            [Argument(Required = true, Tooltip = "Enter the password here")]
            public TextStructure pword { get; set; }
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        {
            try
            {

                arguments.Search.Value = "/html/body/div/div/div[1]/div/div/div/div[1]/div/div/div/div[3]/div[1]/div/div[2]/div[1]/div/form/div/input[6]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.TypeText(arguments.email.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div/div/div[1]/div/div/div/div[1]/div/div/div/div[3]/div[1]/div/div[2]/div[1]/div/form/div/input[7]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.TypeText(arguments.pword.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div/div/div[1]/div/div/div/div[1]/div/div/div/div[3]/div[1]/div/div[2]/div[1]/div/form/div/button";
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
