using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using OpenQA.Selenium;

namespace G1ANT.Addon.Instagram
{
    [Command(Name = "instagram.senddm", Tooltip = "This command will send a direct message to the recipient")]
    class InstagramSenddmCommand : Command
    {
        public InstagramSenddmCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : InstagramCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the content to send")]
            public TextStructure content { get; set; }
            [Argument(Required = true, Tooltip = "Enter the recipient you want to send message")]
            public TextStructure recipient { get; set; }
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                
                arguments.Search.Value = "/html/body/div[1]/section/nav/div[2]/div/div/div[3]/div/div[2]/a/svg/path";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/section/div/div[2]/div/div/div[1]/div[1]/div/div[3]/button/svg";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[4]/div/div/div[2]/div[1]/div/div[2]/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.recipient.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[4]/div/div/div[2]/div[2]/div[1]/div/div[3]/button/span";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[4]/div/div/div[1]/div/div[2]/div/button/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/section/div/div[2]/div/div/div[2]/div[2]/div/div[2]/div/div/div[2]/textarea";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.content.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/section/div/div[2]/div/div/div[2]/div[2]/div/div[2]/div/div/div[3]/button";
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
