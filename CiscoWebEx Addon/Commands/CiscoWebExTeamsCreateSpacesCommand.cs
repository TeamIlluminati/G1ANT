using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.CiscoWebEx
{
    [Command(Name = "ciscowebexteams.createspace", Tooltip = " Helps create spaces in webex teams")]
    class CiscoWebExTeamsCreateSpacesCommand : Command
    {
        public CiscoWebExTeamsCreateSpacesCommand(AbstractScripter scripter ): base(scripter)
        {

        }
        public class Arguments : CiscoWebExCommandArguments
        {

            [Argument(Required = true, Tooltip = "Enter the Information here")]
            public TextStructure info { get; set; }

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                       "chrome",
                       "https://teams.webex.com/spaces/new",
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
                arguments.Search.Value = "/html/body/main/div/div[1]/div[4]/div[1]/nav/ul/li[1]/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/main/div/div[1]/div[4]/div[2]/div[2]/div[2]/div/div[1]/div[3]/div[1]/div/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.info.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/main/div/div[1]/div[4]/div[2]/div[2]/div[2]/div/div[1]/div[3]/div[2]/div[2]/div/button";
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
