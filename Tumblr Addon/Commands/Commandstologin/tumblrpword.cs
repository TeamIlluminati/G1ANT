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
    [Command(Name = "tumblr.pword", Tooltip = "This command sign-in user into tumblr")]

    class tumblrpwordCommand : Command
    {
        public tumblrpwordCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            

            [Argument(Required = true, Tooltip = "Enter the password here")]
            public TextStructure pword { get; set; } = new TextStructure();
            [Argument(Required = true, Tooltip = "Enter the value to be followed ")]
            public TextStructure searchvalue { get; set; }

            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);


        }
        public void Execute(Arguments arguments)
        {
            try
            {
               
                arguments.Search.Value = "signup_password";
                arguments.By.Value = "id";
                SeleniumManager.CurrentWrapper.TypeText(arguments.pword.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[2]/div[1]/div[3]/div[1]/button[1]/span[6]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);


            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while typing text to element. Text: '{arguments.pword.Value}'. 'Search element phrase: '{arguments.Search.Value}', by: '{arguments.By.Value}'. Message: {ex.Message}", ex);
            }
        }

    }
}
