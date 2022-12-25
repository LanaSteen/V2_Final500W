using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;
using V2_Final500W.Models;
using V2_Final500W.Repositories;
using V2_Final500W.ViewModels;

namespace V2_Final500W.Controllers
{
    /// <summary>
    /// Student Controller with CRUD actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class StudentController : ControllerBase
    {

        private readonly UniversityDbContext _context;

        private readonly IGenericRepository<Student> _studentRepository;
        /// <summary>
        /// IGeneric interface implementation
        /// </summary>
        public StudentController(IGenericRepository<Student> studentRepository,
            UniversityDbContext context)
        {
            _studentRepository = studentRepository;

            _context = context;

        }
        /// <summary>
        /// Controller for getting the list of all Students
        /// </summary>
        /// <returns>The List of Students</returns>
        [HttpGet]
        public async Task<IEnumerable<StudentModel>> GetAllStudents()
        {

            Expression<Func<Student, object>> includes = exp => exp.Semester;
            Expression<Func<Student, object>> includes2 = exp2 => exp2.Address;
            Expression<Func<Student, object>> includes3 = exp3 => exp3.Department;
            Expression<Func<Student, object>> includes4 = exp4 => exp4.StudentSubject;
            var students = await _studentRepository.GetAllAsync(null, new[] { includes, includes2, includes3, includes4 });

            return students.Select(x => new StudentModel
            {
                FirstName= x.FirstName,
                LastName= x.LastName,
                PersonalId= x.PersonalId,
                StartYear= x.StartYear,

                SemesterId = x.SemesterId,
                AddressId = x.AddressId,
                DepartmentId =  x.DepartmentId,
                StudentSubject = x.StudentSubject

            });
        }

        /// <summary>
        /// Controller for getting the particular Student through existing id 
        /// </summary>
        /// <returns>The one particular Student model</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudent(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            return Ok(student);
        }

        /// <summary>
        /// Controller for inserting the one particular Student 
        /// </summary>
        /// <returns>Status ok if it was inserted</returns>
        [HttpPost]
        public async Task AddStudent(StudentModel2 student)
        {
            await _studentRepository.AddAsync(new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                PersonalId = student.PersonalId,
                StartYear = student.StartYear,
                SemesterId = student.SemesterId,
                AddressId = student.AddressId,
                DepartmentId = student.DepartmentId,
        

            });
            await _studentRepository.SaveAsync();
        }

  

        /// <summary>
        /// Controller for editing the one particular Student choose by id
        /// </summary>
        /// <returns>Status ok if it was updated</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditStudent(int id, StudentModel2 stud)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (StudentExists(id))
            {
                if (stud.FirstName != "string")
                {
                    if (String.IsNullOrEmpty(stud.FirstName))
                    {
                        return StatusCode(400, $"The FirstName field is required.");
                    }

                    student.FirstName = stud.FirstName;
                }
                else
                {
                    student.FirstName = student.FirstName;
                }
                if (stud.LastName != "string")
                {
                    if (String.IsNullOrEmpty(stud.LastName))
                    {
                        return StatusCode(400, $"The LastName field is required.");
                    }

                    student.LastName = stud.LastName;
                }
                else
                {
                    student.LastName = student.LastName;
                }
                if (stud.PersonalId != "string")
                {
                    if (String.IsNullOrEmpty(stud.PersonalId))
                    {
                        return StatusCode(400, $"The PersonalId field is required.");
                    }

                    student.PersonalId = stud.PersonalId;
                }
                else
                {
                    student.PersonalId = student.PersonalId;
                }

                if (stud.StartYear != 0)
                {

                    student.PersonalId = stud.PersonalId;
                }
                else
                {
                    if (student.StartYear == 0)
                    {
                        return StatusCode(400, $"The PersonalId field is required.");
                    }
                    else { student.PersonalId = student.PersonalId; }
                    
                }

                if (stud.SemesterId != 0)
                {
                    student.SemesterId = stud.SemesterId;
                }
                else
                {
                    student.SemesterId = student.SemesterId;
                }
                if (stud.AddressId != 0)
                {
                    student.AddressId = stud.AddressId;
                }
                else
                {
                    student.AddressId = student.AddressId;
                }
                if (stud.DepartmentId != 0)
                {
                    student.DepartmentId = stud.DepartmentId;
                }
                else
                {
                    student.DepartmentId = student.DepartmentId;
                }

                _studentRepository.Update(student);
                await _studentRepository.SaveAsync();

            }
            else
            {
                return StatusCode(500, $"Wrong Parameters");

            }

            return NoContent();
        }

        /// <summary>
        /// Controller for deleting the one particular Student choose by id
        /// </summary>
        /// <returns>Status ok if it was deleted</returns>


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }
            _studentRepository.Delete2(student);
            await _studentRepository.SaveAsync();

            return NoContent();
        }



        private bool StudentExists(int id)
        {
            // return _context.Students.Any(e => e.Id == id);
            return _studentRepository.GetByIdAsyncBool(id);
        }


    }

}


