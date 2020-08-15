﻿using System;
using G1ANT.Language;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Remote;

namespace G1ANT.Addon.rapido
{
    [Command(Name = "rapido.notifications", Tooltip = "This command opens your notifications")]
    public class NotificationsCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure("");

            [Argument(Required = true, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure("");
        }

        public NotificationsCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "com.rapido.passenger:id/orderNavigation";
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
                arguments.Search.Value = "/ hierarchy / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.FrameLayout / androidx.drawerlayout.widget.DrawerLayout / android.widget.FrameLayout / android.widget.RelativeLayout / android.widget.FrameLayout / androidx.recyclerview.widget.RecyclerView / android.widget.LinearLayout / android.widget.LinearLayout / android.widget.LinearLayout[8]";
                arguments.By.Value = "xpath";
                ElementHelper.GetElement(arguments.By.Value.ToLower(), arguments.Search.Value).Click();
            }
        }
    }
}

