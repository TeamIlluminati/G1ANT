using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using RestSharp;

namespace G1ANT.Addon.Facebook
{
    [Command(Name = "facebook.getpageposts", Tooltip = "This retrieves posts from a given page.")]
    class FacebookGetPagePostsCommand : Command
    {
        public FacebookGetPagePostsCommand(AbstractScripter scripter) : base(scripter)
        { 
        }

        public class Arguments : CommandArguments
        {

            [Argument(Required = true, Tooltip = "Specify the Page Access Token here")]
            public TextStructure AccessToken { get; set; }

            [Argument(Required = true, Tooltip = "Enter the number of posts you want")]
            public TextStructure NumberOfPosts { get; set; }

            [Argument(Tooltip = "Result variable")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");

        }

        public void Execute(Arguments arguments)
        {
            var baseURL = String.Format("https://graph.facebook.com/v4.0/me/?fields=posts.limit({0})&access_token=", arguments.NumberOfPosts.Value);
            var URL = String.Concat(baseURL, arguments.AccessToken.Value);
            RestClient client = new RestClient(URL);
            Method currentMethod = ParseRestMethod("get");
            RestRequest request = new RestRequest(string.Empty, currentMethod);
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            if (response.ResponseStatus == ResponseStatus.TimedOut)
            {
                throw new TimeoutException("Request Timed Out");
            }
            Scripter.Variables.SetVariableValue(arguments.Result.Value, new TextStructure(content));
        }

        private Method ParseRestMethod(string method)
        {
            Method currentMethod = Method.GET;
            try
            {
                currentMethod = (Method)Enum.Parse(typeof(Method), method, true);
            }
            catch
            {
                throw new NotSupportedException($"Given method [{method}] is not supported in rest");
            }

            return currentMethod;
        }
    }
}
