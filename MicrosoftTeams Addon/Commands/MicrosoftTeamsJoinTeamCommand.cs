using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.MicrosoftTeams
{
    [Command(Name = "microsoftteams.jointeam", Tooltip = "Helps the person login to the team with a entry code")]
    class MicrosoftTeamsJoinTeamCommand :Command
    {
        public MicrosoftTeamsJoinTeamCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : MicrosoftTeamsCommandArguments
        {
            [Argument(Required = true, Tooltip = "Specify the code for joining the team")]
            public TextStructure code { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);


        }
        
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                       "chrome",
                       "https://www.microsoft.com/en-in/microsoft-365/microsoft-teams/group-chat-software",
                       arguments.Timeout.Value,
                       false,
                       Scripter.Log,
                       Scripter.Settings.UserDocsAddonFolder.FullName);
                OnScriptEnd = () =>
                {
                    SeleniumManager.DisposeAllOpenedDrivers();
                    SeleniumManager.RemoveWrapper(wrapper);
                };
                arguments.Search.Value = "/html/body/div[1]/div[2]/div[2]/div[1]/teams-grid/div/div[1]/div/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div[2]/div[2]/div[1]/div/div[2]/div/div[1]/div[2]/div[2]/div/div/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.code.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div[2]/div[2]/div[1]/div/div[2]/div/div[1]/div[2]/div[2]/div/div/div[2]/div/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.PressKey("Join team", arguments, arguments.Timeout.Value);


            }
            catch(Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
            


    }
}
