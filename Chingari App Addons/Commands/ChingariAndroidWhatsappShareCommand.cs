using G1ANT.Addon.ChingariAndroid;
using G1ANT.Language;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.ChingariAndroid
{
    [Command(Name = "chingariandroid.whatsappshare", Tooltip = "This command will allow you to share posts to whatsapp through Chingari")]
    public class ChingariAndroidWhatsappShareCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

        }

        public ChingariAndroidWhatsappShareCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {
            RobotMessageBox.Show("Share through whatsapp ");
            arguments.Search.Value = "io.chingari.app:id / whatsapp_share";
            arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();

           

            RobotMessageBox.Show("Send to the person you want to send");
        }
    }
}
