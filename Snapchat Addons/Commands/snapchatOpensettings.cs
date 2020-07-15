using System;
using G1ANT.Language;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.snapchat
{
    [Command(Name = "snapchat.settings", Tooltip = "This command clicks opens account settings")]
    public class OpensettingsCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; }

            [Argument(Required = true, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; }
            

        }

        public OpensettingsCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "com.snapchat.android:id/avatar_silhouette_3";
            arguments.By.Value = "id";
            var by = arguments.By.Value.ToLower();


            if (by == "xy")
            {
                TouchAction clickAction = new TouchAction(OpenCommand.GetDriver());
                var coordinates = arguments.Search.Value.Split(',');
                clickAction.Tap(int.Parse(coordinates[0]), int.Parse(coordinates[1])).Perform();
            }
            else
            {
                ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
                arguments.Search.Value = "com.snapchat.android:id/camera_flip_button";
                arguments.By.Value = "id";
                ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
              

            }
        }
    }
}


