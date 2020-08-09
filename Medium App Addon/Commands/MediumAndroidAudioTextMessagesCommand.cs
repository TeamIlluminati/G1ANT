using System;
using System.Diagnostics;
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
    [Command(Name = "mediumandroid.audio", Tooltip = "This command will help view all audio t on Medium")]
    public class MediumAndroidAudioTextMessagesCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

        }

        public MediumAndroidAudioTextMessagesCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {

            arguments.Search.Value = "//android.widget.ImageButton[@content-desc='Open navigation drawer']";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "/ hierarchy / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.widget.FrameLayout / androidx.drawerlayout.widget.DrawerLayout / android.view.ViewGroup / android.widget.RelativeLayout / android.view.ViewGroup / android.widget.ViewFlipper / androidx.recyclerview.widget.RecyclerView / android.view.ViewGroup / androidx.recyclerview.widget.RecyclerView / android.view.ViewGroup[2] / android.view.ViewGroup / android.widget.TextView[1]";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

        }
    }
}