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
    [Command(Name = "tumblr.activity", Tooltip = "This command opens the activity in tumblr")]

    class tumblractivityCommand : Command
    {
        public tumblractivityCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {


            
            [Argument(Required = true, Tooltip = "Enter the value to be followed ")]
            public TextStructure searchvalue { get; set; }

            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);


        }
        public void Execute(Arguments arguments)
        {
            try
            {

                
                arguments.Search.Value = "/html/body/div[3]/div/div[1]/div/div[5]/a";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);


            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while typing text to element. 'Search element phrase: '{arguments.Search.Value}', by: '{arguments.By.Value}'. Message: {ex.Message}", ex);
            }
        }

    }
}
