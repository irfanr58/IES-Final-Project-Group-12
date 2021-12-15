using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        List<Student> _Studentsinfo = new List<Student>()
        {
        new Student(){ Id=2001,Name="Irfan",Course="BDAT"},
        new Student(){ Id=2002,Name="Divya",Course="RAPP"},
        new Student(){ Id=2003,Name="Manna",Course="GBMT"}


        };

        [HttpGet]
        public IActionResult Gets()
        { 
        
        if (_Studentsinfo.Count==0)
            {
                return NotFound("No List Found");
            }
            return Ok(_Studentsinfo);
        
        }

        [HttpGet("GetStudent")]
        public IActionResult Get(int id)
        {
            var oStudent = _Studentsinfo.SingleOrDefault(x => x.Id == id);
            if (oStudent == null)
            {
                return NotFound("No student found.");

            
            }
            return Ok(oStudent);
        
        
        
        }
        [HttpPost]

        public IActionResult Save(Student oStudent)
        {
            _Studentsinfo.Add(oStudent);
            if (_Studentsinfo.Count == 0)
            {
                return NotFound("No list found.");
                       
            
            }return Ok(_Studentsinfo);
        
        }
        [HttpDelete]
        public IActionResult DeleteStudent(int id) {
            var oStudent = _Studentsinfo.SingleOrDefault(x => x.Id == id);
            if(oStudent==null)
            {
                return NotFound("No Student Found.");
                           }
            _Studentsinfo.Remove(oStudent);

            if (_Studentsinfo.Count == 0)
            {
                return NotFound("No list found.");
            }
            return Ok(_Studentsinfo);

    
        
        }
    }
}
