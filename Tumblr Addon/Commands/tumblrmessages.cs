/**
*    Copyright(C) G1ANT Ltd, All rights reserved
*    Solution G1ANT.Addon, Project G1ANT.Addon.Selenium
*    www.g1ant.com
*
*    Licensed under the G1ANT license.
*    See License.txt file in the project root for full license information.
*
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;
using G1ANT.Addon.tumblr;

namespace G1ANT.Addon.tumblr
{
    [Command(Name = "tumblr.message", Tooltip = "This command allows user to send messages")]
    public class tumblrmessagesCommand : Command
    {
        public tumblrmessagesCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the value to be followed ")]
            public TextStructure searchvalue { get; set; }
            [Argument(Required = true, Tooltip = "Enter the trend to be opened")]
            public TextStructure to { get; set; } = new TextStructure();
            [Argument(Required = true, Tooltip = "Enter the trend to be opened")]
            public TextStructure message { get; set; } = new TextStructure();

            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        {
            try
            {


                arguments.Search.Value = "/html/body/div[3]/div/div[1]/div/div[4]/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[14]/div/div/div[1]/div[2]/a[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[14]/div/div/div[2]/div[1]/label/span[2]/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.to.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[14]/div[1]/div/div/div[1]/div[4]/div[1]/textarea";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.message.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                

               

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}