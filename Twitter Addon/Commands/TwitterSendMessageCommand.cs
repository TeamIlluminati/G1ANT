using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Addon.Twitter;
using G1ANT.Language;

namespace G1ANT.Addon.Twitter
{
    [Command(Name = "twitter.sendmessage", Tooltip = "This enables a user to send message to a friend")]
    class TwitterSendMessageCommand : Command
    {
        public TwitterSendMessageCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : TwitterCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the name of the person here")]
            public TextStructure createnamevalue { get; set; } 
            [Argument(Required = true, Tooltip = "Enter the message")]
            public TextStructure postvalue { get; set; }

            [Argument(DefaultVariable = "timeouttwitter", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "/html/body/div/div/div/div[2]/header/div/div/div/div[1]/div[2]/nav/a[4]/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div/div/div/div[2]/main/div/div/div/div[2]/div[2]/section/div/div/a/div/span/span";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div/div/div/div[2]/main/div/div/div/div[2]/div[1]/div/div/div[2]/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments.createnamevalue.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div/div/div/div[1]/div[2]/div/div/div/div/div/div[2]/div[2]/div/div[1]/div/div/div/div[3]/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div/div/div/div[2]/main/div/div/div/div[2]/div/div/aside/div[2]/div[2]/div/div/div/div/div[1]/div/div/div/div[2]/div/div/div/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments.postvalue.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div/div/div/div[2]/main/div/div/div/div[2]/div/div/aside/div[2]/div[3]/div/svg";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
            
            }
            catch(Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance- unable to process message. Message: {ex.Message}", ex);
            }
        }
    }
}
