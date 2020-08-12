using System;
using System.Diagnostics;
using System.Windows.Forms;
using G1ANT.Language;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.CiscoWebExAndroid
{
    [Command(Name = "ciscowebexandroid.schedulemeetings", Tooltip = "Schedule a meeting with CiscoWebEx")]
    public class CiscoWebExScheduleMeetingCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capability")]
            public TextStructure Search { get; set; } = new TextStructure(String.Empty);
            [Argument(Required = false, Tooltip = "Provide Element ID")]
            public TextStructure By { get; set; } = new TextStructure(String.Empty);
            [Argument(Required = true, Tooltip = "Provide Email of members for the meeting")]
            public TextStructure email { get; set; } = new TextStructure("");
            [Argument(Required = true, Tooltip = "Enter time in hours ( 24 hour format)")]
            public TextStructure hrs { get; set; } = new TextStructure("");
            [Argument(Required = true, Tooltip = "Enter time in minutes")]
            public TextStructure mins { get; set; } = new TextStructure(""); 



        }
        public CiscoWebExScheduleMeetingCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "com.cisco.webex.meetings:id / action_schedule";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "com.cisco.webex.meetings:id / actv_email_address";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).SendKeys(arguments.email.Value);

           arguments.Search.Value = "com.cisco.webex.meetings:id / schedule_start_time";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "android:id/toggle_mode";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "android: id / input_hour";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).SendKeys(arguments.hrs.Value);

            arguments.Search.Value = "android: id / input_minute";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).SendKeys(arguments.mins.Value);

            arguments.Search.Value = "com.cisco.webex.meetings:id/button1";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "//android.widget.TextView[@content-desc='Start meeting button']";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
              
        }
    }
}