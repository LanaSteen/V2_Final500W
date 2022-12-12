namespace V2_Final500W.Models
{
    /// <summary>
    /// This is the model of Department
    /// </summary>
    public class Department
    {
        /// <summary>
        /// This is unique/serial Id number of departmeent (Also PK for this table)
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// This is the name of the department
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This refers to the Semester class PK. It is about - In which semester this particular department has taken part in
        /// </summary>
        public int? SemesterId { get; set; }

        /// <summary>
        /// This refers to the Semester class as an Object to be as property of department class
        /// </summary>
        public Semester? Semester { get; set; }


        /// <summary>
        /// This refers about - What is the maximum number of the students who be part of this particular department
        /// </summary>
        public int MaxNumberOfStudents { get; set; }

        /// <summary>
        /// This refers about - What is the number of the students who are already part of this particular department
        /// </summary>
        public int CurrentAmount { get; set; }


        /// <summary>
        /// //// this is list of the teachers in this particular department
        /// </summary>
        public IEnumerable<Teacher>? Teachers { get; set; }

        /// <summary>
        /// //// this is list of the students in this particular department
        /// </summary>
        public IEnumerable<Student>? Students { get; set; }

    }
}
