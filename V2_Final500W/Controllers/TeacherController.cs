
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography.Xml;
using V2_Final500W.Models;
using V2_Final500W.Repositories;
using V2_Final500W.ViewModels;

namespace V2_Final500W.Controllers
{
    /// <summary>
    /// Teacher Controller with CRUD actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class TeacherController : ControllerBase
    {

        private readonly UniversityDbContext _context;

        private readonly IGenericRepository<Teacher> _teacherRepository;
        /// <summary>
        /// IGeneric interface implementation
        /// </summary>
        public TeacherController(IGenericRepository<Teacher> teacherRepository,
            UniversityDbContext context)
        {
            _teacherRepository = teacherRepository;

            _context = context;

        }
        /// <summary>
        /// Controller for getting the list of all Teachers
        /// </summary>
        /// <returns>The List of Teachers</returns>
        [HttpGet]
        public async Task<IEnumerable<TeacherModel>> GetAllTeachers()
        {

            Expression<Func<Teacher, object>> includes = exp => exp.Subject;
            Expression<Func<Teacher, object>> includes2 = exp2 => exp2.Department;
            Expression<Func<Teacher, object>> includes3 = exp3 => exp3.Address;

            var teachers = await _teacherRepository.GetAllAsync(null, new[] { includes, includes2, includes3 });
            //var a = teachers.Count<Teacher>();

            //Console.WriteLine(a);
            return teachers.Select(x => new TeacherModel
            {
                
                FirstName = x.FirstName,
                LastName= x.LastName,
                PersonalId= x.PersonalId,
                SubjectId = x.SubjectId,
               // Subject = x.Subject,
                DepartmentId = x.DepartmentId,
                //Department = x.Department,
                AddressId = x.AddressId,

                //Address = x.Address,
            });
        }

        /// <summary>
        /// Controller for getting the particular Teacher through existing id 
        /// </summary>
        /// <returns>The one particular Teacher model</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherModel>> GetTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            return Ok(teacher);
        }


        /// <summary>
        /// Controller for inserting the one particular Teacher 
        /// </summary>
        /// <returns>Status ok if it was inserted</returns>

        [HttpPost]
        public async Task<IActionResult> AddTeacherMaxSubj(TeacherModel2 teacher)
        {
            await _teacherRepository.AddAsync(new Teacher
            {

                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                PersonalId = teacher.PersonalId,
                SubjectId = teacher.SubjectId,

                DepartmentId = teacher.DepartmentId,

                AddressId = teacher.AddressId,


            });

            int? curentNumberOfTeachers = CountTeacherWithSameSubject(teacher?.SubjectId);
            int? MaxNumberOfTeachers = GetTeacherMaxNumberOnSubject(teacher?.SubjectId);
            if (curentNumberOfTeachers >= MaxNumberOfTeachers)
            {
                return StatusCode(500, $"Over maximmum number of students");
            }
            else { await _teacherRepository.SaveAsync(); }
            return NoContent();


        }


        private int? GetTeacherMaxNumberOnSubject(int? id)
        {
            var x = _context.Subjects.First(c => c.Id == id);
            var y = x.MaxNumberOfTeachers;
            return y;
        }

        private int? CountTeacherWithSameSubject(int? id)
        {
            var x = _context.Teachers.Where(c => c.SubjectId == id);
            var y = x.Count();
            return y;
        }







        /// <summary>
        /// Controller for editing the one particular Teacher choose by id
        /// </summary>
        /// <returns>Status ok if it was updated</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditTeacher(int id, TeacherModel2 teach)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (TeacherExists(id))
            {
                if (teach.FirstName != "string")
                {
                    if (String.IsNullOrEmpty(teach.FirstName))
                    {
                        return StatusCode(400, $"The FirstName field is required.");
                    }
                    teacher.FirstName = teach.FirstName;
                }
                else
                {
                    teacher.FirstName = teacher.FirstName;
                }

                if (teach.LastName != "string")
                {
                    if (String.IsNullOrEmpty(teach.LastName))
                    {
                        return StatusCode(400, $"The LastName field is required.");
                    }
                    teacher.LastName = teach.LastName;
                }
                else
                {
                    teacher.LastName = teacher.LastName;
                }

                if (teach.PersonalId != "string")
                {
                    if (String.IsNullOrEmpty(teach.PersonalId))
                    {
                        return StatusCode(400, $"The LastName field is required.");
                    }
                    teacher.PersonalId = teach.PersonalId;
                }
                else
                {
                    teacher.PersonalId = teacher.PersonalId;
                }


                if (teach.SubjectId != 0)
                {
                    teacher.SubjectId = teach.SubjectId;
                }
                else
                {
                    teacher.SubjectId = teacher.SubjectId;
                }

                if (teach.DepartmentId != 0)
                {
                    teacher.DepartmentId = teach.DepartmentId;
                }
                else
                {
                    teacher.DepartmentId = teacher.DepartmentId;
                }

                if (teach.AddressId != 0)
                {
                    teacher.AddressId = teach.AddressId;
                }
                else
                {
                    teacher.AddressId = teacher.AddressId;
                }


                _context.Teachers.Update(teacher);
                await _context.SaveChangesAsync();

            }
            else
            {
                return StatusCode(500, $"Wrong Parameters");

            }

            return NoContent();
        }

        /// <summary>
        /// Controller for deleting the one particular Teacher choose by id
        /// </summary>
        /// <returns>Status ok if it was deleted</returns>


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }


    }

}