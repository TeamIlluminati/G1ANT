using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Chinagri
{
    [Command(Name = "chingari.trending",Tooltip = "Gives an idea on the latest trending stuffs in chingari")]
    class ChingariTrendingCommand: Command
    {
        public ChingariTrendingCommand(AbstractScripter scripter): base(scripter)
        {

        }
        public class Arguments : ChinagriCommandArguments
        {
            [Argument(Required = true, Tooltip = "Defines which web browser we use")]
            public TextStructure Type { get; set; }

            [Argument(Tooltip = "Webpage address to load")]
            public TextStructure Url { get; set; } = new TextStructure(string.Empty);

            [Argument(DefaultVariable = "timeoutselenium")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Tooltip = "Does not wait for a webpage to fully load")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(false);

            [Argument]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                      arguments.Type.Value,
                      "https://chingari.io/trending",
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
