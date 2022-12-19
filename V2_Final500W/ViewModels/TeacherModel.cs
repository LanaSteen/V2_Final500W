using V2_Final500W.Models;

namespace V2_Final500W.ViewModels
{
    /// <summary>
    /// This is the model view of Teacher
    /// </summary>
    public class TeacherModel
    {
        /// <summary>
        /// This is firstname of Teacher
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// This is particular Subject id from Subject table what this particular Teacher is teaching
        /// </summary>
        public int? SubjectId { get; set; }

        /// <summary>
        /// This is particular Subject what this particular Teacher is teaching
        /// </summary>
      //  public Subject? Subject { get; set; }

        /// <summary>
        /// This is particular Department id from Department table where this particular Teacher is teaching
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// This is particular Department where this particular Teacher is teaching
        /// </summary>
     //  public Department? Department { get; set; }

        /// <summary>
        /// This is particular address id from address table where this particular teacher is living or teaching
        /// </summary>
        public int? AddressId { get; set; }

        /// <summary>
        /// This is particular address  where this particular teacher is living or teaching
        /// </summary>
    //   public Address? Address { get; set; }

        /// <summary>
        /// This is lastname of teacher
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// This is personal identification number of teacher
        /// </summary>
        public string PersonalId { get; set; }
    }

    /// <summary>
    /// This is the model2 view of Teacher
    /// </summary>
    public class TeacherModel2
    {
        /// <summary>
        /// This is firstname of Teacher
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// This is particular Subject id from Subject table what this particular Teacher is teaching
        /// </summary>
        public int? SubjectId { get; set; }



        /// <summary>
        /// This is particular Department id from Department table where this particular Teacher is teaching
        /// </summary>
        public int? DepartmentId { get; set; }



        /// <summary>
        /// This is particular address id from address table where this particular teacher is living or teaching
        /// </summary>
        public int? AddressId { get; set; }


        /// <summary>
        /// This is lastname of teacher
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// This is personal identification number of teacher
        /// </summary>
        public string PersonalId { get; set; }
    }
}
