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
    [Command(Name = "naukriapp.applied", Tooltip = "This command display user applied jobs in Naukri App")]
    public class NaukriAppAppliedCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

        }

        public NaukriAppAppliedCommand(AbstractScripter scripter) :
            base(scripter)
        {

        }

        // Implement this method
        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "//android.widget.ImageButton[@content-desc='Navigate up']";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
            arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/androidx.drawerlayout.widget.DrawerLayout/android.view.ViewGroup[2]/android.widget.FrameLayout/android.widget.ScrollView/android.widget.LinearLayout/android.widget.LinearLayout/android.widget.RelativeLayout[1]/android.widget.LinearLayout[5]/android.widget.TextView";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
        }
    }
}