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
    [Command(Name = "pinterestapp.search", Tooltip = "This command will search pins on Pinterest App")]
    public class PinterestAppSearchCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);
        }

        public PinterestAppSearchCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "com.pinterest:id/menu_search";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();


        }
    }
}

