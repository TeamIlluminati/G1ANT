﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using OpenQA.Selenium;

namespace G1ANT.Addon.Zomato
{
    [Command(Name = "zomato.profile", Tooltip = "This command will open your profile on zomato")]
    class ZomatoViewProfileCommand : Command
    {
        public ZomatoViewProfileCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : ZomatoCommandArguments
        {
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        {
            try
            {

                arguments.Search.Value = "/html/body/div[4]/header/div[1]/div/div[2]/div/div/span/i";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html/body/div[1]/div[2]/header/nav/ul[2]/li[2]/div/div/div[2]/div[1]/div";
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
