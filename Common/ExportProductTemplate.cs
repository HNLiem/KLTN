using Newtonsoft.Json;

namespace WebApi.Common
{
    public class ExportProductTemplate
    {
        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
