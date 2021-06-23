using System.Runtime.Serialization;

namespace TestWeb.Helper
{
    public class MessageHelper
    {
        [DataMember]
        public string Message { get; set; }
        public int statuscode { get; set; }
    }
}
