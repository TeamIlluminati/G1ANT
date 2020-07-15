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
    [Command(Name = "tumblr.post", Tooltip = "This command create posts in tumblr")]

    class tumblrpostCommand : Command
    {
        public tumblrpostCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the post to be opened")]
            public TextStructure open { get; set; } = new TextStructure();
            

            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);


        }
        public void Execute(Arguments arguments)
        {
            try
            {








                arguments.Search.Value = "/html/body/div[2]/div[1]/button/svg/g/path";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                switch (arguments.open.Value)
                {
                    case "Text":
                        arguments.Search.Value = "/html/body/div[8]/div/div/div[1]/div[1]";
                        arguments.By.Value = "xpath";
                        SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                        break;
                    case "Photo":
                        arguments.Search.Value = "/html/body/div[8]/div/div/div[2]/div[1]";
                        arguments.By.Value = "xpath";
                        SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                        break;
                    case "Quote":
                        arguments.Search.Value = "/html/body/div[8]/div/div/div[3]/div[1]";
                        arguments.By.Value = "xpath";
                        SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                        break;
                    case "Link":
                        arguments.Search.Value = "/html/body/div[8]/div/div/div[4]/div[1]";
                        arguments.By.Value = "xpath";
                        SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                        break;
                    case "Chat":
                        arguments.Search.Value = "/html/body/div[8]/div/div/div[5]/div[1]";
                        arguments.By.Value = "xpath";
                        SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                        break;
                    case "Audio":
                        arguments.Search.Value = "/html/body/div[8]/div/div/div[6]/div[1]";
                        arguments.By.Value = "xpath";
                        SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                        break;
                    case "Video":
                        arguments.Search.Value = "/html/body/div[8]/div/div/div[7]/div[1]";
                        arguments.By.Value = "xpath";
                        SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                        break;
                   ;

                }



            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while typing text to element. 'Search element phrase: '{arguments.Search.Value}', by: '{arguments.By.Value}'. Message: {ex.Message}", ex);
            }
        }

    }
}
