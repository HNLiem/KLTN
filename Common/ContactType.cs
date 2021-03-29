using System.ComponentModel;


namespace WebApi.Common
{
    public enum ContactType
    {
        [Description("Customer")]
        Customer,

        [Description("Supplier")]
        Supplier,
    }
}
