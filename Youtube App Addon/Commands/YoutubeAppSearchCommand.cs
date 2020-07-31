using System;
using G1ANT.Language;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.YoutubeApp
{
    [Command(Name = "youtubeapp.search", Tooltip = "This command opens search page on Youtube")]
    public class YoutubeAppSearchCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Provide name of the selector")]
            public TextStructure Search { get; set; } = new TextStructure("Search");

            [Argument(Required = true, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure("AccessibilityId");

            [Argument(Required = true, Tooltip = "Provide the search element")]
            public TextStructure keyword { get; set; } = new TextStructure("");
            [Argument(Required = false, Tooltip = "Provide the search element")]
            public TextStructure message { get; set; } = new TextStructure("Please type <<<ENTER>>> Command after search command to see the results of your search, if you already typed it ignore this messsage - Thank you");
        }

        public YoutubeAppSearchCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {

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
            }
            arguments.Search.Value = "com.google.android.youtube:id/search_edit_text";
            arguments.By.Value = "Id";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.keyword.Value);
            RobotMessageBox.Show(arguments.message.Value);
        }
    }
}