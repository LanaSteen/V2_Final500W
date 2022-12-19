using System.ComponentModel.DataAnnotations.Schema;

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
       // public string _startTime;

        public TimeSpan StartTime { get; set; }
        //{
        //    get { return _startTime; }
        //    set
        //    {
        //        int hour = DateTime.Parse(value).Hour;
        //        int minute = DateTime.Parse(value).Minute;
        //        int second = DateTime.Parse(value).Second;
        //        _startTime = $"{hour}:{minute}:{second}0";
        //    }
        //}


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

       // public string _endTime;

        public TimeSpan EndTime { get; set; }
        //{
        //    get { return _endTime; }
        //    set
        //    {
        //        int hour = DateTime.Parse(value).Hour;
        //        int minute = DateTime.Parse(value).Minute;
        //        int second = DateTime.Parse(value).Second;
        //        _endTime = $"{hour}:{minute}:{second}0";
        //    }
        //}

    }
}

