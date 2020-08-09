using System;
using System.Diagnostics;
using System.Windows.Forms;
using G1ANT.Addon.LineAndroid;
using G1ANT.Language;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.LineAndroid
{
    [Command(Name = "lineandroid.viewnoti", Tooltip = "View Notifications on LINE Android")]
    public class LineAndroidViewNotificationsCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

        }
        public LineAndroidViewNotificationsCommand(AbstractScripter scripter): base(scripter)
        {

        }
        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "(//android.view.ViewGroup[@content-desc='@{bottomNavigationBarButtonViewModel.contentDescription'])[3]/android.view.View";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "jp.naver.line.android:id / header_button_img";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
        }
    }
}
