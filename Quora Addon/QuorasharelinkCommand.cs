using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Addon.Quora;
using G1ANT.Language;


namespace G1ANT.Addon.Quora
{
    [Command(Name ="quora.share", Tooltip = "This can allow a person to share different links on the platform")]
    class QuorasharelinkCommand : Command
    {
        public QuorasharelinkCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments: QuoraCommandArguments
        {
            [Argument(Required = true, Tooltip = "post the URL on the forum")]
            public TextStructure postvalue { get; set; }
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "//*[@id='root']/div/div/div[4]/div/div/div[2]/div/div[1]/div/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "//*[@id='root']/div/div[1]/div/div/div/div/div[2]/div/div/div[1]/div[1]/div/div[2]/div/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "//*[@id='root']/div/div[1]/div/div/div/div/div[2]/div/div/div[1]/div[2]/div/div/div[2]/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.postvalue.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "//*[@id='root']/div/div[1]/div/div/div/div/div[2]/div/div/div[1]/div[2]/div/div/div[3]/div/div/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.postvalue.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "//*[@id='root']/div/div[1]/div/div/div/div/div[2]/div/div/div[2]/div/div[2]/span/button";
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
