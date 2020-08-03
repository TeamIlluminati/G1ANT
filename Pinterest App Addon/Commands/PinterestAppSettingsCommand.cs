using System.Windows.Forms;
using G1ANT.Addon.PinterestApp;
using G1ANT.Language;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.PinterestApp
{
    [Command(Name = "pinterestapp.settings", Tooltip = "This command will open settings on Pinterest App")]
    public class PinterestAppSettingsCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);
        }

        public PinterestAppSettingsCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "//android.widget.FrameLayout[@content-desc='Saved']";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();

            arguments.Search.Value = "//android.widget.ImageView[@content-desc='Settings']";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();

        }
    }
}

