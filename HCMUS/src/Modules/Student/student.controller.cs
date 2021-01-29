using HCMUS.src.Entities.Applicant;
using HCMUS.src.Modules.Student.Dto;
using HCMUS.src.Shared.Filters;
using HCMUS.src.Shared.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HCMUS.src.Modules.Student.StudentModule;

namespace HCMUS.src.Modules.Student
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController :ControllerBase
    {

        private readonly IStudentService _studentservice;

        public StudentController(IStudentService studentservice)
        {
            _studentservice = studentservice;
        }

        [HttpGet]
        public async Task<PagedResponse<StudentDto>> GetById([FromQuery] StudentQueryInput filter)
        {
            return await _studentservice.GetAllStudentsAsync(filter);
        }

        
        [HttpGet("id")]
        public async Task<StudentDto> Get(string id)
        {
            return await _studentservice.GetStudentsByIdAsync(id);

        }


        //[HttpGet]
        //public async Task<List<Students>> Get()
        //{

        //    List<Students> test =  await _studentservice.GetAllStudentsAsync();
        //    // var m = test.First().LastName;
        //    return test;
        //}


        //[HttpGet("test")]
        //public  Object Get1()
        //{

        //    var test =  _studentservice.GetAllStudents();
        //   var m= test.First();
        //    return m;
        //    //return await _studentservice.GetAllStudents();
        //}



    }
}
