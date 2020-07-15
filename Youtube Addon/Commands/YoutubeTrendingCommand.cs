using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using G1ANT.Addon.Youtube;
using G1ANT.Language;

namespace G1ANT.Addon.Youtube
{
    [Command(Name = "youtube.trending", Tooltip = "This command redirects user to vidoes trending on youtube")]

    public class YoutubeTrendingCommand : Command
    {
        public YoutubeTrendingCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public class Arguments : SeleniumCommandArguments
        {

            [Argument(DefaultVariable = "url", Tooltip = "")]
            public TextStructure url { get; set; } = new TextStructure("https://www.youtube.com/feed/trending");
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
            [Argument(Tooltip = "By default, waits until the webpage fully loads")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(false);
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.Navigate(arguments.url.Value, arguments.Timeout.Value, arguments.NoWait.Value);

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }



        }






    }
}
