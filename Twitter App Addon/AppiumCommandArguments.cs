using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using G1ANT.Language;


namespace G1ANT.Addon.TwitterAndroid 
{

    public class AppiumCommandArguments : CommandArguments
    {
        // Enter all arguments you need 
        [Argument(Required = false, Tooltip = "Provide name of the capability")]
        public TextStructure Search { get; set; } = new TextStructure(string.Empty);

        [Argument(Required = false, Tooltip = "Provide element ID")]
        public VariableStructure Result { get; set; } = new VariableStructure(string.Empty);
    }
}