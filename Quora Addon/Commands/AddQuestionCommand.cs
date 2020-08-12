using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Addon.Quora;
using G1ANT.Language;

namespace G1ANT.Addon.Quora
{
    [Command(Name = "quora.addquestion", Tooltip= "This can add questions to be asked on Quora")]
    class AddQuestionCommand :  Command
    {
        public AddQuestionCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : QuoraCommandArguments
        {
            [Argument(Required = true, Tooltip ="This allows a user to add his query online")]
            public TextStructure postvalue { get; set; }
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "/html/body/div[1]/div/div/div[2]/div/div/span/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[1]/div/div[1]/div/div/div/div/div[2]/div/div/div[1]/div[2]/div/div/div[2]/div[2]/div/div/div[1]/div/div/div/textarea";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.postvalue.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div/div[1]/div/div/div/div/div[2]/div/div/div[2]/div/div[2]/span/button";
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
