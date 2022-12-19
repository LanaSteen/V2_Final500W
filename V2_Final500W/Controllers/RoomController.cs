using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;
using V2_Final500W.Models;
using V2_Final500W.Repositories;
using V2_Final500W.ViewModels;

namespace V2_Final500W.Controllers
{
    /// <summary>
    /// Room Controller with CRUD actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class RoomController : ControllerBase
    {

        private readonly UniversityDbContext _context;

        private readonly IGenericRepository<Room> _roomRepository;
        /// <summary>
        /// IGeneric interface implementation
        /// </summary>
        public RoomController(IGenericRepository<Room> roomRepository,
            UniversityDbContext context)
        {
            _roomRepository = roomRepository;

            _context = context;

        }
        /// <summary>
        /// Controller for getting the list of all Rooms
        /// </summary>
        /// <returns>The List of Rooms</returns>
        [HttpGet]
        public async Task<IEnumerable<RoomModel>> GetAllRooms()
        {

            // Expression<Func<Department, object>> includes = exp => exp.Student;
            Expression<Func<Room, object>> includes2 = exp2 => exp2.ScheduleRooms;

            var rooms = await _roomRepository.GetAllAsync(null, new[] { includes2 });

            return rooms.Select(x => new RoomModel
            {
                Description = x.Description,
                IsFree = x.IsFree,

                MaxNumberOfStudents = x.MaxNumberOfStudents,
                ScheduleRooms = x.ScheduleRooms,

            });
        }

        /// <summary>
        /// Controller for getting the particular Room through existing id 
        /// </summary>
        /// <returns>The one particular Room model</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomModel>> GetRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            return Ok(room);
        }

        /// <summary>
        /// Controller for inserting the one particular Room 
        /// </summary>
        /// <returns>Status ok if it was inserted</returns>
        [HttpPost]
        public async Task AddRoom(RoomModel2 room)
        {
            await _roomRepository.AddAsync(new Room
            {
                Description = room.Description,
                IsFree = room.IsFree,
                MaxNumberOfStudents = room.MaxNumberOfStudents,

            });
            await _roomRepository.SaveAsync();
        }

        /// <summary>
        /// Controller for editing the one particular Room choose by id
        /// </summary>
        /// <returns>Status ok if it was updated</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditRoom(int id, RoomModel2 roo)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (RoomExists(id))
            {
                
                if (roo.Description != "string")
                {
                    if (String.IsNullOrEmpty(roo.Description))
                    {
                        return StatusCode(400, $"The Descrioption field is required.");
                    }

                    room.Description = roo.Description;
                }
                else
                {
                    room.Description = room.Description;
                }

                if (roo.MaxNumberOfStudents != 0)
                {
                    if (roo.MaxNumberOfStudents == null)
                    {
                        return StatusCode(400, $"The  field is required.");
                    }

                    room.MaxNumberOfStudents = roo.MaxNumberOfStudents;
                }
                else
                {
                    room.MaxNumberOfStudents = room.MaxNumberOfStudents;
                }
                if (roo.IsFree != false)
                {
                  
                    room.IsFree = room.IsFree;
                }
                else
                {
                    room.IsFree = room.IsFree;
                }

                _context.Rooms.Update(room);
                await _context.SaveChangesAsync();

            }
            else
            {
                return StatusCode(500, $"Wrong Parameters");

            }

            return NoContent();
        }

        /// <summary>
        /// Controller for deleting the one particular Room choose by id
        /// </summary>
        /// <returns>Status ok if it was deleted</returns>


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }


    }

}

