using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Addon.Twitter;
using G1ANT.Language;

namespace G1ANT.Addon.Twitter
{
    [Command(Name = "twitterlogin", Tooltip = "Connect through twitter login")]
    class TwitterloginCommand : Command
    {
        public TwitterloginCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : TwitterCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter your login email credential")]
            public TextStructure email { get; set; }

            [Argument(Required = true, Tooltip = "Enter your password here ")]
            public TextStructure pword { get; set; }
            [Argument(DefaultVariable = "timeouttwitter", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments )
        {
            try
            {
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                        "chrome",
                        "twitter.com",
                        arguments.Timeout.Value,
                        false,
                        Scripter.Log,
                        Scripter.Settings.UserDocsAddonFolder.FullName);
                int wrapperId = wrapper.Id;
                OnScriptEnd = () =>
                {
                    SeleniumManager.DisposeAllOpenedDrivers();
                    SeleniumManager.RemoveWrapper(wrapperId);
                    SeleniumManager.CleanUp();
                };
                arguments.Search.Value = "/html/body/div/div/div/div[2]/header/div[2]/div[1]/div/div[2]/div[1]/div[1]/a";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div/div/div/div[2]/main/div/div/form/div/div[1]/label/div/div[2]/div/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.email.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div/div/div/div[2]/main/div/div/form/div/div[2]/label/div/div[2]/div/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.pword.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
      
            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
