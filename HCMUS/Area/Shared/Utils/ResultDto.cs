using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCMUS.src.Shared.Utils
{
    public class ResultDto<T>
    {
        public ResultDto(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
