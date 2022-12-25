
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography.Xml;
using V2_Final500W.Models;
using V2_Final500W.Repositories;
using V2_Final500W.ViewModels;

namespace V2_Final500W.Controllers
{
    /// <summary>
    /// Subject Controller with CRUD actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class SubjectController : ControllerBase
    {

        private readonly UniversityDbContext _context;

        private readonly IGenericRepository<Subject> _subjectRepository;
        /// <summary>
        /// IGeneric interface implementation
        /// </summary>
        public SubjectController(IGenericRepository<Subject> subjectRepository,
            UniversityDbContext context)
        {
            _subjectRepository = subjectRepository;

            _context = context;

        }
        /// <summary>
        /// Controller for getting the list of all Subjects
        /// </summary>
        /// <returns>The List of tSubjects</returns>
        [HttpGet]
        public async Task<IEnumerable<SubjectModel>> GetAllSubjects()
        {

            Expression<Func<Subject, object>> includes = exp => exp.Teachers;
            Expression<Func<Subject, object>> includes2 = exp2 => exp2.ScheduleSubject;
            Expression<Func<Subject, object>> includes3 = exp3 => exp3.StudentSubject;

            var subjects = await _subjectRepository.GetAllAsync(null, new[] { includes, includes2, includes3});
            //var a = subjects.Count<Subject>();

            //Console.WriteLine(a);
            return subjects.Select(x => new SubjectModel
            {
                Credit = x.Credit,
                Name= x.Name,
                LowerBound= x.LowerBound,
                MaxNumberOfStudents= x.MaxNumberOfStudents,
                MaxNumberOfTeachers= x.MaxNumberOfTeachers,
                Teachers= x.Teachers,
                ScheduleSubject= x.ScheduleSubject,
                StudentSubject= x.StudentSubject,

            });
        }

        /// <summary>
        /// Controller for getting the particular Subject through existing id 
        /// </summary>
        /// <returns>The one particular Subject model</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectModel>> GetSubject(int id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);

            if (subject == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            return Ok(subject);
        }

        /// <summary>
        /// Controller for inserting the one particular Subject 
        /// </summary>
        /// <returns>Status ok if it was inserted</returns>
        [HttpPost]
        public async Task AddSubject(SubjectModel2 subject)
        {
            await _subjectRepository.AddAsync(new Subject
            {
                Credit = subject.Credit,
                Name = subject.Name,
                LowerBound = subject.LowerBound,
                MaxNumberOfStudents = subject.MaxNumberOfStudents,
                MaxNumberOfTeachers = subject.MaxNumberOfTeachers,
   
            });
            await _subjectRepository.SaveAsync();
        }

        /// <summary>
        /// Controller for editing the one particular Subject choose by id
        /// </summary>
        /// <returns>Status ok if it was updated</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditSubject(int id, SubjectModel2 subj)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            if (SubjectExists(id))
            { 
                if (subj.Credit != 0)
                {
                    subject.Credit = subj.Credit;
                }
                else
                {
                    subject.Credit = subject.Credit;
                }

                if (subj.Name != "string")
                {
                    if (String.IsNullOrEmpty(subj.Name))
                    {
                        return StatusCode(400, $"The Name field is required.");
                    }

                    subject.Name = subj.Name;
                }

                else
                {
                    subject.Name = subject.Name;
                }



                if (subj.LowerBound != 0)
                {
                    subject.LowerBound = subj.LowerBound;
                }
                else
                {
                    subject.LowerBound = subject.LowerBound;
                }

                if (subj.MaxNumberOfStudents != 0)
                {
                    subject.MaxNumberOfStudents = subj.MaxNumberOfStudents;
                }
                else
                {
                    subject.MaxNumberOfStudents = subject.MaxNumberOfStudents;
                }

                if (subj.MaxNumberOfTeachers != 0)
                {
                    subject.MaxNumberOfTeachers = subj.MaxNumberOfTeachers;
                }
                else
                {
                    subject.MaxNumberOfTeachers = subject.MaxNumberOfTeachers;
                }

                _subjectRepository.Update(subject);
                await _subjectRepository.SaveAsync();

            }
            else
            {
                return StatusCode(500, $"Wrong Parameters");

            }

            return NoContent();
        }

        /// <summary>
        /// Controller for deleting the one particular Subject choose by id
        /// </summary>
        /// <returns>Status ok if it was deleted</returns>


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            if (subject == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }
            _subjectRepository.Delete2(subject);
            await _subjectRepository.SaveAsync();

            return NoContent();
        }



        private bool SubjectExists(int id)
        {
            //return _context.Subjects.Any(e => e.Id == id);
            return _subjectRepository.GetByIdAsyncBool(id);
        }


    }

}