using V2_Final500W.Models;

namespace V2_Final500W.ViewModels
{
    /// <summary>
    /// This is the model view of Room
    /// </summary>
    public class RoomModel
    {
        /// <summary>
        /// This is Description about room : name or floor or etc
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// This is about either room is free=true or it is not free = false
        /// </summary>
        public bool? IsFree { get; set; }

        /// <summary>
        /// This is about how many maximum number of students can be in the room 
        /// </summary>
        public int MaxNumberOfStudents { get; set; }
        /// <summary>
        /// This is list of schedules in which this particular room is involved
        /// </summary>
        public IEnumerable<ScheduleRoom>? ScheduleRooms { get; set; }
    }
    public class RoomModel2
    {
        /// <summary>
        /// This is Description about room : name or floor or etc
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// This is about either room is free=true or it is not free = false
        /// </summary>
        public bool? IsFree { get; set; }

        /// <summary>
        /// This is about how many maximum number of students can be in the room 
        /// </summary>
        public int MaxNumberOfStudents { get; set; }
    
    }
}
