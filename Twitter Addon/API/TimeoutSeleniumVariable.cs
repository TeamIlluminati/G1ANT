using G1ANT.Language;
using System;

namespace G1ANT.Addon.Twitter.Variables
{
    [Variable(
        Name = "timeouttwitter",
        Tooltip = "Determines the timeout value (in ms) for several `selenium.` commands; the default value is 10000 (10 seconds)")]
    public class TimeoutTwitterVariable : Variable
    {
        private TimeSpanStructure value;

        public TimeoutTwitterVariable(AbstractScripter scripter = null) : base(scripter) 
        {
            value = new TimeSpanStructure(new TimeSpan(0, 0, 10), "", scripter);
        }

        public override Structure GetValue(string index = null)
        {
            return value.Get(index);
        }

        public override void SetValue(Structure value, string index = null)
        {
            this.value.Set(value, index);
        }
    }
}
