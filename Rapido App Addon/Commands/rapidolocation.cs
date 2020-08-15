using System;
using G1ANT.Language;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.rapido
{
    [Command(Name = "rapido.location", Tooltip = "This command searches the location")]
    public class ClickCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure("");

            [Argument(Required = true, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure("");
            [Argument(Required = true, Tooltip = "Provide name to be searched")]
            public TextStructure search { get; set; } = new TextStructure("");
        }

        public ClickCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "com.rapido.passenger:id / dropText";
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
                ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
                ElementHelper.GetElement(arguments.By.Value, arguments.search.Value).SendKeys(arguments.search.Value);
                arguments.Search.Value = "/ hierarchy / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.FrameLayout / android.view.ViewGroup / android.widget.RelativeLayout / android.widget.ScrollView / android.widget.LinearLayout / androidx.recyclerview.widget.RecyclerView / android.view.ViewGroup[1] / android.view.ViewGroup / android.widget.TextView[1]";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            }
        }
    }
}
