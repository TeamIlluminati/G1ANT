using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using RestSharp;


namespace G1ANT.Addon.Facebook
{
    [Command(Name = "facebook.getfriends", Tooltip = "This retrieves the names of users for a given profile.")]
    class FacebookGetFriendsCommand: Command
    {
        public FacebookGetFriendsCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public class Arguments : CommandArguments
        {
            //https://graph.facebook.com/v4.0/me?fields=friendlists%7Bname%7D&access_token=EAAJ1PvMntuMBALz7aGfqUUyKf60FHjIRPTWSgdhRss4XhmVygHuQ2njFg6fb20pYjrqrY6lXoNXn4rh9MTE736R8129nuUliSEDpKake8toIZBEg5mrrjhUL5lJoTWCZAKIAMWEO6nRW4F3xyCa7ai3tF15fiU3sjC7TF94Wj1fmAoIvif2ybY6tsF8dwhA6L653QGYQpR3uG9KgMS
            [Argument(Required = true, Tooltip = "Specify the Access Token here")]
            public TextStructure AccessToken { get; set; }

            [Argument(Tooltip = "Result variable")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }

        public void Execute(Arguments arguments)
        {
            var baseURL = "https://graph.facebook.com/v4.0/me?fields=friends%7Bname%7D&access_token=";
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
