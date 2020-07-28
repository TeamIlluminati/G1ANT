using System;
using G1ANT.Language;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.viber
{
    [Command(Name = "viber.call", Tooltip = "This command calls the searched friend")]
    public class CallCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure("");

            [Argument(Required = true, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; }
            [Argument(Required = true, Tooltip = "Write full name of your friend")]
            public TextStructure search { get; set; } = new TextStructure("");

        }

        public CallCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "/ hierarchy / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.widget.FrameLayout / android.view.ViewGroup / android.widget.LinearLayout / android.view.ViewGroup[2] / android.widget.ImageView";
            arguments.By.Value = "xpath";
            var by = arguments.By.Value.ToLower();


            if (by == "xy")
            {
                TouchAction clickAction = new TouchAction(OpenCommand.GetDriver());
                var coordinates = arguments.Search.Value.Split(',');
                clickAction.Tap(int.Parse(coordinates[0]), int.Parse(coordinates[1])).Perform();
            }
            else
            {
                ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
                arguments.Search.Value = "com.viber.voip:id/menu_search";
                arguments.By.Value = "id";
                ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.widget.LinearLayout/android.view.ViewGroup/androidx.appcompat.widget.LinearLayoutCompat/android.widget.LinearLayout/android.widget.LinearLayout/android.widget.LinearLayout/android.widget.EditText";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.search.Value);
                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.widget.FrameLayout/android.widget.RelativeLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.ListView/android.widget.RelativeLayout/android.widget.RelativeLayout/android.widget.ImageButton";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            }
        }
    }
}
