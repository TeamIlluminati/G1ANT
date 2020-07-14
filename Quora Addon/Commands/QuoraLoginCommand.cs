using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Addon.Quora;
using G1ANT.Language;

namespace G1ANT.Addon.Quora
{
    [Command(Name= "login", Tooltip = "this helps the user enter the credentials")]
    class QuoraLoginCommand : Command
    {
        public QuoraLoginCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments: QuoraCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter your Email ID here")]
            public TextStructure email { get; set; }
            
            [Argument(Required = true, Tooltip = "Enter your password")]
            public TextStructure pword { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                    "chrome",
                    "https://www.quora.com/",
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
                arguments.Search.Value = //*[@id="__w2_wJ2DMLa020_email"];
                arguments.By.Value = "xpath"; 
                SeleniumManager.CurrentWrapper.TypeText(arguments.email.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                arguments.Search.Value = //*[@id="__w2_wJ2DMLa020_password"];
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.pword.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while typing text to element. Text: '{arguments.email.Value}'. 'Search element phrase: '{arguments.Search.Value}'.'{arguments.pword.Value}'. Message: {ex.Message}", ex);
            }
        }

    }
}
