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
    [Command(Name = "ciscowebexandroid.viewrecordings", Tooltip = "View your recordings in CiscoWebEx")]
    public class CiscoWebExViewRecordingsCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capability")]
            public TextStructure Search { get; set; } = new TextStructure(String.Empty);
            [Argument(Required = false, Tooltip = "Provide Element ID")]
            public TextStructure By { get; set; } = new TextStructure(String.Empty);

        }
        public CiscoWebExViewRecordingsCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public void Execute(Arguments arguments)
        {
            RobotMessageBox.Show("This views all your recordings!");
            arguments.Search.Value = "com.cisco.webex.meetings:id / btnRecording";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            Thread.Sleep(3000);
            RobotMessageBox.Show("View Past Recordings");
            arguments.Search.Value = "com.cisco.webex.meetings:id / btnPast";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();



        }
    }
}