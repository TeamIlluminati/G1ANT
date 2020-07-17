using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using G1ANT.Addon.Quora;

namespace G1ANT.Addon.Quora
{
    [Command(Name = "quora.viewnotification", Tooltip = "Helps a user view their notifications")]
    class QuoraViewNotificationCommand:Command
    {
        public QuoraViewNotificationCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments: QuoraCommandArguments
        {
            [Argument(DefaultVariable = "timeoutquora", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "/html/body/div[1]/div/div/div[2]/div/div/a[2]/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
            }
            catch(Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
