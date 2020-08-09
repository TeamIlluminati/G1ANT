using System;
using System.Diagnostics;
using System.Windows.Forms;
using G1ANT.Addon.MediumAndroid;
using G1ANT.Language;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.MediumAndroid
{
    [Command(Name = "mediumandroid.stories", Tooltip = "This command will help post your articles on Medium for the viewers")]
    public class MediumAndroidStoriesCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = true, Tooltip = "Enter the article to be posted on Medium")]
            public TextStructure story { get; set; } = new TextStructure("");

        }

        public MediumAndroidStoriesCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {

            arguments.Search.Value = "//android.widget.ImageButton[@content-desc='Open navigation drawer']";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            
            arguments.Search.Value = "com.medium.reader:id/edit_post_paragraph_list";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).SendKeys(arguments.story.Value);

            arguments.Search.Value = "com.medium.reader:id / edit_post_publish_button";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
        }
    }
}