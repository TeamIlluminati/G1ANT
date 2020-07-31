using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using G1ANT.Language;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.FacebookApp
{
    [Command(Name = "fbandroid.post", Tooltip = "This command takes content of post from user using argument and post it in fb app")]
    public class FBandroidWritePostCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

            [Argument(Name = "Post", Required = true, Tooltip = "Enter the message or story to be posted.")]
            public TextStructure post { get; set; } = new TextStructure(string.Empty);
        }

        public FBandroidWritePostCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        // Implement this method
        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "//android.view.View[@content-desc='News Feed, Tab 1 of 6']";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
            arguments.Search.Value = "//android.view.ViewGroup[@content-desc='Make a post on Facebook']";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
            arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout[1]/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.ScrollView/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.EditText";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.post.Value);
            arguments.Search.Value = "//android.widget.Button[@content-desc='POST']";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();

        }
    }
}