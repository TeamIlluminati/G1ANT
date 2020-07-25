﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;
using OpenQA.Selenium;

namespace G1ANT.Addon.Flipkart
{
    [Command(Name = "flipkart.login", Tooltip = "This command login into user's flipkart account.")]
    public class FlipkartLoginCommand : Command
    {
        public FlipkartLoginCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the Mobile number here")]
            public TextStructure phoneno { get; set; }
            [Argument(Required = true, Tooltip = "Enter the password here")]
            public TextStructure pword { get; set; }

            [Argument(Tooltip = "If set to `true`, the command should wait for a new window to appear after clicking the specified element")]
            public BooleanStructure WaitForNewWindow { get; set; } = new BooleanStructure(false);

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "/html/body/div[2]/div/div/div/div/div[2]/div/form/div[1]/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.phoneno.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[2]/div/div/div/div/div[2]/div/form/div[2]/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.pword.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
               
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}