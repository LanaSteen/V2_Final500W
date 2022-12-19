using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;
using V2_Final500W.Models;
using V2_Final500W.Repositories;
using V2_Final500W.ViewModels;

namespace V2_Final500W.Controllers
{
    /// <summary>
    /// Semester Controller with CRUD actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class SemesterController : ControllerBase
    {

        private readonly UniversityDbContext _context;

        private readonly IGenericRepository<Semester> _semesterRepository;
        /// <summary>
        /// IGeneric interface implementation
        /// </summary>
        public SemesterController(IGenericRepository<Semester> semesterRepository,
            UniversityDbContext context)
        {
            _semesterRepository = semesterRepository;

            _context = context;

        }
        /// <summary>
        /// Controller for getting the list of all Semesters
        /// </summary>
        /// <returns>The List of Semesters</returns>
        [HttpGet]
        public async Task<IEnumerable<SemesterModel>> GetAllSemesters()
        {

            // Expression<Func<Department, object>> includes = exp => exp.Student;
           // Expression<Func<Semester, object>> includes2 = exp2 => exp2.ScheduleRooms;

            var semesters = await _semesterRepository.GetAllAsync(null);

            return semesters.Select(x => new SemesterModel
            {
                Name = x.Name,
                AvaliableGPA = x.AvaliableGPA,

                StartDate = x.StartDate,
                EndDate= x.EndDate,
                Schedules = x.Schedules,
                Departments= x.Departments,
                Students= x.Students,

            });
        }

        /// <summary>
        /// Controller for getting the particular semester through existing id 
        /// </summary>
        /// <returns>The one particular semester model</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SemesterModel>> GetSemester(int id)
        {
            var semester = await _context.Semesters.FindAsync(id);

            if (semester == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            return Ok(semester);
        }

        /// <summary>
        /// Controller for inserting the one particular semester 
        /// </summary>
        /// <returns>Status ok if it was inserted</returns>
        [HttpPost]
        public async Task AddSemester(SemesterModel2 semester)
        {
            await _semesterRepository.AddAsync(new Semester
            {
               
                Name = semester.Name,
                AvaliableGPA = semester.AvaliableGPA,
                StartDate = semester.StartDate,
                EndDate = semester.EndDate,

            });
            await _semesterRepository.SaveAsync();
        }

        /// <summary>
        /// Controller for editing the one particular semester choose by id
        /// </summary>
        /// <returns>Status ok if it was updated</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditSemester(int id, SemesterModel2 sem)
        {
            var semester = await _context.Semesters.FindAsync(id);
            if (SemesterExists(id))
            {

                if (sem.Name != "string")
                {
                    if (String.IsNullOrEmpty(sem.Name))
                    {
                        return StatusCode(400, $"The Descrioption field is required.");
                    }

                    semester.Name = sem.Name;
                }
                else
                {
                    semester.Name = semester.Name;
                }

                if (sem.AvaliableGPA != 0)
                {
                    if (sem.AvaliableGPA == null)
                    {
                        return StatusCode(400, $"The  field is required.");
                    }

                    semester.AvaliableGPA = sem.AvaliableGPA;
                }
                else
                {
                    semester.AvaliableGPA = semester.AvaliableGPA;
                }

                if (sem.EndDate != DateTime.Now)
                {
                    if (sem.EndDate == null)
                    {
                        return StatusCode(400, $"The  field is required.");
                    }

                    semester.EndDate = sem.EndDate;
                }
                else
                {
                    semester.EndDate = semester.EndDate;
                }

                if (sem.StartDate != DateTime.Now)
                {
                    if (sem.StartDate == null)
                    {
                        return StatusCode(400, $"The  field is required.");
                    }

                    semester.StartDate = sem.StartDate;
                }
                else
                {
                    semester.StartDate = semester.StartDate;
                }

         
                _context.Semesters.Update(semester);
                await _context.SaveChangesAsync();

            }
            else
            {
                return StatusCode(500, $"Wrong Parameters");

            }

            return NoContent();
        }

        /// <summary>
        /// Controller for deleting the one particular Semester choose by id
        /// </summary>
        /// <returns>Status ok if it was deleted</returns>


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSemester(int id)
        {
            var semester = await _context.Semesters.FindAsync(id);
            if (semester == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            _context.Semesters.Remove(semester);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        private bool SemesterExists(int id)
        {
            return _context.Semesters.Any(e => e.Id == id);
        }


    }

}

