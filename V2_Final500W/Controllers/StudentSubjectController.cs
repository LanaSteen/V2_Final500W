﻿using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Cryptography.Xml;
using V2_Final500W.Models;
using V2_Final500W.Repositories;
using V2_Final500W.ViewModels;

namespace V2_Final500W.Controllers
{
    /// <summary>
    /// StudentSubject Controller with CRUD actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class StudentSubjectController : ControllerBase
    {

        private readonly UniversityDbContext _context;

        private readonly IGenericRepository<StudentSubject> _studentSubjectRepository;
        /// <summary>
        /// IGeneric interface implementation
        /// </summary>
        public StudentSubjectController(IGenericRepository<StudentSubject> studentSubjectRepository,
            UniversityDbContext context)
        {
            _studentSubjectRepository = studentSubjectRepository;

            _context = context;

        }
        /// <summary>
        /// Controller for getting the list of all StudentSubjects
        /// </summary>
        /// <returns>The List of StudentSubjects</returns>
        [HttpGet]
        public async Task<IEnumerable<StudentSubjectModel>> GetAllStudentSubjects()
        {

            Expression<Func<StudentSubject, object>> includes = exp => exp.Student;
            Expression<Func<StudentSubject, object>> includes2 = exp2 => exp2.Subject;

            var studentsSubjects = await _studentSubjectRepository.GetAllAsync(null, new[] { includes, includes2 });
            var a = studentsSubjects.Count<StudentSubject>();
            
            Console.WriteLine(a);
            return studentsSubjects.Select(x => new StudentSubjectModel
            {
                Point= x.Point,
                StudentId = x.StudentId,
                Student =  x.Student,
                SubjectId = x.SubjectId,
                Subject= x.Subject,

            });
        }

        /// <summary>
        /// Controller for getting the particular StudentSubject through existing id 
        /// </summary>
        /// <returns>The one particular StudentSubject model</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentSubjectModel>> GetStudentSubject(int id)
        {
            var studentSubject = await _context.StudentSubjects.FindAsync(id);

            if (studentSubject == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            return Ok(studentSubject);
        }

        /// <summary>
        /// Controller for inserting the one particular StudentSubject 
        /// </summary>
        /// <returns>Status ok if it was inserted</returns>
        [HttpPost]
        public async Task AddStudentSubject(StudentSubjectModel2 studentSubject)
        {
            await _studentSubjectRepository.AddAsync(new StudentSubject
            {
                Point= studentSubject.Point,
                StudentId = studentSubject.StudentId,
                SubjectId = studentSubject.SubjectId
            });
            await _studentSubjectRepository.SaveAsync();
        }

        /// <summary>
        /// Controller for editing the one particular StudentSubject choose by id
        /// </summary>
        /// <returns>Status ok if it was updated</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditStudentSubject(int id, StudentSubjectModel2 studS)
        {
            var studentSubject = await _context.StudentSubjects.FindAsync(id);
            if (StudentSubjectExists(id))
            {
                if (studS.StudentId != 0)
                {
                    studentSubject.StudentId = studS.StudentId;
                }
                else
                {
                    studentSubject.StudentId = studentSubject.StudentId;
                }
                if (studS.SubjectId != 0)
                {
                    studentSubject.SubjectId = studS.SubjectId;
                }
                else
                {
                    studentSubject.SubjectId = studentSubject.SubjectId;
                }


                _context.StudentSubjects.Update(studentSubject);
                await _context.SaveChangesAsync();

            }
            else
            {
                return StatusCode(500, $"Wrong Parameters");

            }

            return NoContent();
        }

        /// <summary>
        /// Controller for deleting the one particular StudentSubject choose by id
        /// </summary>
        /// <returns>Status ok if it was deleted</returns>


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentSubject(int id)
        {
            var studentSubject = await _context.StudentSubjects.FindAsync(id);
            if (studentSubject == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            _context.StudentSubjects.Remove(studentSubject);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        private bool StudentSubjectExists(int id)
        {
            return _context.StudentSubjects.Any(e => e.Id == id);
        }


    }

}