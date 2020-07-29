using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Addon.Medium;
using G1ANT.Language;

namespace G1ANT.Addon.Medium
{
    [Command(Name = "medium.login", Tooltip = "Helps the user login medium. Please use your mail id for further actions")]
    class MediumLoginCommand : Command
    {
        public MediumLoginCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments: MediumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter your Email ID here")]
            public TextStructure email { get; set; }

          

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                    "chrome",
                    "https://www.medium.com/",
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
                arguments.Search.Value = "/html/body/div/div/div[4]/div/div/div/div/div[3]/div[3]/h4/span/a";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[2]/div/div/div/div[2]/div/div/div/div/div[3]/div[5]/div/div/button/div/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.PressKey(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[2]/div/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div[2]/div/h4/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.email.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("Continue", arguments, arguments.Timeout.Value);
                
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while typing text to element. Text: '{arguments.email.Value}'. 'Search element phrase: '{arguments.Search.Value}'. Message: {ex.Message}", ex);
            }
        }
        
    }
}
