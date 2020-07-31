using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using G1ANT.Language;
using System.Threading;
using OpenQA.Selenium.Remote;



namespace G1ANT.Addon.NaukriApp
{
    [Command(Name = "naukriapp.login", Tooltip = "This command logins the user into Naukri app")]
    public class NaukriAppLoginCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

            [Argument(Name = "Email", Required = true, Tooltip = "Enter your email-id to login")]
            public TextStructure email { get; set; } = new TextStructure(string.Empty);
            [Argument(Name = "Password", Required = true, Tooltip = "Enter your password to login")]
            public TextStructure pword { get; set; } = new TextStructure(string.Empty);
            [Argument(Name = "Tab", Required = true, Tooltip = "Do you want to save password-Never or Save")]
            public TextStructure tab { get; set; } = new TextStructure(string.Empty);

        }

        public NaukriAppLoginCommand(AbstractScripter scripter) :
            base(scripter)
        {

        }

        // Implement this method
        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.widget.RelativeLayout/android.widget.LinearLayout[2]/android.widget.RelativeLayout/android.widget.Button[2]";
            arguments.By.Value = "xpath";

            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
            Thread.Sleep(5000);

            arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.LinearLayout[2]/android.widget.RelativeLayout/android.widget.ScrollView/android.widget.LinearLayout/android.widget.LinearLayout[1]/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.EditText";
            arguments.By.Value = "xpath";

            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.email.Value);


            arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.LinearLayout[2]/android.widget.RelativeLayout/android.widget.ScrollView/android.widget.LinearLayout/android.widget.LinearLayout[1]/android.widget.RelativeLayout[1]/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.EditText";
            arguments.By.Value = "xpath";

            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.pword.Value);

            arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.LinearLayout[2]/android.widget.RelativeLayout/android.widget.ScrollView/android.widget.LinearLayout/android.widget.LinearLayout[1]/android.widget.Button";
            arguments.By.Value = "xpath";

            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
            if(arguments.tab.Value=="Never")
            {
                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.LinearLayout[2]/android.widget.Button[1]";
                arguments.By.Value = "xpath";

                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
            }
            if(arguments.tab.Value=="Save")
            {
                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.LinearLayout[2]/android.widget.Button[2]";
                arguments.By.Value = "xpath";

                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();

            }
        }
    }
}