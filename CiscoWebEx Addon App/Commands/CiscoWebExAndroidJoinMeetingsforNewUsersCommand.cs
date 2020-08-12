using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using G1ANT.Language;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.CiscoWebExAndroid
{
    [Command(Name = "ciscowebexandroid.joinmeetingfornewusers", Tooltip = "Join a WebEx Meeting for a new user")]
    public class CiscoWebExAndroidJoinMeetingsforNewUsersCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capability")]
            public TextStructure Search { get; set; } = new TextStructure(String.Empty);
            [Argument(Required = false, Tooltip = "Provide Element ID")]
            public TextStructure By { get; set; } = new TextStructure(String.Empty);
            [Argument(Required = true, Tooltip = "Provide Meeting ID or URL")]
            public TextStructure id { get; set; } = new TextStructure("");
            [Argument(Required = true, Tooltip = "Provide your name")]
            public TextStructure name { get; set; } = new TextStructure("");
            [Argument(Required = true, Tooltip = "Provide your email")]
            public TextStructure email { get; set; } = new TextStructure("");

        }
        public CiscoWebExAndroidJoinMeetingsforNewUsersCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public void Execute(Arguments arguments)
        {
            
            arguments.Search.Value = "com.cisco.webex.meetings:id / btn_welcome_join_meeting";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "com.cisco.webex.meetings:id / btn_welcome_join_meeting";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).SendKeys(arguments.id.Value);

            arguments.Search.Value = "com.cisco.webex.meetings:id / et_joinmeeting_displayname";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).SendKeys(arguments.name.Value);

            arguments.Search.Value = "com.cisco.webex.meetings:id / et_joinmeeting_emailaddress";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).SendKeys(arguments.email.Value);

            arguments.Search.Value = "//android.widget.TextView[@content-desc='Join Button']";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

        }
    }
}
