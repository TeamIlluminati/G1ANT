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
    [Command(Name = "ciscowebexandroid.searchrecordings", Tooltip = "Search your recordings in CiscoWebEx")]
    public class CiscoWebExSearchRecordingsCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capability")]
            public TextStructure Search { get; set; } = new TextStructure(String.Empty);
            [Argument(Required = false, Tooltip = "Provide Element ID")]
            public TextStructure By { get; set; } = new TextStructure(String.Empty);
            [Argument(Required = true, Tooltip = "Provide the title for your recording")]
            public TextStructure title { get; set; } = new TextStructure("");

        }
        public CiscoWebExSearchRecordingsCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public void Execute(Arguments arguments)
        {
            
            arguments.Search.Value = "com.cisco.webex.meetings:id / btnRecording";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "com.cisco.webex.meetings:id / search_button";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "com.cisco.webex.meetings:id / search_src_text";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).SendKeys(arguments.title.Value);






        }
    }
}