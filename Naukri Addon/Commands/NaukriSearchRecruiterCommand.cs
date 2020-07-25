using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using System.Threading;

namespace G1ANT.Addon.Naukri
{
    [Command(Name = "naukri.searchrecruiter", Tooltip = "Command to find recruiter in naukri.com")]
    public class NaukriSearchRecruiterCommand : Command
    {
        public NaukriSearchRecruiterCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the name or type of recruiter you want to search")]
            public TextStructure recruiter { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
            [Argument(DefaultVariable = "url", Tooltip = "")]
            public TextStructure url { get; set; } = new TextStructure("https://www.naukri.com/hr-recruiters-consultants");
            [Argument(Tooltip = "By default, waits until the webpage fully loads")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(false);

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(5000);
                SeleniumManager.CurrentWrapper.Navigate(arguments.url.Value, arguments.Timeout.Value, arguments.NoWait.Value);
                arguments.Search.Value = "/html/body/div[2]/div[2]/div[1]/div[1]/form/div[1]/div/div[1]/div[1]/div[2]/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.recruiter.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}