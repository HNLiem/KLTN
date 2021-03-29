using System.ComponentModel;

namespace WebApi.Common
{
    public enum Role
    {
        [Description("Admin")]
        Admin,

        [Description("User")]
        User,

    }
}
