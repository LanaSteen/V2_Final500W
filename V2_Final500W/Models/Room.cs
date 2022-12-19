namespace V2_Final500W.Models
{
    /// <summary>
    /// This is the model of Room
    /// </summary>
    public class Room
    {
        /// <summary>
        /// This is unique/serial Id number of Room (Also PK for it's table)
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// This is Description about room : name or floor or etc
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// This is about either room is free=true=1 or it is not free = false=0
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
}
