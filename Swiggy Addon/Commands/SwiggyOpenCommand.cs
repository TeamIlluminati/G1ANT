﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using OpenQA.Selenium;

namespace G1ANT.Addon.Swiggy
{
    [Command(Name = "swiggy.open", Tooltip = "This command will open naukri.com website in specfied web browser")]
    public class SwiggyOpenCommand : Command
    {
        public SwiggyOpenCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Name of a web browser")]
            public TextStructure Type { get; set; } = new TextStructure("chrome");

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
            

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                        arguments.Type.Value,
                        "swiggy.com",
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

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }

    }
}