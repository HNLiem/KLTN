
namespace WebApi.Commands.Users.UpdateSasAvatar.Models
{
    public class UriSas
    {
        public string Uri { get; set; }
        public string Name { get; set; }
        public  UriSas(string uri, string name)
        {
            Uri = uri;
            Name = name;
        }
    }
}
