using System;
using System.Threading;
using G1ANT.Language;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Remote;


namespace G1ANT.Addon.YoutubeApp
{
    [Command(Name = "youtubeapp.history", Tooltip = "This command opens user's history in Youtube app")]
    public class YoutubeAppHistoryCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Provide name of the selector")]
            public TextStructure Search { get; set; } = new TextStructure("Library");

            [Argument(Required = true, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure("AccessibilityId");
        }

        public YoutubeAppHistoryCommand(AbstractScripter scripter) : base(scripter)
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
            Thread.Sleep(3000);
            arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.FrameLayout/android.view.ViewGroup[2]/android.support.v7.widget.RecyclerView/android.widget.LinearLayout[1]";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();

        }
    }
}