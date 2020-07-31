﻿using G1ANT.Language;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.NaukriApp
{
    [Command(Name = "naukriapp.close", Tooltip = "This command closes appium session")]
    public class CloseCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {

        }

        public CloseCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {
            var driver = OpenCommand.GetDriver();
            driver.Quit();
        }
    }
}