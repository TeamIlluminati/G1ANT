using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.MicrosoftTeams
{
    [Command(Name = "microsoftteams.createchat", Tooltip = "To create a chat group")]
    class MicrosoftTeamsChatcreationCommand : Command
    {
        public MicrosoftTeamsChatcreationCommand(AbstractScripter scripter): base(scripter)
        {

        }
        public class Arguments : MicrosoftTeamsCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the email id or name of the participant")]
            public TextStructure name { get; set; }

            [Argument(Required = true, Tooltip = "Enter the chat description")]
            public TextStructure message { get; set; }

            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
            [Argument(Tooltip = "By default, waits until the webpage fully loads")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(false);
            [Argument(Tooltip = "Name of a variable where the command's result will be stored")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
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
                int wrapperId = wrapper.Id;
                OnScriptEnd = () =>
                {
                    SeleniumManager.DisposeAllOpenedDrivers();
                    SeleniumManager.RemoveWrapper(wrapperId);
                    SeleniumManager.CleanUp();
                };
                arguments.Search.Value = "/html/body/div[1]/div[1]/app-header-bar/div/power-bar/div/div/button/ng-include/svg";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div[2]/div[2]/div[1]/div/messages-header/div[2]/div/message-pane/div[1]/div[2]/chat-people-picker/div/div/div[1]/recipient-line/div/div/div[1]/div/people-picker/div/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.name.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div[2]/div[2]/div[1]/div/messages-header/div[2]/div/message-pane/div[2]/div[3]/new-message/div/div[2]/form/div[4]/div[1]/div[2]/div/div/div[2]/div/div/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.message.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div[2]/div[2]/div[1]/div/messages-header/div[2]/div/message-pane/div[2]/div[3]/new-message/div/div[3]/div[2]/button/ng-include/svg";
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
