using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;
using System.Net;
using V2_Final500W.Models;
using V2_Final500W.Repositories;
using V2_Final500W.ViewModels;

namespace V2_Final500W.Controllers
{
    /// <summary>
    /// Schedule Controller with CRUD actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class ScheduleController : ControllerBase
    {

        private readonly UniversityDbContext _context;

        private readonly IGenericRepository<Schedule> _scheduleRepository;
        /// <summary>
        /// IGeneric interface implementation
        /// </summary>
        public ScheduleController(IGenericRepository<Schedule> scheduleRepository,
            UniversityDbContext context)
        {
            _scheduleRepository = scheduleRepository;

            _context = context;

        }
        /// <summary>
        /// Controller for getting the list of all schedules
        /// </summary>
        /// <returns>The List of schedules</returns>
        [HttpGet]
        public async Task<IEnumerable<ScheduleModel>> GetAllSchedules()
        {

            // Expression<Func<Department, object>> includes = exp => exp.Student;
            Expression<Func<Schedule, object>> includes2 = exp2 => exp2.Semester;

            var schedules = await _scheduleRepository.GetAllAsync(null, new[] { includes2 });

            return schedules.Select(x => new ScheduleModel
            {   
                Year= x.Year,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                SemesterId= x.SemesterId,
                ScheduleSubjects= x.ScheduleSubjects,
                ScheduleRooms = x.ScheduleRooms,

            });
        }

        /// <summary>
        /// Controller for getting the particular Schedule through existing id 
        /// </summary>
        /// <returns>The one particular Schedule model</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleModel>> GetSchedule(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);

            if (schedule == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            return Ok(schedule);
        }

        /// <summary>
        /// Controller for inserting the one particular Schedule 
        /// </summary>
        /// <returns>Status ok if it was inserted</returns>
        [HttpPost]
        public async Task AddScheedule(ScheduleModel2 schedule)
        {
            await _scheduleRepository.AddAsync(new Schedule
            {
                Year= schedule.Year,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                SemesterId = schedule.SemesterId,

            });
            await _scheduleRepository.SaveAsync();
        }

        /// <summary>
        /// Controller for editing the one particular Schedule choose by id
        /// </summary>
        /// <returns>Status ok if it was updated</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditSchedule(int id, ScheduleModel2 sched)
        {
            var shcedule = await _context.Schedules.FindAsync(id);
            if (ScheduleExists(id))
            {
                if (sched.Year != 0)
                {

                    shcedule.Year = sched.Year;
                }
                else
                {
                    shcedule.Year = shcedule.Year;
                }
                shcedule.StartTime = sched.StartTime;
                shcedule.EndTime = sched.EndTime;
            
                if (sched.SemesterId != 0)
                {

                    shcedule.SemesterId = sched.SemesterId;
                }
                else
                {
                    shcedule.SemesterId = shcedule.SemesterId;
                }

                _context.Schedules.Update(shcedule);
                await _context.SaveChangesAsync();

            }
            else
            {
                return StatusCode(500, $"Wrong Parameters");

            }

            return NoContent();
        }

        /// <summary>
        /// Controller for deleting the one particular Schedule choose by id
        /// </summary>
        /// <returns>Status ok if it was deleted</returns>


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        private bool ScheduleExists(int id)
        {
            return _context.Schedules.Any(e => e.Id == id);
        }



        //[HttpGet("{year}")]
        //public async Task<ActionResult<ScheduleModel>> GetScheduleByYear(int year)
        //{

        //    var schedule = await _context.Schedules.FindAsync(year);

        //    if (schedule == null)
        //    {
        //        return StatusCode(500, $"There is no schedule on {year} year");
        //    }
     
        //    return Ok(schedule);
        //}

      

    }

}

