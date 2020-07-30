using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.CiscoWebEx
{
    [Command(Name = "ciscowebex.viewmeetings", Tooltip = "View the list of meetings present")]
    class CiscoWebExViewMeetingsCommand : Command
    {
        public CiscoWebExViewMeetingsCommand(AbstractScripter scripter): base(scripter)
        {

        }
        public class Arguments : CiscoWebExCommandArguments
        {
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
                arguments.Search.Value = "/html/body/div[1]/div[3]/div/div/div[1]/div[2]/div[1]/div[2]/ul/li[2]/a";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.Refresh();

            }
            catch(Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
