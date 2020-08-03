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
    [Command(Name = "pinterestapp.follow", Tooltip = "This command will follow pins on Pinterest App")]
    public class PinterestAppFollowCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);
        }

        public PinterestAppFollowCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.widget.LinearLayout/android.widget.LinearLayout/android.widget.HorizontalScrollView/android.widget.LinearLayout/androidx.appcompat.app.ActionBar.b[3]";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();


        }
    }
}

