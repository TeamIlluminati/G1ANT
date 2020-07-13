using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Facebook
{
    [Command(Name = "facebook.groupinvite", Tooltip = "This sends group invites for the specified group")]
    class FacebookGroupInviteCommand : Command
    {
        public FacebookGroupInviteCommand(AbstractScripter scripter) : base(scripter)
        {
        }


        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Specify the Group ID here")]
            public TextStructure GroupID { get; set; }
            [Argument(Required = true, Tooltip = "Enter Friend's name")]
            public TextStructure FriendName { get; set; }
            [Argument(Required = true, Tooltip = "Enter login e-mail ID")]
            public TextStructure email { get; set; }
            [Argument(Required = true, Tooltip = "Enter password here")]
            public TextStructure password { get; set; }
            [Argument(Required = true, Tooltip = "Enter the name of a browser")]
            public TextStructure Type { get; set; }
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                var URL = String.Format("facebook.com/groups/{0}", arguments.GroupID);
                SeleniumOpen(URL, arguments.Type.Value, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[1]/div[3]/div[1]/div/div[2]/div[2]/form/div[2]/div[1]/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.email.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[1]/div[3]/div[1]/div/div[2]/div[2]/form/div[2]/div[2]/input";
                SeleniumManager.CurrentWrapper.TypeText(arguments.password.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[1]/div[3]/div[1]/div/div[2]/div[2]/div[2]/div[1]/div/div/div/div/div[1]/div/div/div[1]/div[2]/div[1]/div/div/div/form/div[1]/div/div/input";
                SeleniumManager.CurrentWrapper.PressKey("escape", arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.FriendName.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured! Message: {ex.Message}", ex);
            }

        }

        private void SeleniumOpen(string URL, string Type, TimeSpan timeout)
        {
            try
            {
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                        Type,
                        URL,
                        timeout,
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
                throw new ApplicationException($"Error occured while opening new selenium instance. Url '{URL}'. Message: {ex.Message}", ex);
            }
        }

    }
}
