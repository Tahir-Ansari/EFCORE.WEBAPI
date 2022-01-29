using EFCORE.WEBAPI.DataContext;
using EFCORE.WEBAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCORE.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private AppDbContext _context;
        public TeacherController(AppDbContext context)
        {
            _context = context;
        }

        //httppost method/ create a resource
        [HttpPost]
        public async Task<IActionResult> AddTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            if (string.IsNullOrEmpty(teacher.FullName))
            {
                return BadRequest("something is wrong");
            }
            return Ok("record inseerted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeacher()
        {
            var teacher = await _context.Teachers.ToListAsync();
            if (teacher == null)
                return NotFound();
            return Ok(teacher);
        }

        //httpget//get a all teacher by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllTeacherById(int id)
        {
            var teachers = await _context.Teachers.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (teachers == null)
            {
                return NotFound();
            }
            return Ok(teachers);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DelTeacher(int id)
        {
            var teachers = await _context.Teachers.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (teachers == null)
                return NotFound();
             _context.Teachers.Remove(teachers);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(Teacher teacherUpdate,int id)
        {
            var teachers = await _context.Teachers.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (teachers == null)
            {
                return NotFound();
            }
            else
            {
                teachers.FullName = teacherUpdate.FullName;
                teachers.SubjectName = teacherUpdate.SubjectName;
                teachers.Salary = teacherUpdate.Salary;
                await _context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
