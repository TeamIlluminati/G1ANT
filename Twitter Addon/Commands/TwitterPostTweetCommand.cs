using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Addon.Twitter;
using G1ANT.Language;


namespace G1ANT.Addon.Twitter
{
    [Command(Name = "twitter.posttweet", Tooltip = "Allows a user to post their tweets to a public forum")]
    class TwitterPostTweetCommand : Command
    {
        public TwitterPostTweetCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : TwitterCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the message to be posted ")]
            public TextStructure postvalue { get; set; }

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "/html/body/div/div/div/div[2]/header/div/div/div/div[1]/div[2]/nav/a[1]/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div/div/div/div[2]/main/div/div/div/div/div/div[2]/div/div[2]/div[1]/div/div/div/div[2]/div[1]/div/div/div/div/div/div/div/div/div/div[1]/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.postvalue.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div/div/div/div[2]/main/div/div/div/div/div/div[2]/div/div[2]/div[1]/div/div/div/div[2]/div[2]/div/div/div[2]/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
            }
            catch(Exception ex)
            {
                throw new ApplicationException($"Error occured while opening a new instance. Message: {ex.Message}", ex);
            }
        }
    }
}