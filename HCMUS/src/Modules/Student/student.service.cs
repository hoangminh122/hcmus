using HCMUS.src.Entities.Applicant;
using HCMUS.src.Modules.Database;
using HCMUS.src.Modules.Student.Dto;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HCMUS.src.Modules.Student.StudentModule;

namespace HCMUS.src.Modules.Student
{
    public class StudentService : IStudentService
    {
        private readonly IMongoRepository<Students, ObjectId> _repository;

        public StudentService(IMongoRepository<Students, ObjectId> repository)
        {
            _repository = repository;
        }

        public  List<Students> GetAllStudents()
        {
            try
            {
                //var MINH = await _repository.GetAllListAsync();

                //var minh = MINH.First().LastName;
                //var m = 0;
                return  _repository.GetAllList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StudentDto> GetAllStudentsAsync()
        {
            try
            {
                var result =  await _repository.GetAllListAsync();
                return new StudentDto
                {
                    Id = result[0].Id.ToString(),
                    LastName = result[0].LastName,
                    StudentId = result[0].StudentId
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
