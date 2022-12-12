namespace V2_Final500W.Models
{
    /// <summary>
    /// This is the model of StudentSubject
    /// </summary>
    public class StudentSubject
    {
        /// <summary>
        /// This is unique/serial Id number of StudentSubject (Also PK for it's table)
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// This is particular Subject id from Subject table for this particular student 
        /// </summary>
        public int? SubjectId { get; set; }
        /// <summary>
        /// This is particular Subject  for this particular student 
        /// </summary>
        public Subject? Subject { get; set; }


        /// <summary>
        /// This is particular student id from student table for this particular subject 
        /// </summary>
        public int? StudentId { get; set; }
        /// <summary>
        /// This is particular Student  for this particular Subject 
        /// </summary>
        public Student? Student { get; set; }

        /// <summary>
        /// This is amount of points of particular student in this particular subject
        /// </summary>

        public int Point { get; set; }



    }
}
