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
    [Command(Name = "microsoftteamsandroid.createteam", Tooltip = "This command will help a person create their own teams on teams")]
    public class MicrosoftTeamsAndroidCreateTeamCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = true, Tooltip = "Provide the name of the group")]
            public TextStructure name { get; set; } = new TextStructure("");

            [Argument(Required = true, Tooltip = "Provide the description of the group")]
            public TextStructure msg { get; set; } = new TextStructure("");

        }

        public MicrosoftTeamsAndroidCreateTeamCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "com.microsoft.teams:id / action_bar_browse_teams";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "com.microsoft.teams:id / action_bar_browse_teams";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "/ hierarchy / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.view.ViewGroup / android.widget.FrameLayout / androidx.recyclerview.widget.RecyclerView / android.widget.FrameLayout[2] / android.widget.Button";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "com.microsoft.teams:id / teamNameInput";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).SendKeys(arguments.name.Value);

            arguments.Search.Value = "com.microsoft.teams:id / teamDescriptionInput";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).SendKeys(arguments.msg.Value);

            arguments.Search.Value = "//android.widget.TextView[@content-desc='Save']";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
        }

    }
}
