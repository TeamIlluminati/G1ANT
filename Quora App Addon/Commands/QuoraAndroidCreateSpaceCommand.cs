using System;
using System.Diagnostics;
using System.Windows.Forms;
using G1ANT.Addon.QuoraAndroid;
using G1ANT.Language;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.QuoraAndroid
{
    [Command(Name = "quoraandroid.createspace", Tooltip = "This command will help create a space for you in Quora")]
    public class QuoraAndroidCreateSpaceCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);
            [Argument(Required = true, Tooltip = "Create a name for your space")]
            public TextStructure name { get; set; } = new TextStructure("");
            [Argument(Required = true, Tooltip = "Write a one line about your space")]
            public TextStructure space { get; set; } = new TextStructure("");


        }

        public QuoraAndroidCreateSpaceCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {

            arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout[2]/android.widget.RelativeLayout/android.widget.RelativeLayout/android.widget.LinearLayout/android.widget.HorizontalScrollView/android.widget.LinearLayout/androidx.appcompat.app.ActionBar.Tab[3]/android.widget.RelativeLayout/android.widget.RelativeLayout/android.widget.ImageView";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "/ hierarchy / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.widget.FrameLayout[2] / android.widget.RelativeLayout / android.widget.RelativeLayout / android.widget.LinearLayout / android.widget.RelativeLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.widget.LinearLayout / androidx.viewpager.widget.ViewPager / android.widget.RelativeLayout / android.widget.RelativeLayout / android.widget.LinearLayout / android.view.ViewGroup / android.webkit.WebView / android.webkit.WebView / android.view.View / android.view.View / android.view.View / android.view.View / android.widget.Button[1]";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "/ hierarchy / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.widget.FrameLayout[2] / android.widget.RelativeLayout / android.widget.RelativeLayout / android.widget.LinearLayout / android.widget.RelativeLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.widget.LinearLayout / androidx.viewpager.widget.ViewPager / android.widget.RelativeLayout / android.widget.RelativeLayout / android.widget.LinearLayout / android.view.ViewGroup / android.webkit.WebView / android.webkit.WebView / android.view.View / android.view.View / android.view.View / android.view.View / android.view.View[4]";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.name.Value);

            arguments.Search.Value = "/ hierarchy / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.widget.FrameLayout[2] / android.widget.RelativeLayout / android.widget.RelativeLayout / android.widget.LinearLayout / android.widget.RelativeLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.widget.LinearLayout / androidx.viewpager.widget.ViewPager / android.widget.RelativeLayout / android.widget.RelativeLayout / android.widget.LinearLayout / android.view.ViewGroup / android.webkit.WebView / android.webkit.WebView / android.view.View / android.view.View / android.view.View / android.view.View / android.view.View[4]";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.space.Value);

            arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout[2]/android.widget.RelativeLayout/android.widget.RelativeLayout/android.widget.LinearLayout/android.widget.RelativeLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.LinearLayout/androidx.viewpager.widget.ViewPager/android.widget.RelativeLayout/android.widget.RelativeLayout/android.widget.LinearLayout/android.view.ViewGroup/android.webkit.WebView/android.webkit.WebView/android.view.View/android.view.View/android.view.View/android.view.View";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

        }
    }
}
