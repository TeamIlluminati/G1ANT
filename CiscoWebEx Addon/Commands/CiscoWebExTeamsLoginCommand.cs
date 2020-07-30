using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.CiscoWebEx
{
    [Command(Name = "ciscowebexteams.login", Tooltip = "This helps the user enter teams of ciscowebEx")]
    class CiscoWebExTeamsLoginCommand: Command
    {
        public CiscoWebExTeamsLoginCommand(AbstractScripter scripter):base(scripter)
        {

        }
        public class Arguments : CiscoWebExCommandArguments
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
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                       "chrome",
                       "https://www.webex.com/",
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
                arguments.Search.Value = "/html/body/div[1]/div/div/div[1]/div[2]/div/div/section/nav/div/div/ul/li[8]/div/a";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[1]/div/div/div[1]/div[2]/div/div/section/nav/div/div/ul/li[8]/div/div/div/ul/li[2]/div/a/div[2]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/main/div/div/div[1]/form/div[1]/div/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.email.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/main/div/div/div[1]/form/div[2]/button/span";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.PressKey("Next", arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div/div[2]/div[1]/form[1]/div[3]/div[2]/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.pword.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div/div[2]/div[1]/form[1]/div[4]/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.PressKey("Sign In", arguments, arguments.Timeout.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
