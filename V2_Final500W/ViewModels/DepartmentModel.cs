using V2_Final500W.Models;

namespace V2_Final500W.ViewModels
{
    /// <summary>
    /// This is the model view of Department
    /// </summary>
    public class DepartmentModel
    {
        /// <summary>
        /// This is the name of the department
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This refers to the Semester class as an Object to be as property of department class
        /// </summary>
        public int? SemesterId { get; set; }
       // public Semester? Semester { get; set; }

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

    public class DepartmentModel2
    {
        /// <summary>
        /// This is the name of the department
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This refers to the Semester class as an Object to be as property of department class
        /// </summary>
        public int? SemesterId { get; set; }
        // public Semester? Semester { get; set; }

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
     //   public IEnumerable<Teacher>? Teachers { get; set; }

        /// <summary>
        /// //// this is list of the students in this particular department
        /// </summary>
      //  public IEnumerable<Student>? Students { get; set; }
    }
}
