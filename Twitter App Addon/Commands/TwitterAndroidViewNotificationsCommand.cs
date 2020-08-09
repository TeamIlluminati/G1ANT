using System;
using System.Diagnostics;
using System.Windows.Forms;
using G1ANT.Addon.TwitterAndroid;
using G1ANT.Language;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.TwitterAndroid
{
    [Command(Name = "twitterandroid.viewnoti", Tooltip = "This command will help view all the notifications in the app")]
    public class TwitterAndroidViewNotificationsCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

        }

        public TwitterAndroidViewNotificationsCommand(AbstractScripter scripter) : base(scripter) 
        {

        }

        public void Execute(Arguments arguments)
        {

            arguments.Search.Value = "//androidx.appcompat.app.a.c[@content-desc='Notifications Tab. 1 new items']/android.view.View";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
        }
    }
}