/**
*    Copyright(C) G1ANT Ltd, All rights reserved
*    Solution G1ANT.Addon, Project G1ANT.Addon.Selenium
*    www.g1ant.com
*
*    Licensed under the G1ANT license.
*    See License.txt file in the project root for full license information.
*
*/

using G1ANT.Language;
using System;

namespace G1ANT.Addon.tumblr
{
    [Command(Name = "tumblr.trends", Tooltip = "This command opens trends of tumblr")]

    class tumblrtrendsCommand : Command
    {
        public tumblrtrendsCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the trend to be opened")]
            public TextStructure open { get; set; } = new TextStructure();
            [Argument(Required = true, Tooltip = "Enter the value to be followed ")]
            public TextStructure searchvalue { get; set; }

            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);


        }
        public void Execute(Arguments arguments)
        {
            try
            {








                arguments.Search.Value = "/html/body/div[2]/div[1]/div[1]/div/div[2]/a";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                switch (arguments.open.Value)
                {
                    case "Staff Picks":
                        arguments.Search.Value = "/html/body/div[2]/div[2]/div/div/a[3]";
                        arguments.By.Value = "xpath";
                        SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                        break;
                    case "Text":
                        arguments.Search.Value = "/html/body/div[2]/div[2]/div/div/a[4]";
                        arguments.By.Value = "xpath";
                        SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                        break;
                    case "Photos":
                        arguments.Search.Value = "/html/body/div[2]/div[2]/div/div/a[5]";
                        arguments.By.Value = "xpath";
                        SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                        break;
                    case "GIFs":
                        arguments.Search.Value = "/html/body/div[2]/div[2]/div/div/a[6]";
                        arguments.By.Value = "xpath";
                        SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                        break;
                    case "Quotes":
                        arguments.Search.Value = "/html/body/div[2]/div[2]/div/div/a[7]";
                        arguments.By.Value = "xpath";
                        SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                        break;
                    case "Chats":
                        arguments.Search.Value = "/html/body/div[2]/div[2]/div/div/a[8]";
                        arguments.By.Value = "xpath";
                        SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                        break;
                    case "Audio":
                        arguments.Search.Value = "/html/body/div[2]/div[2]/div/div/a[9]";
                        arguments.By.Value = "xpath";
                        SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                        break;
                    case "Video":
                        arguments.Search.Value = "/html/body/div[2]/div[2]/div/div/a[10]";
                        arguments.By.Value = "xpath";
                        SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                        break;
                    case "Asks":
                        arguments.Search.Value = "/html/body/div[2]/div[2]/div/div/a[11]";
                        arguments.By.Value = "xpath";
                        SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                        break;
                    case "Recommended":
                        arguments.Search.Value = "/html/body/div[2]/div[2]/div/div/a[1]";
                        arguments.By.Value = "xpath";
                        SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                        break;

                }



            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while typing text to element. 'Search element phrase: '{arguments.Search.Value}', by: '{arguments.By.Value}'. Message: {ex.Message}", ex);
            }
        }

    }
}
