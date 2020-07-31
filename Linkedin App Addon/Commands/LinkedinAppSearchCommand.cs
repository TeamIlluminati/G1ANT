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
    [Command(Name = "linkedinapp.search", Tooltip = "This command searches the given keyword in Linkedin app")]

    public class LinkedinAppSearchCommand : Language.Command
    {
        public LinkedinAppSearchCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public class Arguments : CommandArguments
        {
            // Enter all arguments you need
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);
            [Argument(Name="keyword",Required = true, Tooltip = "Provide keyword you want to search")]
            public TextStructure keyword { get; set; } = new TextStructure(string.Empty);
            [Argument(Required = false, Tooltip = "Message to display")]
            public TextStructure message { get; set; } = new TextStructure("Please type <<<ENTER>>> Command after search command to see the results of your search, if you already typed it ignore this messsage - Thank you");

        }
        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "//android.widget.Button[@content-desc='Search for people, jobs, posts, and more']/android.widget.TextView";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.keyword.Value);
            RobotMessageBox.Show(arguments.message.Value);
        }
    }
}
