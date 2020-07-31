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
    [Command(Name = "linkedinapp.jobs", Tooltip = "This command displays jobs in Linkedin app according to user's profile")]

    public class LinkedinAppJobsCommand : Language.Command
    {
        public LinkedinAppJobsCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public class Arguments : CommandArguments
        {
            // Enter all arguments you need
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

        }
        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "//android.view.ViewGroup[@content-desc='Jobs']/android.widget.ImageView";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
        }
    }
}
