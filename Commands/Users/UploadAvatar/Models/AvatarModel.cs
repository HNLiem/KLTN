
namespace WebApi.Commands.Users.UploadAvatar.Models
{
    public class AvatarModel
    {
        public string Name { get; set; }
        public AvatarModel(string name)
        {
            Name = name;
        }
    }
}
