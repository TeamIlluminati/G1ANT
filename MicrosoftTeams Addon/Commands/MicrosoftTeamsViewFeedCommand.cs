﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.MicrosoftTeams
{
    [Command(Name = "microsoftteams.viewfeed", Tooltip = "View the activities of your teams")]
    class MicrosoftTeamsViewFeedCommand:Command
    {
        public MicrosoftTeamsViewFeedCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : MicrosoftTeamsCommandArguments
        {

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                       "chrome",
                       "https://teams.microsoft.com/_?culture=en-in&country=IN&lm=deeplink&lmsrc=homePageWeb&cmpid=WebSignIn#/conversations/General?threadId=19:bbfa8614ff11455084419d2dbe5dff3d@thread.tacv2&messageId=1594783221657&replyChainId=1594627895659&ctx=channel",
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
                arguments.Search.Value = "/html/body/div[1]/div[2]/div[1]/app-bar/nav/ul/li[1]/button";
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
