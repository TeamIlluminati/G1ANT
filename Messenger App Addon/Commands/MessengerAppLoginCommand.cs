using System;
using System.Diagnostics;
using System.Windows.Forms;
using G1ANT.Addon.MessengerApp;
using G1ANT.Language;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.MessengerApp
{
    [Command(Name = "messengerapp.login", Tooltip = "This command will login you on Messenger App")]
    public class MessengerAppLoginCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = true, Tooltip = "Type email id")]
            public TextStructure email { get; set; } = new TextStructure("");
            [Argument(Required = true, Tooltip = "Type password")]
            public TextStructure pword { get; set; } = new TextStructure("");
        }

        public MessengerAppLoginCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {
            
            arguments.Search.Value = "//android.widget.EditText[@content-desc='Phone Number or Email']";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.email.Value);

            arguments.Search.Value = "//android.widget.EditText[@content-desc='Password']";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.pword.Value);

            arguments.Search.Value = "//android.view.ViewGroup[@content-desc='LOG IN']";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

        }
    }
}