using System.Windows.Forms;
using G1ANT.Addon.MicrosoftTeamsAndroid;
using G1ANT.Language;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.MicrosoftTeamsAndroid
{
    [Command(Name = "microsoftteamsandroid.chat", Tooltip = "This command will help a person chat with another person in teams ")]
    public class MicrosoftTeamsAndroidChatCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = true, Tooltip = "Enter the name of the person")]
            public TextStructure name { get; set; } = new TextStructure("");

            [Argument(Required = true, Tooltip = "Enter your message")]
            public TextStructure msg { get; set; } = new TextStructure("");

        }

        public MicrosoftTeamsAndroidChatCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "//android.view.ViewGroup[@content-desc='Chat tab,2 of 6, not selected']/android.widget.TextView";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
                        
            arguments.Search.Value = "com.microsoft.teams:id / search_contact_box";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).SendKeys(arguments.name.Value);

            arguments.Search.Value = "com.microsoft.teams:id / search_contact_box";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).SendKeys(arguments.msg.Value);

            arguments.Search.Value = "//android.widget.ImageView[@content-desc='Send message']";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

            
        }
    }
}

