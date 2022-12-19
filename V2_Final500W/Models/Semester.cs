namespace V2_Final500W.Models
{
    /// <summary>
    /// This is the model of Semester
    /// </summary>
    public class Semester
    {
        /// <summary>
        /// This is unique/serial Id number of Semester (Also PK for it's table)
        /// </summary>
        public int Id { get; set; }
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
}
