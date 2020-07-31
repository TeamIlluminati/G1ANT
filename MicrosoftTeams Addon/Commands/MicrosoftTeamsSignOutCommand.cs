using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.MicrosoftTeams
{
    [Command(Name = "microsoftteams.signout", Tooltip = "Sign out of teams")]
    class MicrosoftTeamsSignOutCommand: Command
    {
        public MicrosoftTeamsSignOutCommand(AbstractScripter scripter): base(scripter)
        {

        }
        public class Arguments : MicrosoftTeamsCommandArguments
        {
            [Argument(Tooltip = "By default, waits until the webpage fully loads")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(false);

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.Navigate("https://login.microsoftonline.com/common/oauth2/authorize?response_type=id_token&client_id=5e3ce6c0-2b1f-4285-8d4b-75ee78787346&redirect_uri=https%3A%2F%2Fteams.microsoft.com%2Fgo&state=51a201c2-815c-428d-bb98-b2f1c83769bc&&client-request-id=ffff3113-967c-4553-97dc-cf6a98f0116d&x-client-SKU=Js&x-client-Ver=1.0.9&nonce=556725eb-c56f-4bfc-bcea-0c7f07228568&domain_hint=", arguments.Timeout.Value, arguments.NoWait.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
