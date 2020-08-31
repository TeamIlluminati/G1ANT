﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Yatra
{
    [Command(Name = "yatra.cabs", Tooltip = "This command is used to search cabs on yatra.com")]
    class YatraCabCommand : Command
    {
        public YatraCabCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Tooltip = "Enter -> 1 for one way -> 2 for round-trip")]
            public IntegerStructure op { get; set; }

            [Argument(Required = true, Tooltip = "Enter departure location here")]
            public TextStructure depart { get; set; }

            [Argument(Required = true, Tooltip = "Enter destination here")]
            public TextStructure destination { get; set; }

            [Argument(Required = true, Tooltip = "Enter departure date here in dd/mm/yyyy format")]
            public TextStructure departdate { get; set; }

            [Argument(Tooltip = "If Two way trip, enter return date here in dd/mm/yyyy format")]
            public TextStructure returndate { get; set; }

            [Argument(Tooltip = "Name of a variable where the value of a specified attribute will be stored")]
            public VariableStructure result { get; set; } = new VariableStructure("result");

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(10000);
                arguments.Search.Value = "//a[@id='booking_engine_cabs']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                if (arguments.op.Value == 2)
                {
                    Thread.Sleep(5000);
                    arguments.Search.Value = "//a[contains(text(),'Outstation Round Trip')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = "//input[@id='BE_cabs_from_station']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    SeleniumManager.CurrentWrapper.TypeText(arguments.depart.Value, arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//input[@id='BE_cabs_to_station']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    SeleniumManager.CurrentWrapper.TypeText(arguments.destination.Value, arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//input[@id='BE_cabs_checkin_date']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = arguments.departdate.Value;
                    arguments.By.Value = "id";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//input[@id='checkInTimeField']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//div[@id='checkInTimeList']//li[contains(text(),'10:00 am')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//input[@id='BE_cabs_checkout_date']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = arguments.returndate.Value;
                    arguments.By.Value = "id";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//input[@id='checkOutTimeField']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//div[@id='checkOutTimeList']//li[contains(text(),'10:00 pm')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                }

                else
                {

                    Thread.Sleep(5000);
                    arguments.Search.Value = "//a[contains(text(),'Outstation Oneway')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = "//input[@id='BE_cabs_from_station']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    SeleniumManager.CurrentWrapper.TypeText(arguments.depart.Value, arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//input[@id='BE_cabs_to_station']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    SeleniumManager.CurrentWrapper.TypeText(arguments.destination.Value, arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//input[@id='BE_cabs_checkin_date']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    arguments.Search.Value = arguments.departdate.Value;
                    arguments.By.Value = "id";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//input[@id='checkInTimeField']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//div[@id='checkInTimeList']//li[contains(text(),'10:00 am')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);

                }
                Thread.Sleep(2000);
                arguments.Search.Value = "//input[@id='BE_cabs_htsearch_btn']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(10000);
                arguments.Search.Value = "//body/div[@id='root']/div[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                var attributeValue = SeleniumManager.CurrentWrapper.GetTextValue(
                 arguments,
                 arguments.Timeout.Value);


                Scripter.Variables.SetVariableValue(arguments.result.Value, new TextStructure(attributeValue));


            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}