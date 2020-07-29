using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Medium
{
    [Command(Name = "medium.series", Tooltip = "Helps a user to post stories!")]
    class MediumStoriesCommand : Command
    {
        public MediumStoriesCommand(AbstractScripter scripter): base(scripter)
        {

        }
        public class Arguments : MediumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Set the title")]
            public TextStructure posttitle { get; set; }
            [Argument(Required = true, Tooltip = "Set the body")]
            public TextStructure postvalue { get; set; }
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
                arguments.Search.Value = "/html/body/div[1]/div[2]/div/div[2]/div[2]/div[2]/div[3]/button[2]/div/img";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[1]/div[2]/div/div[2]/div[3]/div[1]/ul/li[4]/a";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[1]/div[2]/div/div[1]/main/article/div[1]/section[1]/div[3]/div/h3/span";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.posttitle, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[1]/div[2]/div/div[1]/main/article/div[1]/section[2]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.postvalue, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[1]/div[2]/div/div[1]/div/div[1]/div[2]/div[2]/div[1]/button[2]/span[1]";
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
