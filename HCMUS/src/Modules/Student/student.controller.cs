using HCMUS.src.Entities.Applicant;
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
        public async Task<IActionResult> Get()
        {

            return Ok(await _studentservice.GetAllStudentsAsync());
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
