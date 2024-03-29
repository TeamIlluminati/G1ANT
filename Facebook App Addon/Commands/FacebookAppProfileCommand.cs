﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.MultiTouch;



namespace G1ANT.Addon.FacebookApp
{
    [Command(Name = "fbapp.profile", Tooltip = "This command displays user's profile in Facebook app")]

    public class FacebookAppProfileCommand : Language.Command
    {
        public FacebookAppProfileCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public class Arguments : CommandArguments
        {
            // Enter all arguments you need
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

        }
        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "//android.view.View[@content-desc='Profile, Tab 3 of 6']";
            arguments.By.Value = "xpath";

            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();

        }
    }
}