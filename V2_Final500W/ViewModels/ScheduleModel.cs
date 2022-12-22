using V2_Final500W.Models;

namespace V2_Final500W.ViewModels
{
    /// <summary>
    /// This is the model view of Schedule
    /// </summary>
    public class ScheduleModel
    {

        /// <summary>
        /// this is the year which this schedule is for
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// This is starting date and time for schedule and   in the database will be datetime2(0)
        /// </summary>
        public TimeSpan StartTime { get; set; }
        //{
        //    get
        //    {
        //        return _startTime;
        //    }
        //    set
        //    {
        //        int hour = DateTime.Parse(value).Hour;
        //        int minute = DateTime.Parse(value).Minute;
        //        int second = DateTime.Parse(value).Second;
        //        _startTime = $"{hour}:{minute}:{second}";
        //    }
        //}

        /// <summary>
        /// This refers to particular semester (for which is this schedule) id from semester table 
        /// </summary>
        public int? SemesterId { get; set; }
        /// <summary>
        /// This refers to particular semester for which is this schedule
        /// </summary>
      //  public Semester? Semester { get; set; }


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
        public TimeSpan EndTime { get; set; }
    }

    public class ScheduleModel2
    {
        /// <summary>
        /// this is the year which this schedule is for
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// This is starting date and time for schedule and   in the database will be datetime2(0)
        /// </summary>
        public TimeSpan StartTime { get; set; }
    

        /// <summary>
        /// This refers to particular semester (for which is this schedule) id from semester table 
        /// </summary>
        public int? SemesterId { get; set; }

        /// <summary>
        /// This is ending date and time for schedule and   in the database will be datetime2(0)
        /// </summary>
        public TimeSpan EndTime { get; set; }
    }


}
