namespace WebApi.Entities
{
    public class BaseResponse
    {
        public bool Result { get; set; }

        public string Message { get; set; }

        public string MessageCode { get; set; }
    }
}
