using System.ComponentModel;


namespace WebApi.Common
{
    public enum ProductType
    {
        [Description("Item")]
        Item,

        [Description("Service")]
        Service,
    }
}
