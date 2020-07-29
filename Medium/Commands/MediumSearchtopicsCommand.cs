using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Medium
{
    [Command(Name = "medium.search", Tooltip = "Helps User search the topics he wants to")]
    class MediumSearchtopicsCommand : Command
    {
        public MediumSearchtopicsCommand(AbstractScripter scripter): base(scripter)
        {

        }
        public class Arguments: MediumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the value to be searched ")]
            public TextStructure keyword { get; set; }
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                    "chrome",
                    "https://www.medium.com/",
                    arguments.Timeout.Value,
                    false,
                    Scripter.Log,
                    Scripter.Settings.UserDocsAddonFolder.FullName);
                int wrapperId = wrapper.Id;
                OnScriptEnd = () =>
                {
                    SeleniumManager.DisposeAllOpenedDrivers();
                    SeleniumManager.RemoveWrapper(wrapperId);
                    SeleniumManager.CleanUp();
                };
                arguments.Search.Value = "/html/body/div[1]/div[2]/div/div[1]/div[2]/div[2]/div/a[1]/span/span/svg";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[1]/div[2]/div/div[3]/div[1]/header/form/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.keyword.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }

    }
}
