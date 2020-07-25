using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using G1ANT.Language;


namespace G1ANT.Addon.Swiggy
{
    [Command(Name = "swiggy.cart", Tooltip = "This command open user's cart on swiggy ")]
    public class SwiggyCartCommand : Command
    {
        public SwiggyCartCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
            [Argument(Tooltip = "By default, waits until the webpage fully loads")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(false);
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(3000);
                arguments.Search.Value = "/html/body/div[1]/div[1]/header/div/div/ul/li[1]/div/div/div/a";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }


}