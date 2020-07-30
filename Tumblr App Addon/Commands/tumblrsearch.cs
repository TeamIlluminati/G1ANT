using System;
using G1ANT.Language;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.tumblr
{
    [Command(Name = "tumblr.search", Tooltip = "This command searches the text you have typed")]
    public class searchCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure("");

            [Argument(Required = true, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure("");
            [Argument(Required = true, Tooltip = "Type the text you want to search")]
            public TextStructure search { get; set; } = new TextStructure("");
        }

        public searchCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "com.tumblr:id / topnav_explore_button_img_active";
            arguments.By.Value = "id";
            var by = arguments.By.Value.ToLower();

            if(by == "xy")
            {
                TouchAction clickAction = new TouchAction(OpenCommand.GetDriver());
                var coordinates = arguments.Search.Value.Split(',');
                clickAction.Tap(int.Parse(coordinates[0]), int.Parse(coordinates[1])).Perform();
            }
            else
            {
                ElementHelper.GetElement(by, arguments.Search.Value).Click();
                arguments.Search.Value = "/ hierarchy / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.FrameLayout / android.view.ViewGroup / androidx.viewpager.widget.ViewPager / android.view.ViewGroup / android.widget.FrameLayout / android.widget.RelativeLayout / android.widget.FrameLayout / android.widget.TextView";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.search.Value);
            }
        }
    }
}
