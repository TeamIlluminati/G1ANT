using System;
using G1ANT.Language;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.tumblr
{
    [Command(Name = "tumblr.settings", Tooltip = "This command opens settings of your tumblr profile")]
    public class settingsCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure("");

            [Argument(Required = true, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure("");

        }

        public settingsCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "com.tumblr:id/topnav_account_button_img_active";
            arguments.By.Value = "id";
            var by = arguments.By.Value.ToLower();

            if (by == "xy")
            {
                TouchAction clickAction = new TouchAction(OpenCommand.GetDriver());
                var coordinates = arguments.Search.Value.Split(',');
                clickAction.Tap(int.Parse(coordinates[0]), int.Parse(coordinates[1])).Perform();
            }
            else
            {
                ElementHelper.GetElement(by, arguments.Search.Value).Click();
                arguments.Search.Value = "com.tumblr:id / action_blog_options";
                arguments.By.Value = "id";
                ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();


            }
        }
    }
}