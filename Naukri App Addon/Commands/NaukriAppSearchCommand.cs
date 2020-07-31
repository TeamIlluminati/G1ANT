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
    [Command(Name = "naukriapp.search", Tooltip = "This command searches job in a particular location in Naukri App")]
    public class NaukriAppSearchCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

            [Argument(Name = "job", Required = true, Tooltip = "Enter name of job you want to searcxh")]
            public TextStructure job { get; set; } = new TextStructure(string.Empty);
            [Argument(Name = "Location", Required = true, Tooltip = "Enter location where you want")]
            public TextStructure location { get; set; } = new TextStructure(string.Empty);

            [Argument(Name = "login", Required = true, Tooltip = "Enter whether you are logged in or not- Yes or No")]
            public TextStructure login { get; set; } = new TextStructure(string.Empty);
        }

        public NaukriAppSearchCommand(AbstractScripter scripter) :
            base(scripter)
        {

        }

        // Implement this method
        public void Execute(Arguments arguments)
        {
            if (arguments.login.Value == "No")
            {
                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.widget.RelativeLayout/android.widget.LinearLayout[2]/android.widget.EditText";
                arguments.By.Value = "xpath";

                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
                Thread.Sleep(5000);

                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/androidx.drawerlayout.widget.DrawerLayout/android.view.ViewGroup/android.widget.LinearLayout/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.ScrollView/android.view.ViewGroup/android.widget.LinearLayout[1]/android.widget.FrameLayout/android.widget.EditText";
                arguments.By.Value = "xpath";

                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.job.Value);
                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/androidx.drawerlayout.widget.DrawerLayout/android.view.ViewGroup/android.widget.LinearLayout/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.ScrollView/android.view.ViewGroup/android.widget.TextView";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();



                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/androidx.drawerlayout.widget.DrawerLayout/android.view.ViewGroup/android.widget.LinearLayout/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.ScrollView/android.view.ViewGroup/android.widget.LinearLayout[2]/android.widget.FrameLayout/android.widget.EditText";
                arguments.By.Value = "xpath";

                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.location.Value);

                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/androidx.drawerlayout.widget.DrawerLayout/android.view.ViewGroup/android.widget.LinearLayout/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.ScrollView/android.view.ViewGroup/android.widget.Button";
                arguments.By.Value = "xpath";

                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
            }
            if(arguments.login.Value=="Yes")
            {
                arguments.Search.Value= "//android.widget.ImageButton[@content-desc='Navigate up']";
                arguments.By.Value = "xpath";

                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/androidx.drawerlayout.widget.DrawerLayout/android.view.ViewGroup[2]/android.widget.FrameLayout/android.widget.ScrollView/android.widget.LinearLayout/android.widget.LinearLayout/android.widget.RelativeLayout[1]/android.widget.LinearLayout[1]/android.widget.TextView";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.LinearLayout[2]/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.ScrollView/android.view.ViewGroup/android.widget.LinearLayout[1]/android.widget.FrameLayout/android.widget.EditText";
                arguments.By.Value = "xpath";

                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.job.Value);
                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.LinearLayout[2]/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.ScrollView/android.view.ViewGroup/android.widget.TextView[1]";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.LinearLayout[2]/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.ScrollView/android.view.ViewGroup/android.widget.LinearLayout[2]/android.widget.FrameLayout/android.widget.EditText";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.location.Value);
                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.LinearLayout[2]/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.ScrollView/android.view.ViewGroup/android.widget.Button";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();


            }
        }
    }
}