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
    public class StudentController : ControllerBase
    {
        private AppDbContext _context;
        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok(student.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var students = await _context.Students.ToListAsync();
            if (students == null)
                return NotFound();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _context.Students.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var student = await _context.Students.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (student == null)
                return NotFound();
            _context.Students.Remove(student);
            return Ok("record is deleted");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id,Student studentUpdate)
        {
            var student = _context.Students.Where(a => a.Id == id).FirstOrDefault();
            if (student == null)
                return NotFound();
            else
            {
                student.Age = studentUpdate.Age;
                student.Name = studentUpdate.Name;
                student.RollNo = studentUpdate.RollNo;
                await _context.SaveChangesAsync();
                return Ok("Update Successfully");
            }

        }
    }
}
