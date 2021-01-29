using HCMUS.src.Entities.Applicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCMUS.src.Modules.Test
{
    public interface ITestService
    {
        public Task<IEnumerable<AppUsers>> GetAll();
    }
}
