using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.CiscoWebEx
{
    [Command(Name = "cisco.startmeeting", Tooltip = "Attend a regular meeting")]
    class CiscoStartAMeetingCommand : Command
    {
        public CiscoStartAMeetingCommand(AbstractScripter scripter): base(scripter)
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
                arguments.Search.Value = "/html/body/div[1]/div[3]/div/div/div[4]/div[1]/div/div[1]/div[1]/div[1]/div/div[2]/div/a/div/button[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                //grant permission always 

                arguments.Search.Value = "/html/body/div/div[3]/div/div[1]/div/div[2]/div[1]/div[2]/div[3]/a";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);


                SeleniumManager.CurrentWrapper.Refresh();

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
