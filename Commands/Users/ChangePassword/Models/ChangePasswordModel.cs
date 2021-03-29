namespace WebApi.Commands.Users.ChangePassword.Models
{
    public class ChangePasswordModel
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }

        public ChangePasswordModel(string password, string newpassword)
        {
            Password = password;
            NewPassword = newpassword;
        }
    }
}
