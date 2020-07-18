using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Linkedin
{
    [Command(Name = "linkedin.connections", Tooltip = "This command is used to get user's connections on linkedin.")]
    public class LinkedinConnectionsCommand : Command
    {
        public LinkedinConnectionsCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
         
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "mynetwork-tab-icon";
                arguments.By.Value = "id";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(10000);
                arguments.Search.Value = "/html[1]/body[1]/div[9]/div[4]/div[1]/div[1]/div[1]/div[1]/div[1]/aside[1]/div[1]/section[1]/div[1]/div[1]/a[1]/div[1]/div[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(10000);


                arguments.Search.Value = "/html[1]/body[1]/div[8]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/section[1]";
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