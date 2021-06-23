namespace TestWeb.Core.Request
{
    public class Response<T>
    {
        public string status { get; set; }
        public string errorMsg { get; set; }
        public Body<T> body { get; set; }
    }
}