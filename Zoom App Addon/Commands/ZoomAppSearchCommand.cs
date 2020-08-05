using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.ZoomApp
{
    [Command(Name = "zoomapp.search", Tooltip = "This command lets user search in Zoom App.")]
    public class ZoomAppSearchCommand : Language.Command
    {
        public ZoomAppSearchCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public class Arguments : CommandArguments
        {
            [Argument(Required = false, Tooltip = "Provide name of the capaility")]
            public TextStructure Search { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Provide element ID")]
            public TextStructure By { get; set; } = new TextStructure(string.Empty);

            [Argument(Name = "Keyword", Required = true, Tooltip = "Enter the keyword to search.")]
            public TextStructure keyword { get; set; } = new TextStructure(string.Empty);

            [Argument(Name = "Message", Required = false, Tooltip = "Message to display.")]
            public TextStructure message { get; set; } = new TextStructure("Please press <ENTER> key to show search.Ignore if already pressed");
        }
        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.LinearLayout/androidx.viewpager.widget.ViewPager/android.widget.LinearLayout/android.widget.RelativeLayout/android.widget.LinearLayout/android.widget.LinearLayout/android.widget.RelativeLayout/android.widget.EditText";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.keyword.Value);
            RobotMessageBox.Show(arguments.message.Value);
            
        }
    }
}
