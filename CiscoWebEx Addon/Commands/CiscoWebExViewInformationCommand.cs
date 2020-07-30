using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.CiscoWebEx
{
    [Command(Name = "ciscowebEx.viewinfo", Tooltip = "Information about meetings you've hosted will appear here")]
    class CiscoWebExViewInformationCommand : Command
    {
        public CiscoWebExViewInformationCommand(AbstractScripter scripter): base(scripter)
        {

        }
        public class Arguments : CiscoWebExCommandArguments
        {

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                     "chrome",
                     "https://meetingsapac35.webex.com/webappng/sites/meetingsapac35/insight/home",
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
                arguments.Search.Value = "";
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
