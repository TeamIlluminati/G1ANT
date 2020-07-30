using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.CiscoWebEx
{
    [Command(Name = "cisco.schedule", Tooltip = "Helps User schedule his or her meeting")]
    class CiscoWebExScheduleCommand : Command
    {
        public CiscoWebExScheduleCommand(AbstractScripter scripter): base(scripter)
        {

        }
        public class Arguments : CiscoWebExCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the Information here")]
            public TextStructure info { get; set; }
            [Argument(Required = true, Tooltip = "Enter the Date here")]
            public TextStructure date { get; set; }
            [Argument(Required = true, Tooltip = "Enter the Hours here")]
            public TextStructure hour { get; set; }
            [Argument(Required = true, Tooltip = "Enter the Minutes here")]
            public TextStructure minutes { get; set; }
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                       "chrome",
                       "https://meetingsapac35.webex.com/webappng/sites/meetingsapac35/dashboard/home",
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
                arguments.Search.Value = "/html/body/div[1]/div[3]/div/div/div[4]/div[1]/div/div[1]/div[1]/div[1]/div/div[2]/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div[3]/div/div/div[4]/div[1]/div/div/div/section/form/div[2]/div/div/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.info.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div[3]/div/div/div[4]/div[1]/div/div/div/section/form/div[4]/div/div[1]/a/span[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[7]/span/div/div[1]/div/div/div[1]/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.date.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[7]/span/div/div[2]/div[1]/div[1]/div[2]/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.hour.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[7]/span/div/div[2]/div[1]/div[2]/div[2]/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.minutes.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[7]/span/div/div[2]/div[3]/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div[3]/div/div/div[4]/div[1]/div/div/div/section/form/div[9]/div/button[2]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
            }
            catch(Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
