using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCMUS.src.Modules.Student.Dto
{
    public class StudentQueryInput
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string LastName { get; set; }
    }
}
