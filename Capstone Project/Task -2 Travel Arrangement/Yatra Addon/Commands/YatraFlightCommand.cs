﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using G1ANT.Language;

namespace G1ANT.Addon.Yatra
{
    [Command(Name = "yatra.flight", Tooltip = "This command is used to search flights for 1 adult")]
    class YatraFlightCommand : Command
    {
        public YatraFlightCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Tooltip = "Enter -> 1 for one-way ->2 for round-trip")]
            public IntegerStructure op { get; set; }

            [Argument(Required = true, Tooltip = "Enter departure location here")]
            public TextStructure depart { get; set; }

            [Argument(Required = true, Tooltip = "Enter arrival location here")]
            public TextStructure arrival { get; set; }

            [Argument(Required = true, Tooltip = "Enter departure date here in dd/mm/yyyy format")]
            public TextStructure departdate { get; set; }

            [Argument(Tooltip = "If Two way trip, enter return date here in dd/mm/yyyy format")]
            public TextStructure returndate { get; set; }

            [Argument(Required = true, Tooltip = "Enter the class here")]
            public TextStructure cabin { get; set; } = new TextStructure("Economy");

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
                arguments.Search.Value = "//body/div/div/section/div/div/section/div/div/div/ul/li[1]/a[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                if (arguments.op.Value == 2)
                {
                    Thread.Sleep(5000);
                    arguments.Search.Value = "//a[contains(text(),'Round Trip')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = "//body/div/div/section/div/div/div/section/div/div/div/div/div/div/ul/li/ul/li[1]/div[1]/label[1]/input[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    SeleniumManager.CurrentWrapper.TypeText(arguments.depart.Value, arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//body/div/div/section/div/div/div/section/div/div/div/div/div/div/ul/li/ul/li[3]/div[1]/label[1]/input[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    SeleniumManager.CurrentWrapper.TypeText(arguments.arrival.Value, arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//li[1]//section[1]//label[1]//input[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = arguments.departdate.Value;
                    arguments.By.Value = "id";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//li//li[3]//section[1]//label[1]//input[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = arguments.returndate.Value;
                    arguments.By.Value = "id";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                }

                else
                {

                    Thread.Sleep(5000);
                    arguments.Search.Value = "//a[contains(text(),'One Way')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = "//body/div/div/section/div/div/div/section/div/div/div/div/div/div/ul/li/ul/li[1]/div[1]/label[1]/input[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    SeleniumManager.CurrentWrapper.TypeText(arguments.depart.Value, arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//body/div/div/section/div/div/div/section/div/div/div/div/div/div/ul/li/ul/li[3]/div[1]/label[1]/input[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    SeleniumManager.CurrentWrapper.TypeText(arguments.arrival.Value, arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//li[1]//section[1]//label[1]//input[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    arguments.Search.Value = arguments.departdate.Value;
                    arguments.By.Value = "id";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                }

                Thread.Sleep(2000);

                if (arguments.cabin.Value == "Premium Economy")
                {
                    arguments.Search.Value = "//body/div/div/section/div/div/div/section/div/div/div/div/div/div/div/i[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = "//span[contains(text(),'Premium Economy')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.cabin.Value == "Business")
                {
                    arguments.Search.Value = "//body/div/div/section/div/div/div/section/div/div/div/div/div/div/div/i[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = "//html//body//div//div//section//div//div//div//section//div//div//div//div//div//div//div//div//div//div//div//ul//li//span[contains(text(),'Business')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }

                else if (arguments.cabin.Value == "First Class")
                {
                    arguments.Search.Value = "//body/div/div/section/div/div/div/section/div/div/div/div/div/div/div/i[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = "//span[contains(text(),'First Class')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else
                {
                    arguments.Search.Value = "//body/div/div/section/div/div/div/section/div/div/div/div/div/div/div/i[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = "//div//div//div//div//div//div//div//div//div//div//div//div//div//li[1]//span[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                Thread.Sleep(3000);
                arguments.Search.Value = "//body/div/div/section/div/div/div/section/div/div/div/div/div/div[2]/input[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(10000);
                arguments.Search.Value = "//body/section[@id='Flight-APP']/section/section/section/div[2]/div[2]";
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