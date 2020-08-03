using System;
using System.Diagnostics;
using System.Windows.Forms;
using G1ANT.Addon.InstagramApp;
using G1ANT.Language;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.InstagramApp
{
    [Command(Name = "instagramapp.profile", Tooltip = "This command opens your profile settings")]
    public class ViewprofileCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);
        }
        	
        public ViewprofileCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "com.instagram.android:id/profile_tab";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();

        }
    }
    }


