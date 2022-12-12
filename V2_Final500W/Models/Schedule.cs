namespace V2_Final500W.Models
{
    /// <summary>
    /// This is the model of Schedule
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// This is unique/serial Id number of Schedule (Also PK for it's table)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// This is starting date and time for schedule and   in the database will be datetime2(0)
        /// </summary>
        public DateTime StartTime { get; set; }


        /// <summary>
        /// This refers to particular semester (for which is this schedule) id from semester table 
        /// </summary>
        public int? SemesterId { get; set; }
        /// <summary>
        /// This refers to particular semester for which is this schedule
        /// </summary>
        public Semester? Semester { get; set; }


        ////////////////////////////////////////////////////////////////////////////// i'm not sure if many to many relationship is corect way like that

        /// <summary>
        /// This refers to Subjects list in this  particular schedule
        /// </summary>
        public IEnumerable<ScheduleSubject>? ScheduleSubjects { get; set; }
        /// <summary>
        /// This refers to Rooms list which will be (or has been) used in this  particular schedule
        /// </summary>
        public IEnumerable<ScheduleRoom>? ScheduleRooms { get; set; }

        /// <summary>
        /// This is ending date and time for schedule and   in the database will be datetime2(0)
        /// </summary>
        public DateTime EndTime { get; set; }

    }
}

