using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.CiscoWebEx
{
    [Command(Name = "ciscowebexteams.videocall", Tooltip = "Helps a person do a video call")]
    class CiscoWebExVideoCallsCommand: Command
    {
        public CiscoWebExVideoCallsCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : CiscoWebExCommandArguments
        {

            [Argument(Required = true, Tooltip = "Enter the phone number here")]
            public TextStructure phone { get; set; }
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                       "chrome",
                       "https://teams.webex.com/calls",
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
                arguments.Search.Value = "/html/body/main/div/div[1]/div[4]/div[1]/nav/ul/li[3]/button/span";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/main/div/div[1]/div[4]/div[2]/div[2]/div[2]/div[1]/div/div/div/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.phone.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/main/div/div[1]/div[4]/div[2]/div[2]/div[2]/button/span";
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
