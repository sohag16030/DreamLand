using System.Collections.Generic;

namespace TestWeb.Core.Request
{
    public class Body<T>
    {
        public List<T> data { get; set; }
    }
}