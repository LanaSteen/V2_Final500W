using V2_Final500W.Models;

namespace V2_Final500W.Models
{
    /// <summary>
    /// model of combined schedule and room 
    /// </summary>
    public class ScheduleRoom
    {

        /// <summary>
        /// This is unique/serial Id number of ScheduleRoom (Also PK for it's table)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// This refers to particular schedule id from schedule table 
        /// </summary>
        public int? ScheduleId { get; set; }
        /// <summary>
        /// This refers to particular schedule 
        /// </summary>
        public Schedule? Schedule { get; set; }

        /// <summary>
        /// This refers to particular Room id from schedule table 
        /// </summary>
        public int? RoomId { get; set; }

        /// <summary>
        /// This refers to particular Room  
        /// </summary>
        public Room? Room { get; set; }
    }
}



