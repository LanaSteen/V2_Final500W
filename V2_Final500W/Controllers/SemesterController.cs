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
                Year= x.Year,
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
            var semester = await  _semesterRepository.GetByIdAsync(id);

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
               Year = semester.Year,
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
            var semester = await _semesterRepository.GetByIdAsync(id);
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
                if (sem.Year != 0)
                {
                    semester.Year = sem.Year;
                }
                else if (sem.Year<1900 && sem.Year > 2100)
                {
                    return StatusCode(500, $"Wrong year.");
                }
                else
                {
                    semester.Year = semester.Year;
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

                _semesterRepository.Update( semester );
                await _semesterRepository.SaveAsync();
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
            var semester = await _semesterRepository.GetByIdAsync(id);
            if (semester == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }
            _semesterRepository.Delete2(semester);
            await _semesterRepository.SaveAsync();

            return NoContent();
        }



        private bool SemesterExists(int id)
        {
            // return _context.Semesters.Any(e => e.Id == id);
            return _semesterRepository.GetByIdAsyncBool(id);
        }





        [HttpGet]
        public async Task<IEnumerable<SemesterModel>> GetYearSemestersWithDepsAndWithSchedules()
        {

            // Expression<Func<Department, object>> includes = exp => exp.Student;
            // Expression<Func<Semester, object>> includes2 = exp2 => exp2.ScheduleRooms;

            var semesters = await _semesterRepository.GetAllAsync(null);

            var xx =  semesters.Select(x => new SemesterModel
            {
                Name = x.Name,
                AvaliableGPA = x.AvaliableGPA,
                Year = x.Year,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Schedules = x.Schedules,
                Departments = x.Departments,
                Students = x.Students,

            });

            return xx;
        }
        /// <summary>
        /// Შექმენით მეთოდი და გამოიტანეთ კონტროლერში (რომელშიც ფიქრობთ რომ ეს მეთოდი უნდა იყსო) 
        /// 1 წლის ცხრილი დეპარტამენტების მიხედვით.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("{year}")]
        public async Task<ActionResult<SemesterModel3>> GetSemesterbyYear(int year)
        {
            List<Semester> semesterByYear= new List<Semester>();
            semesterByYear = GetSemesterIdsByYear(year);
            var semester = new Semester();
            foreach (var i in semesterByYear)
            {
                 semester = await _semesterRepository.GetByIdAsync(i.Id);
            }
  
            var xx = semesterByYear.Select(x => new SemesterModel3
            {
           
                Year = x.Year,
                Schedules = GetSchedsBySemesterID(x.Id),
                Departments = GetDepsBySemesterID(x.Id),
          

            });

            if (xx == null)
            {
                return StatusCode(500, $"This Year does not have any information");
            }

            return Ok(xx);
        }

        private List<Department> GetDepsBySemesterID(int? id)
        {
            var x = _context.Departments.Where(c => c.SemesterId == id).ToList();
       
            return x;
        }

        private List<Schedule> GetSchedsBySemesterID(int? id)
        {
            var x = _context.Schedules.Where(c => c.SemesterId == id).ToList();

            return x;
        }


        private List<Semester> GetSemesterIdsByYear(int? year)
        {
            var x = _context.Semesters.Where(c => c.Year == year).ToList();

            return x;
        }



        private Department GetDepsByStudentID(int studentId)
        {
            Department x = _context.Departments.FirstOrDefault(c => c.Students.Any(e => e.Id == studentId));
            
            return x;
        }

        private Student GetStudentBySemesterID(int semesterId)
        {
           Student x = _context.Students.FirstOrDefault(c => c.SemesterId == semesterId);
            return x;
        }

        private List<int> GetStudentsIdBySemesterID(int semesterId)
        {
           var x = _context.Students.Where(c => c.SemesterId == semesterId).ToList();
            List<int> result = new List<int>();
            foreach(var i in x)
            {
                result.Add(i.Id);
            }
            return result;
        }

        private List<int> GetSubjectsIdByStudentID(int studentId)
        {
            var x = _context.StudentSubjects.Where(m => m.StudentId == studentId).ToList();
            List <int> ints= new List<int>();   
            foreach(var i in x)
            {
                ints.Add(i.Id);
            }

            return ints;
           
        }

        private bool StudentFailed( int subjectId)
        {
            Subject x = _context.Subjects.FirstOrDefault(c => c.Id == subjectId);
            StudentSubject y = _context.StudentSubjects.FirstOrDefault(x=> x.SubjectId == subjectId);
           if( y.Point < x.LowerBound)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// Შექმენით მეთოდი რომელიც კონკრეტულ სემესტრში გამოიტანს ჩაჭრილი სტუდენტების სიას 
        /// დეპარტამენტების მიხედვით.(ინფორმაცია უნდა შეიცავდეს სტუდენტის სახელს,გვარს, 
        /// საგნის დასახელებას და ქულას.)
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>


        [HttpGet("{id}")]
        public async Task<ActionResult<SemesterModel4>> GetFailedStudentsBySemesterId(int id)
        {

           // var semester = await _context.Semesters.FindAsync(id);
            var studentsIds = GetStudentsIdBySemesterID(id);
            List<int> subjectIds = new List<int>();
            List<List<int>> subjectIdsS = new List<List<int>>();
            foreach(int student in studentsIds)
            {
                subjectIds=(GetSubjectsIdByStudentID(student));
                subjectIdsS.Add(subjectIds);
            }
            List<bool> subjects = new List<bool>(); 
            
            foreach(var subject in subjectIdsS)
            {
                foreach(var sub in subject)
                {
                    subjects.Add(StudentFailed(sub));
                    if (StudentFailed(sub))
                      {
                        return StatusCode(100, $"Student faild");
                    }
                }
            }


            return Ok(subjects);
        }
    }

}

