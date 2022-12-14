
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using V2_Final500W.Models;
using V2_Final500W.Repositories;
using V2_Final500W.ViewModels;

namespace V2_Final500W.Controllers
{
    /// <summary>
    /// ScheduleRoom Controller with CRUD actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class ScheduleRoomController : ControllerBase
    {

        private readonly UniversityDbContext _context;
        
        private readonly IGenericRepository<Subject> _subjectRepository;
        private readonly IGenericRepository<ScheduleRoom> _scheduleRoomRepository;
        /// <summary>
        /// IGeneric interface implementation
        /// </summary>
        public ScheduleRoomController(IGenericRepository<ScheduleRoom> scheduleRoomRepository,
            IGenericRepository<Subject> subjectRepository,
            UniversityDbContext context)
        {
            _scheduleRoomRepository = scheduleRoomRepository;
            _subjectRepository = subjectRepository;

            _context = context;

        }
        /// <summary>
        /// Controller for getting the list of all ScheduleRooms
        /// </summary>
        /// <returns>The List of ScheduleRooms</returns>
        [HttpGet]
        public async Task<IEnumerable<ScheduleRoomModel>> GetAllScheduleRooms()
        {
          
            Expression<Func<ScheduleRoom, object>> includes = exp => exp.Schedule;
            Expression<Func<ScheduleRoom, object>> includes2 = exp2 => exp2.Room;

            var scheduleRooms = await _scheduleRoomRepository.GetAllAsync(null, new[] { includes, includes2 });

            return scheduleRooms.Select(x => new ScheduleRoomModel
            {
              
                ScheduleId = x.ScheduleId,
                RoomId = x.RoomId

            });
        }

        /// <summary>
        /// Controller for getting the particular ScheduleRoom through existing id 
        /// </summary>
        /// <returns>The one particular ScheduleRoom model</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleRoomModel>> GetScheduleRoom(int id)
        {
            var scheduleRoom = await _scheduleRoomRepository.GetByIdAsync(id);

            if (scheduleRoom == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            return Ok(scheduleRoom);
        }

        /// <summary>
        /// Controller for inserting the one particular ScheduleRoom or list ScheduleRoom
        /// </summary>
        /// <returns>Status ok if it was inserted</returns>
        [HttpPost]
        public async Task <IActionResult> AddScheduleRooms(List<ScheduleRoomModel> scheduleRooms)
        {
            foreach(ScheduleRoomModel scheduleRoom in scheduleRooms) { 
            await _scheduleRoomRepository.AddAsync(new ScheduleRoom
            {
              
                ScheduleId = scheduleRoom.ScheduleId,
                RoomId = scheduleRoom.RoomId
            });
            await _scheduleRoomRepository.SaveAsync();
            }
            return Ok($"Succseed");
        }

        /// <summary>
        /// Controller for editing the one particular ScheduleRoom choose by id
        /// </summary>
        /// <returns>Status ok if it was updated</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditScheduleRoom(int id, ScheduleRoomModel schedR)
        {
            var scheeduleRoom = await _scheduleRoomRepository.GetByIdAsync(id);
            if (ScheduleRoomExists(id))
            {
                if (schedR.ScheduleId != 0)
                {
                    scheeduleRoom.ScheduleId = schedR.ScheduleId;
                }
                else
                {
                    scheeduleRoom.ScheduleId = scheeduleRoom.ScheduleId;
                }
                if (schedR.RoomId != 0)
                {
                    scheeduleRoom.RoomId = schedR.RoomId;
                }
                else
                {
                    scheeduleRoom.RoomId = scheeduleRoom.RoomId;
                }

                _scheduleRoomRepository.Update(scheeduleRoom);
                await _scheduleRoomRepository.SaveAsync();

            }
            else
            {
                return StatusCode(500, $"Wrong Parameters");

            }

            return Ok($"Succseed");
        }

        /// <summary>
        /// Controller for deleting the one particular ScheduleRoom choose by id
        /// </summary>
        /// <returns>Status ok if it was deleted</returns>

        // DELETE: api/Addresses1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleRoom(int id)
        {
            var scheduleRooms = await _scheduleRoomRepository.GetByIdAsync(id);
            if (scheduleRooms == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }
            _scheduleRoomRepository.Delete2(scheduleRooms);
            await _scheduleRoomRepository.SaveAsync();

            return Ok($"Succseed");
        }



        private bool ScheduleRoomExists(int id)
        {
            //  return _context.ScheduleRooms.Any(e => e.Id == id);
            return _scheduleRoomRepository.GetByIdAsyncBool(id);
        }



        //private async int GetStudentMaxNumberOnSubject(int? id)
        //{
        //    var x = await _subjectRepository.GetByIdAsync2(id); 
        //    var y =x.MaxNumberOfStudents;
        //    return y;
        //}

        //ესაა ის შემთხვევა როდესაც რეპოზიტორი ვერ გამოვიყენე ანუ სადაც WHERE დამჭირდა და სადაც int დაბრუნება დამჭირდა 
        private int? CountStudentsWithSameSubject(int? id)
        {
           // var x = _scheduleRoomRepository.GetByIdAsync2(id);
            var x = _context.ScheduleRooms.Where(c => c.Id == id);
            var y = x.Count();
            return y;
        }
        /// <summary>
        /// //// Dont even ask me
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        [HttpGet("{startDate}")]
        public int? GetScheduleRoomFree(DateTime startDate)
        {
            var x = _context.Rooms.Where(c => c.IsFree == false);
            var y = x.Select(c => c.ScheduleRooms);
           var z = new List<Schedule>();
            foreach (ScheduleRoom i in  y)
            {
                z.Add((Schedule)_context.Schedules.Where(k => k.Id == i.ScheduleId)); 
            }

            var m = z.Where(c => c.Semester.StartDate == startDate).Count();
            return m;
        }


    }

}


