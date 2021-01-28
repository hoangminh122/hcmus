using HCMUS.src.Entities.Applicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCMUS.src.Modules.Student
{
    public class StudentModule
    {
        public interface IStudentService
        {
            public Task<IEnumerable<Students>> GetAllStudentsAsync();
           public List<Students> GetAllStudents();

        }
    }
}
