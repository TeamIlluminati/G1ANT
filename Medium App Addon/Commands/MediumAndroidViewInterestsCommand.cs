﻿using System.Diagnostics;
using System.Windows.Forms;
using G1ANT.Addon.MediumAndroid;
using G1ANT.Language;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.MediumAndroid
{
    [Command(Name = "mediumandroid.viewinterests", Tooltip = "This command search in Medium")]
    public class MediumAndroidViewInterestsCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

            

        }

        public MediumAndroidViewInterestsCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {

            arguments.Search.Value = "//android.widget.ImageButton[@content-desc='Open navigation drawer']";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();


            arguments.Search.Value = "com.medium.reader:id / todays_highlights_post_preview_options_menu";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            


        }
    }
}