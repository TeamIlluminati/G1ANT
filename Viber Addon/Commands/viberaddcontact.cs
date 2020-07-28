using System;
using G1ANT.Language;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.viber
{
    [Command(Name = "viber.addcontact", Tooltip = "This command adds a contact")]
    public class AddCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure("");

            [Argument(Required = true, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure("");
            [Argument(Required = true, Tooltip = "Write number of the contact to be added")]
            public TextStructure number { get; set; } = new TextStructure("");
            [Argument(Required = true, Tooltip = "Write name of your contact")]
            public TextStructure name { get; set; } = new TextStructure("");
        }

        public AddCommand(AbstractScripter scripter) : base(scripter)
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
                arguments.Search.Value = "com.viber.voip:id / menu_add_contact";
                arguments.By.Value = "id";
                ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
                arguments.Search.Value = "/ hierarchy / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.FrameLayout / android.view.ViewGroup / android.widget.FrameLayout[2] / android.widget.ScrollView / android.widget.RelativeLayout / android.widget.EditText";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.number.Value);
                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.ScrollView/android.widget.RelativeLayout/android.widget.Button[1]";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.ScrollView/android.widget.LinearLayout/android.widget.LinearLayout/android.widget.RelativeLayout[1]/android.widget.EditText";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.name.Value);
                arguments.Search.Value = "com.viber.voip:id / menu_done";
                arguments.By.Value = "id";
                ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            }
        }
    }
}
