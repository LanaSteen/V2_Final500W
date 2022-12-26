
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using V2_Final500W.Models;
using V2_Final500W.Repositories;
using V2_Final500W.ViewModels;

namespace V2_Final500W.Controllers
{
    /// <summary>
    /// ScheduleSubject Controller with CRUD actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class ScheduleSubjectController : ControllerBase
    {

        private readonly IGenericRepository<ScheduleSubject> _scheduleSubjectRepository;
        /// <summary>
        /// IGeneric interface implementation
        /// </summary>
        public ScheduleSubjectController(IGenericRepository<ScheduleSubject> scheduleSubjectRepository)
        {
            _scheduleSubjectRepository = scheduleSubjectRepository;


        }
        /// <summary>
        /// Controller for getting the list of all ScheduleSubjects
        /// </summary>
        /// <returns>The List of ScheduleSubjects</returns>
        [HttpGet]
        public async Task<IEnumerable<ScheduleSubjectModel>> GetAllScheduleSubjects()
        {

            Expression<Func<ScheduleSubject, object>> includes = exp => exp.Schedule;
            Expression<Func<ScheduleSubject, object>> includes2 = exp2 => exp2.Subject;

            var scheduleSubjects = await _scheduleSubjectRepository.GetAllAsync(null, new[] { includes, includes2 });

            return scheduleSubjects.Select(x => new ScheduleSubjectModel
            {

                ScheduleId = x.ScheduleId,
                SubjectId = x.SubjectId

            });
        }

        /// <summary>
        /// Controller for getting the particular ScheduleSubject through existing id 
        /// </summary>
        /// <returns>The one particular ScheduleSubject model</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleSubjectModel>> GetScheduleSubject(int id)
        {
            var scheduleSubject = await _scheduleSubjectRepository.GetByIdAsync(id);

            if (scheduleSubject == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            return Ok(scheduleSubject);
        }

        /// <summary>
        /// Controller for inserting the one particular ScheduleSubject or list of ScheduleSubjects
        /// </summary>
        /// <returns>Status ok if it was inserted</returns>
        [HttpPost]
        public async Task <IActionResult> AddScheduleSubjects(List<ScheduleSubjectModel> scheduleSubjects)
        {
            foreach(ScheduleSubjectModel scheduleSubject in scheduleSubjects)
            {
            await _scheduleSubjectRepository.AddAsync(new ScheduleSubject
            {
                ScheduleId = scheduleSubject.ScheduleId,
                SubjectId = scheduleSubject.SubjectId
            });
            await _scheduleSubjectRepository.SaveAsync();
            }
            return Ok($"Succseed");
        }

        /// <summary>
        /// Controller for editing the one particular ScheduleSubject choose by id
        /// </summary>
        /// <returns>Status ok if it was updated</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditScheduleSubject(int id, ScheduleSubjectModel schedS)
        {
            var scheeduleSubject = await _scheduleSubjectRepository.GetByIdAsync(id);
            if (ScheduleSubjectExists(id))
            {
                if (schedS.ScheduleId != 0)
                {
                    scheeduleSubject.ScheduleId = schedS.ScheduleId;
                }
                else
                {
                    scheeduleSubject.ScheduleId = scheeduleSubject.ScheduleId;
                }
                if (schedS.SubjectId != 0)
                {
                    scheeduleSubject.SubjectId = schedS.SubjectId;
                }
                else
                {
                    scheeduleSubject.SubjectId = scheeduleSubject.SubjectId;
                }

                _scheduleSubjectRepository.Update(scheeduleSubject);
                await _scheduleSubjectRepository.SaveAsync();

            }
            else
            {
                return StatusCode(500, $"Wrong Parameters");

            }

            return Ok($"Succseed");
        }

        /// <summary>
        /// Controller for deleting the one particular ScheduleSubject choose by id
        /// </summary>
        /// <returns>Status ok if it was deleted</returns>

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleSubject(int id)
        {
            var scheduleSubjects = await _scheduleSubjectRepository.GetByIdAsync(id);
            if (scheduleSubjects == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }
            _scheduleSubjectRepository.Delete2(scheduleSubjects);
            await _scheduleSubjectRepository.SaveAsync();

            return Ok($"Succseed");
        }



        private bool ScheduleSubjectExists(int id)
        {
            // return _context.ScheduleSubjects.Any(e => e.Id == id);
            return _scheduleSubjectRepository.GetByIdAsyncBool(id);
        }


    }

}


