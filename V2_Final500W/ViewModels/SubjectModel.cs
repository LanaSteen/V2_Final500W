using V2_Final500W.Models;

namespace V2_Final500W.ViewModels
{
    /// <summary>
    /// This is the model view of Subject
    /// </summary>
    public class SubjectModel
    {
        /// <summary>
        /// This refers how much credit this subject has
        /// </summary>
        public int Credit { get; set; }
        /// <summary>
        /// This is Name of subject
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// This is lowest bound of subject
        /// </summary>
        public int LowerBound { get; set; }
        /// <summary>
        /// This is maximum number of students avalible on the particular subject
        /// </summary>
        public int MaxNumberOfStudents { get; set; }
        /// <summary>
        /// This is maximum number of teachers avalible on the particular subject
        /// </summary>
        public int MaxNumberOfTeachers { get; set; }

        /// <summary>
        /// List of teachers on this particular subject 
        /// </summary>
        public IEnumerable<Teacher>? Teachers { get; set; }
        /// <summary>
        /// List of Schedules with this Subject 
        /// </summary>
        public IEnumerable<ScheduleSubject>? ScheduleSubject { get; set; }

        /// <summary>
        /// This is the list of subjects which student is studing
        /// </summary>
        public IEnumerable<StudentSubject>? StudentSubject { get; set; }
    }

    public class SubjectModel2
    {
        /// <summary>
        /// This refers how much credit this subject has
        /// </summary>
        public int Credit { get; set; }
        /// <summary>
        /// This is Name of subject
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// This is lowest bound of subject
        /// </summary>
        public int LowerBound { get; set; }
        /// <summary>
        /// This is maximum number of students avalible on the particular subject
        /// </summary>
        public int MaxNumberOfStudents { get; set; }
        /// <summary>
        /// This is maximum number of teachers avalible on the particular subject
        /// </summary>
        public int MaxNumberOfTeachers { get; set; }


    }
}
