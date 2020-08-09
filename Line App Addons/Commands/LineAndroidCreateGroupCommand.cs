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
    [Command(Name = "lineandroid.creategroup", Tooltip = "This command will help user create groups on LINE Android")]
    public class LineAndroidCreateGroupCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = true, Tooltip = "Enter your group name")]
            public TextStructure gname { get; set; } = new TextStructure("");

            [Argument(Required = true, Tooltip = "Enter the name of the person you are adding to the group")]
            public TextStructure name { get; set; } = new TextStructure(""); 




        }

        public LineAndroidCreateGroupCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {

            arguments.Search.Value = "//android.view.ViewGroup[@content-desc='@{bottomNavigationBarButtonViewModel.contentDescription'])[1]/android.view.View";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "/ hierarchy / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.RelativeLayout / androidx.viewpager.widget.ViewPager / android.widget.RelativeLayout / android.view.ViewGroup / android.widget.LinearLayout[2] / androidx.recyclerview.widget.RecyclerView / android.widget.LinearLayout[2] / android.widget.LinearLayout";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "jp.naver.line.android:id/searchbar_input_text";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).SendKeys(arguments.name.Value);

            arguments.Search.Value = "jp.naver.line.android:id / header_button_text";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "jp.naver.line.android:id / groupform_name";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).SendKeys(arguments.gname.Value);

            arguments.Search.Value = "/ hierarchy / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.LinearLayout / android.widget.LinearLayout[1] / android.widget.LinearLayout / android.widget.LinearLayout[3] / android.widget.FrameLayout / android.widget.TextView";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            
        }
    }
}