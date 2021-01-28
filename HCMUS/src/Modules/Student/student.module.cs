using HCMUS.src.Entities.Applicant;
using HCMUS.src.Modules.Student.Dto;
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
            public  Task<StudentDto> GetAllStudentsAsync();
           public List<Students> GetAllStudents();

        }
    }
}
