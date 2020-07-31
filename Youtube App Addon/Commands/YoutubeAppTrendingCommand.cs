using System;
using G1ANT.Language;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.YoutubeApp
{
    [Command(Name = "youtubeapp.explore", Tooltip = "This command opens explore section in Youtube app")]
    public class YoutubeAppTrendingCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Provide name of the selector")]
            public TextStructure Search { get; set; } = new TextStructure("Explore");

            [Argument(Required = true, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure("AccessibilityId");
        }

        public YoutubeAppTrendingCommand(AbstractScripter scripter) : base(scripter)
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
        }
    }
}
