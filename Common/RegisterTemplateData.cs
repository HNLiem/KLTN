using Newtonsoft.Json;

namespace WebApi.Common
{
    public class RegisterTemplateData
    {

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}
