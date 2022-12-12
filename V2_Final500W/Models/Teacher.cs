namespace V2_Final500W.Models
{
    /// <summary>
    /// This is the model of Teacher
    /// </summary>

    public class Teacher
        {
        /// <summary>
        /// This is unique/serial Id number of Teacher (Also PK for it's table)
        /// </summary>
        public int Id { get; set; }

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
        public Subject? Subject { get; set; }


        /// <summary>
        /// This is particular Department id from Department table where this particular Teacher is teaching
        /// </summary>
        public int? DepartmentId { get; set; }
        /// <summary>
        /// This is particular Department where this particular Teacher is teaching
        /// </summary>
        public Department? Department { get; set; }

        /// <summary>
        /// This is particular address id from address table where this particular teacher is living or teaching
        /// </summary>
        public int? AddressId { get; set; }
        /// <summary>
        /// This is particular address  where this particular teacher is living or teaching
        /// </summary>
        public Address? Address { get; set; }

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


