using System;
using System.Diagnostics;
using System.Windows.Forms;
using G1ANT.Language;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.MultiTouch;

namespace G1ANT.Addon.FacebookApp
{
    [Command(Name = "fbapp.open", Tooltip = "This command open facebook app in the android device.")]

    public class OpenCommand : Language.Command
    {
        private static AndroidDriver<AndroidElement> driver;
        public class Arguments : CommandArguments
        {
            [Argument(DefaultVariable = "AppActivity", Tooltip = "AppActivity")]
            public TextStructure AppActivity { get; set; } = new TextStructure("com.facebook.katana.platform.FacebookAuthenticationActivity");

            [Argument(DefaultVariable = "AppPackage", Tooltip = "App Package")]
            public TextStructure AppPackage { get; set; } = new TextStructure("com.facebook.katana");

            [Argument(Required = false, Tooltip = "Automation Name")]
            public TextStructure AutomationName { get; set; } = new TextStructure("UiAutomator2");

            [Argument(Required = false, Tooltip = "Device Name")]
            public TextStructure DeviceName { get; set; } = new TextStructure("Android");

            [Argument(Required = false, Tooltip = "Platform Name")]
            public TextStructure PlatformName { get; set; } = new TextStructure("Android");

            [Argument(Required = false, Tooltip = "Platform version")]
            public TextStructure PlatformVersion { get; set; } = new TextStructure("");

            [Argument(Name = "email", Required = true, Tooltip = "Enter your email-id")]
            public TextStructure email { get; set; }

            [Argument(Name = "password", Required = true, Tooltip = "Enter your password")]
            public TextStructure pword { get; set; }

            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);
        }

        public OpenCommand(AbstractScripter scripter) : base(scripter)
        {
        }

        // Implement this method
        public void Execute(Arguments arguments)
        {
            Initialize(arguments);

            arguments.Search.Value = "//android.widget.EditText[@content-desc='Username']";
            arguments.By.Value = "xpath";

            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.email.Value);

            arguments.Search.Value = "//android.widget.EditText[@content-desc='Password']";
            arguments.By.Value = "xpath";

            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.pword.Value);

            arguments.Search.Value = "//android.view.ViewGroup[@content-desc='Log In']";
            arguments.By.Value = "xpath";

            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
        }

        private AppiumOptions CreateAppiumOptions(Arguments arguments)
        {
            var desiredCapabilities = new AppiumOptions();
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, arguments.DeviceName.Value);
            desiredCapabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, arguments.AppPackage.Value);
            desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, arguments.PlatformName.Value);
            desiredCapabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, arguments.AppActivity.Value);
            if (!string.IsNullOrEmpty(arguments.PlatformVersion.Value))
            {
                desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, arguments.PlatformVersion.Value);
            }
            return desiredCapabilities;
        }
        private void Initialize(Arguments arguments)
        {
            try
            {
                var appiumServiceBuilder = new AppiumServiceBuilder().UsingAnyFreePort();
                var appiumOptions = CreateAppiumOptions(arguments);
                driver = new AndroidDriver<AndroidElement>(appiumServiceBuilder, appiumOptions);
            }
            catch (Exception ex)
            {
                InstallAppiumWhenExceptionOccured(ex);
            }
        }
        private void InstallAppiumWhenExceptionOccured(Exception ex)
        {
            if (ex.Message.StartsWith("Invalid"))
            {
                var result = RobotMessageBox.Show("It seems you have no Appium driver installed. Would you like to install it now?", "Error", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Process.Start("\"C:\\Program Files\\nodejs\\npm.cmd\"", "install -g appium");
                }
            }
            else { throw ex; }
        }

        public static AndroidDriver<AndroidElement> GetDriver()
        {
            return driver;
        }


    }
}