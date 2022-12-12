namespace V2_Final500W.Models
{
    /// <summary>
    /// This is the model of Balance. And it refers to students account balance
    /// </summary>
    public class Balance
    {
        /// <summary>
        /// This is unique/serial Id number of Balance (Also PK for this table)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// This value is about how much momney is on particular student's account in one particular semester
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// This refers to particular student (who owns this account) id from students table 
        /// </summary>
        public int? StudentId { get; set; }
        /// <summary>
        /// This refers to particular student who owns this account 
        /// </summary>
        public Student? Student { get; set; }

        /// <summary>
        /// This refers to particular semester's id from semester table
        /// </summary>
        public int? SemesterId { get; set; }

        /// <summary>
        /// This refers to particular semester
        /// </summary>
        public Semester? Semester { get; set; }

        /// <summary>
        /// This value is about how much debth is on particular students account in one particular semester
        /// </summary>
        public decimal Debth { get; set; }

    }
}
