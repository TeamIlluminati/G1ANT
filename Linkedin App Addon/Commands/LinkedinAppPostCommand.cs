using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.MultiTouch;


namespace G1ANT.Addon.LinkedinApp
{
    [Command(Name = "linkedinapp.post", Tooltip = "This command post the text in Linkedin app given by user")]

    public class LinkedinAppPostCommand : Language.Command
    {
        public LinkedinAppPostCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public class Arguments : CommandArguments
        {
            // Enter all arguments you need
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

            [Argument(Name = "access", Required = true, Tooltip = "Provide accessbility-Anyone or Connections Only")]
            public TextStructure access { get; set; } = new TextStructure(string.Empty);

            [Argument(Name = "text", Required = true, Tooltip = "Provide content of post")]
            public TextStructure text { get; set; } = new TextStructure(string.Empty);
        }
        public void Execute(Arguments arguments)
        {
            if (arguments.access.Value == "Anyone")
            {
                arguments.Search.Value = "//android.view.ViewGroup[@content-desc='Post']/android.widget.ImageView";
                arguments.By.Value = "xpath";

                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.LinearLayout/android.widget.RelativeLayout/android.widget.ScrollView/android.widget.LinearLayout/android.widget.FrameLayout[2]/android.widget.EditText";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.text.Value);
                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.LinearLayout/android.view.ViewGroup/androidx.appcompat.widget.LinearLayoutCompat/android.widget.Button";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
            }
            if (arguments.access.Value == "Connections only")
            {
                arguments.Search.Value = "//android.view.ViewGroup[@content-desc='Post']/android.widget.ImageView";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.LinearLayout/android.widget.RelativeLayout/android.widget.ScrollView/android.widget.LinearLayout/android.widget.FrameLayout[2]/android.widget.EditText";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.text.Value);
                arguments.Search.Value = "//android.widget.Button[@content-desc='Anyone, Select post visibility option']";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
                arguments.Search.Value = "//android.view.ViewGroup[@content-desc='Connections only, Connections on LinkedIn, Unselected']/android.widget.RadioButton";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.View";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
                arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.LinearLayout/android.view.ViewGroup/androidx.appcompat.widget.LinearLayoutCompat/android.widget.Button";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
            }
        }
    }
}
