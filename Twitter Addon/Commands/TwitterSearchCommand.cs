using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Addon.Twitter;
using G1ANT.Language;

namespace G1ANT.Addon.Twitter
{
    [Command(Name = "twitter.search", Tooltip = "Search for daily happenings")]
    class TwitterSearchCommand : Command
    {
        public TwitterSearchCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : TwitterCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the value to search here")]
            public TextStructure searchthis { get; set; }


            [Argument(DefaultVariable = "timeouttwitter", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "/html/body/div/div/div/div[2]/header/div/div/div/div[1]/div[2]/nav/a[2]/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div/div/div/div[2]/main/div/div/div/div/div/div[1]/div[1]/div/div/div/div/div[1]/div[2]/div/div/div/form/div[1]/div/div/div[2]/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.TypeText(arguments.searchthis.Value, arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
