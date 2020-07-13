﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;
using G1ANT.Addon.Linkedin;

namespace G1ANT.Addon.Linkedin
{
    [Command(Name = "linkedin.follow", Tooltip = "This command allows user to follow a specific page or person")]
    public class LinkedinFollowCommand : Command
    {
        public LinkedinFollowCommand(AbstractScripter scripter) : base(scripter)
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


                arguments.Search.Value = "search-global-typeahead__input";
                arguments.By.Value = "class";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.TypeText(arguments.searchvalue.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(1000);



                SeleniumManager.CurrentWrapper.PressKey("down", arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "/html/body/div[8]/div[3]/div/div/div/div/div[2]/main/div[1]/section/div[2]/div[1]/div[2]/div/div/span[1]/div/button";
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