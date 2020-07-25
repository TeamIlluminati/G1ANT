using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using System.Threading;


namespace G1ANT.Addon.IRCTC
{
    [Command(Name = "irctc.login", Tooltip = "This command opnes login page on irctc ")]
    public class IRCTCLoginCommand : Command
    {
        public IRCTCLoginCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {

            [Argument(Required = true, Tooltip = "Enter the username")]
            public TextStructure username { get; set; }

            [Argument(Required = true, Tooltip = "Enter the password")]
            public TextStructure password { get; set; }

            [Argument(Tooltip = "By default, waits until the webpage fully loads")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(false);

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "/html/body/app-root/app-home/div[1]/app-header/div[1]/div[3]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/app-root/app-home/div[1]/app-header/div[3]/p-sidebar/div/nav/div/label/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/app-root/app-home/div[2]/app-login/p-dialog/div/div[2]/div[2]/div/div[2]/div[2]/div[2]/form/div[1]/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.username.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/app-root/app-home/div[2]/app-login/p-dialog/div/div[2]/div[2]/div/div[2]/div[2]/div[2]/form/div[2]/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.password.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                RobotMessageBox.Show("Type the Captcha in below box");
            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }


}