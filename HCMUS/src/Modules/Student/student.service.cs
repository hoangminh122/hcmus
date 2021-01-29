using HCMUS.src.Entities.Applicant;
using HCMUS.src.Modules.Database;
using HCMUS.src.Modules.Student.Dto;
using HCMUS.src.Shared.Filters;
using MongoDB.Bson;
using MongoDB.Driver;
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


        public async Task<PagedResponse<StudentDto>> GetAllStudentsAsync( StudentQueryInput filter)
        {
            try
            {

                //filter query
                FilterDefinition<Students> filterBody = Builders<Students>.Filter.Regex("last_name", new BsonRegularExpression(filter.LastName));
                BuildersFilterResponse<Students> filterResult =
                    new BuildersFilterResponse<Students>();
                filterResult.AddNewFilter(filterBody);

                //end filter query

                var page = new PaginationFilter(filter.PageNumber, filter.PageSize);


                var result = await _repository.GetAllListAsync(filterResult.FilterResult, page);
                //var result =  new PagedResponse<List<Students>>(
                //            await _repository.GetAllListAsync(filterResult.FilterResult, page),
                //            filter.PageNumber,
                //            filter.PageSize
                //         );


                //var result =  await _repository.GetAllListAsync();
                var minh =  new StudentDto
                {
                    Id = result[0].Id.ToString(),
                    LastName = result[0].LastName,
                    StudentId = result[0].StudentId
                };
                return new PagedResponse<StudentDto>(
                           minh,
                            filter.PageNumber,
                            filter.PageSize
                         );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<StudentDto> GetStudentsByIdAsync(string id)
        {
            try
            {
                var idObject = new ObjectId(id);

                var student = await _repository.GetByIdAsync(idObject);

                //var result =  await _repository.GetAllListAsync();
                var result = new StudentDto
                {
                    Id = student.Id.ToString(),
                    LastName = student.LastName,
                    StudentId = student.StudentId
                };
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
