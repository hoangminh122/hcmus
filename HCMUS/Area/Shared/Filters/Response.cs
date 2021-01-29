using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCMUS.src.Shared.Filters
{
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(List<T> data)
        {
            Successed = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }

        public List<T> Data { get; set; }
        public bool Successed { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }


    }
}
