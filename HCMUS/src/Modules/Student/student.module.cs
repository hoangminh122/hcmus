using HCMUS.src.Entities.Applicant;
using HCMUS.src.Modules.Student.Dto;
using HCMUS.src.Shared.Filters;
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
            Task<PagedResponse<StudentDto>> GetAllStudentsAsync(StudentQueryInput filter);      // fixing  ->can not use
            Task<StudentDto> GetStudentsByIdAsync(string id);
            public List<Students> GetAllStudents();

        }
    }
}
