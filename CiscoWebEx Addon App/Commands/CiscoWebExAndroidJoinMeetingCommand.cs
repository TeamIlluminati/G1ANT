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
    [Command(Name = "ciscowebexandroid.joinmeetings", Tooltip = "Join a meeting with CiscoWebEx")]
    public class CiscoWebExJoinMeetingCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capability")]
            public TextStructure Search { get; set; } = new TextStructure(String.Empty);
            [Argument(Required = false, Tooltip = "Provide Element ID")]
            public TextStructure By { get; set; } = new TextStructure(String.Empty);
            [Argument(Required = true, Tooltip = "Provide a Meeting number, URL, or username to join")]
            public TextStructure id { get; set; } = new TextStructure("");
           
            

        }
        public CiscoWebExJoinMeetingCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "//android.widget.Button[@content-desc='Join meeting']";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "com.cisco.webex.meetings:id / et_connecting_meeting_num";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).SendKeys(arguments.id.Value);

            arguments.Search.Value = "com.cisco.webex.meetings:id / menu_join";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
                        
        }
    }
}