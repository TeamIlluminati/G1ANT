using G1ANT.Language;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.TwitterAndroid
{
    [Command(Name = "twitterandroid.posttweet", Tooltip = "This command will help user post tweets on Twitter")]
    public class TwitterAndroidPostTweetCommand : Language.Command 
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = true, Tooltip = "Type the content to tweet")]
            public TextStructure tweet { get; set; } = new TextStructure("");
        }

        public TwitterAndroidPostTweetCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {

            arguments.Search.Value = "//android.widget.FrameLayout[@content-desc='Edit Tweet 1 of 1']/android.widget.FrameLayout/android.widget.LinearLayout[1]";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.tweet.Value);

            arguments.Search.Value = "com.twitter.android:id/button_tweet";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();



        }
    }
}