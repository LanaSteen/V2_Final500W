using V2_Final500W.Models;

namespace V2_Final500W.ViewModels
{
    /// <summary>
    /// This is the model view of Semester
    /// </summary>
    public class SemesterModel
    {
        /// <summary>
        /// This is thhe name of particular Semester
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This  value is about how much should be students GPA to study in this semester --------------------------________???????????
        /// </summary>
        public int AvaliableGPA { get; set; }

        /// <summary>
        /// This is starting date and time for Semester and   in the database will be datetime2(0)
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// This is ending date and time for Semester and   in the database will be datetime2(0)
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// //// this is list of the Departments in this particular Semesterr
        /// </summary>
        public IEnumerable<Department>? Departments { get; set; }

        /// <summary>
        /// //// this is list of the Schedules in this particular Semesterr
        /// </summary>
        public IEnumerable<Schedule>? Schedules { get; set; }

        /// <summary>
        /// //// this is list of the Students in this particular Semesterr
        /// </summary>
        public IEnumerable<Student>? Students { get; set; }
    }


    /// <summary>
    /// This is the model view of Semester
    /// </summary>
    public class SemesterModel2
    {
        /// <summary>
        /// This is thhe name of particular Semester
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This  value is about how much should be students GPA to study in this semester --------------------------________???????????
        /// </summary>
        public int AvaliableGPA { get; set; }

        /// <summary>
        /// This is starting date and time for Semester and   in the database will be datetime2(0)
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// This is ending date and time for Semester and   in the database will be datetime2(0)
        /// </summary>
        public DateTime? EndDate { get; set; }


    }
}
