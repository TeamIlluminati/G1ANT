using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using OpenQA.Selenium;

namespace G1ANT.Addon.Instagram
{
    [Command(Name = "instagram.makepost", Tooltip = "This command will post on instagram")]
    class InstagramMakepostCommand : Command
    {
        public InstagramMakepostCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : InstagramCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the caption to post")]
            public TextStructure caption { get; set; }
            [Argument(Required = true, Tooltip = "Enter the image name to post")]
            public TextStructure imagename { get; set; }
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                
                arguments.Search.Value = "/html/body/div[1]/section/nav[2]/div/div/div[2]/div/div/div[3]/svg";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "filename";
                arguments.By.Value = "id";
                SeleniumManager.CurrentWrapper.TypeText(arguments.imagename.Value, arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[1]/section/div[1]/header/div/div[2]/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/section/div[2]/section[1]/div[1]/textarea";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.caption.Value, arguments, arguments.Timeout.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
