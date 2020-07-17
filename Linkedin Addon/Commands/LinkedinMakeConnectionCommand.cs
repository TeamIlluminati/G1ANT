﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Addon.Linkedin;
using G1ANT.Language;
using System.Threading;

namespace G1ANT.Addon.MyAddon1
{
    [Command(Name = "linkedin.makeconnection", Tooltip = "This command is used to make connection in the linkedin site.")]
    class LinkedinMakeConnectionCommand : Command
    {
        public LinkedinMakeConnectionCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter person's name and id here seperated each word by '-'")]
            public TextStructure name { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        {
            try
            {

                arguments.Search.Value = "search-global-typeahead__input";
                arguments.By.Value = "class";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.TypeText(arguments.name.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(1000);



                SeleniumManager.CurrentWrapper.PressKey("down", arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                Thread.Sleep(8000);
                arguments.Search.Value = "body.render-mode-BIGPIPE.nav-v2.theme.theme--classic.ember-application.boot-complete.icons-loaded:nth-child(2) div.application-outlet:nth-child(77) div.authentication-outlet:nth-child(3) div.extended div.body div.pv-profile-wrapper.pv-profile-wrapper--below-nav div.self-focused.ember-view div.pv-content.profile-view-grid.neptune-grid.two-column.ghost-animate-in main.core-rail div.ember-view section.pv-top-card.artdeco-card.ember-view div.ph5.pb5 div.display-flex:nth-child(1) div.flex-1.flex-column.display-flex.mt3.mb1 div.display-flex.justify-flex-end.align-items-center div.mt1.inline-flex.align-items-center.ember-view span.ember-view:nth-child(1) div.ember-view button.pv-s-profile-actions.pv-s-profile-actions--connect.ml2.artdeco-button.artdeco-button--2.artdeco-button--primary.ember-view > span.artdeco-button__text";
                arguments.By.Value = "Cssselector";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value, true);

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }

        }


    }
}