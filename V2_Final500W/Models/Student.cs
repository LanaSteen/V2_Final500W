namespace V2_Final500W.Models
{
    /// <summary>
    /// This is the model of Student
    /// </summary>
    public class Student
    {
        /// <summary>
        /// This is unique/serial Id number of Student (Also PK for it's table)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// This is firstname of student
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// This is particular Department id from Department table where this particular student is studing
        /// </summary>
        public int? DepartmentId { get; set; }
        /// <summary>
        /// This is particular Department where this particular student is studing
        /// </summary>
        public Department? Department { get; set; }


        /// <summary>
        /// This is particular address id from address table where this particular student is living or studing
        /// </summary>
        public int? AddressId { get; set; }

        /// <summary>
        /// This is particular address  where this particular student is living or studing
        /// </summary>
        public Address? Address { get; set; }

        /// <summary>
        /// This is particular semester id from semster table in which semester this particular student is studing
        /// </summary>
        public int? SemesterId { get; set; }
        /// <summary>
        /// This is particular semester in which this particular student is studing
        /// </summary>
        public Semester? Semester { get; set; }

        /// <summary>
        /// This is lastname of student
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// This is personal identification number of student
        /// </summary>
        public string PersonalId { get; set; }
        /// <summary>
        /// This is the year when student started studing. pattern is "2022"
        /// </summary>
      
        //public int _startYear;
        public int StartYear { get; set; }
        //{
        //    get { return _startYear; }
        //    set
        //    {
        //        int year = DateTime.Parse(value).Year;
        //        _startYear = $"{year}";
        //    }
        //}
        /// <summary>
        /// This is the list of subjects which student is studing
        /// </summary>
        public IEnumerable<StudentSubject>? StudentSubject { get; set; }
    }
}
