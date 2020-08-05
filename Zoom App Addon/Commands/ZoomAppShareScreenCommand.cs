using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.ZoomApp
{
    [Command(Name = "zoomapp.sharescreen", Tooltip = "This command shares user screen in meeting in Zoom App.")]
    public class ZoomAppShareCommand : Language.Command
    {
        public ZoomAppShareCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public class Arguments : CommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

            [Argument(Name = "Meeting id", Required = true, Tooltip = "Enter the meeting id or sharing key.")]
            public TextStructure meeting { get; set; } = new TextStructure(string.Empty);
            [Argument(Name = "Required", Required = true, Tooltip = "Enter password required-yes or no")]
            public TextStructure req { get; set; } = new TextStructure(string.Empty);
            
            [Argument(Name = "Password", Required = true, Tooltip = "Enter the password")]
            public TextStructure pword { get; set; } = new TextStructure(string.Empty);

        }
        public void Execute(Arguments arguments)
        {
            if(arguments.req.Value=="Yes")
            {
                arguments.Search.Value = "//android.widget.LinearLayout[@content-desc='Share Screen, button']/android.widget.RelativeLayout";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();

                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.EditText";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.meeting.Value);

                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.RelativeLayout/android.widget.LinearLayout[2]/android.widget.Button[2]";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
                Thread.Sleep(4000);

                arguments.Search.Value = "//android.widget.EditText[@content-desc='Meeting Password']";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.pword.Value);

                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.RelativeLayout/android.widget.LinearLayout[2]/android.widget.Button[2]";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
            }

            if (arguments.req.Value == "No")
            {
                arguments.Search.Value = "//android.widget.LinearLayout[@content-desc='Share Screen, button']/android.widget.RelativeLayout";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();

                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.EditText";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.meeting.Value);

                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.RelativeLayout/android.widget.LinearLayout[2]/android.widget.Button[2]";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
                Thread.Sleep(4000);
            }
            }
        }
}
