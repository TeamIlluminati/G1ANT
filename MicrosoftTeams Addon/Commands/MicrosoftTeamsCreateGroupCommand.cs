using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.MicrosoftTeams
{
    [Command(Name = "microsoftteams.creategroup", Tooltip = "Helps the user create a group")]
    class MicrosoftTeamsCreateGroupCommand : Command
    {
        public MicrosoftTeamsCreateGroupCommand(AbstractScripter scripter): base(scripter)
        {

        }
        public class Arguments: MicrosoftTeamsCommandArguments
        {
            [Argument(Required = true, Tooltip = "Provide the name of the group")]
            public TextStructure name { get; set; }

            [Argument(Required = true, Tooltip = "Provide the objective of the group")]
            public TextStructure description { get; set; }
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
                arguments.Search.Value = "/html/body/div[1]/div[2]/div[2]/div[1]/teams-grid/div/div[1]/div/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div[2]/div[2]/div[1]/div/div[2]/div/div[1]/div[2]/div[1]/div/div/div[2]/div/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.PressKey("Create Team",arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[4]/div[2]/div/div/div/div[2]/div/form/section/div[2]/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.name.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[4]/div[2]/div/div/div/div[2]/div/form/div[2]/div[2]/textarea";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.description.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[4]/div[2]/div/div/div/div[3]/div/div[2]/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.PressKey("Next", arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.Refresh();

                arguments.Search.Value = "/html/body/div[4]/div[2]/div/div/div/div[3]/div/div/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.PressKey("Skip", arguments, arguments.Timeout.Value);



            }
            catch(Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
