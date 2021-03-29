using System.ComponentModel;

namespace WebApi.Common
{
    public enum OtpType
    {
        [Description("Register")]
        Register,

        [Description("ForgotPassword")]
        ForgotPassword,
    }
}
