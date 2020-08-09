﻿using System.Windows.Forms;
using G1ANT.Addon.MicrosoftTeamsAndroid;
using G1ANT.Language;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.MicrosoftTeamsAndroid
{
    [Command(Name = "microsoftteamsandroid.viewmeetings", Tooltip = "This command will help a person view scheduled meetings on teams ")]
    public class MicrosoftTeamsAndroidViewMeetingsCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

           
        }

        public MicrosoftTeamsAndroidViewMeetingsCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "//android.view.ViewGroup[@content-desc='Calendar tab, 5 of 6']/android.widget.TextView";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
        }
    }
}
