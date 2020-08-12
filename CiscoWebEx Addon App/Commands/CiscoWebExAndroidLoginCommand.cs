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
    [Command(Name = "ciscowebexandroid.login", Tooltip = "Log into CiscoWebEx with the correct user credentials")]
    public class CiscoWebExAndroidLoginCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capability")]
            public TextStructure Search { get; set; } = new TextStructure(String.Empty);
            [Argument(Required = false, Tooltip = "Provide Element ID")]
            public TextStructure By { get; set; } = new TextStructure(String.Empty);
            [Argument(Required = true, Tooltip = "Provide User Email ID")]
            public TextStructure email { get; set; } = new TextStructure("");
            [Argument(Required = true, Tooltip = "Provide Password")]
            public TextStructure pass { get; set; } = new TextStructure("");

        }
        public CiscoWebExAndroidLoginCommand(AbstractScripter scripter): base(scripter)
        {

        }
        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "com.cisco.webex.meetings:id / btn_welcome_sign_in";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "com.cisco.webex.meetings:id / et_email_address";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).SendKeys(arguments.email.Value);

            arguments.Search.Value = "//android.widget.TextView[@content-desc='Next button']";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "com.cisco.webex.meetings:id / tv_site_url";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            arguments.Search.Value = "com.cisco.webex.meetings:id / et_password";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).SendKeys(arguments.pass.Value);

            arguments.Search.Value = "//android.widget.TextView[@content-desc='Next button']";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

           

        }
    }
}