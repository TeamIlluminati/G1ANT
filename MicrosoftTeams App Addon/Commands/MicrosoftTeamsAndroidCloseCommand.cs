﻿using G1ANT.Language;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.MicrosoftTeamsAndroid 
{
    [Command(Name = "microsoftteamsandroid.close", Tooltip = "This command closes appium session")]
    public class CloseCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {

        }

        public CloseCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {
            var driver = MicrosoftTeamsAndroidOpenCommand.GetDriver();
            driver.Quit();
        }
    }
}
