using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Medium
{
    [Command(Name = "medium.write", Tooltip = "Helps the user to share articles")]
    class MediumWriteArticlesCommand : Command
    {
        public MediumWriteArticlesCommand(AbstractScripter scripter) : base(scripter)
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
                arguments.Search.Value = "/html/body/div[1]/div[2]/div/main/article/div[1]/section/div[2]/div/h3";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.posttitle, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[1]/div[2]/div/main/article/div[1]/section/div[2]/div/p";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.postvalue, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[1]/div[2]/div/div[2]/div[2]/div[2]/div[1]/button/span";
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

