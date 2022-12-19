using V2_Final500W.Models;

namespace V2_Final500W.ViewModels
{
    /// <summary>
    /// This is the model view of Balance
    /// </summary>
    public class BalanceModel
    {

        /// <summary>
        /// This value is about how much momney is on particular student's account in one particular semester
        /// </summary>
        public decimal Amount { get; set; }

        public int? StudentId { get; set; }
        /// <summary>
        /// This refers to particular student who owns this account 
        /// </summary>
        // public Student? Student { get; set; }
        public int? SemesterId { get; set; }
        /// <summary>
        /// This refers to particular semester
        /// </summary>
       // public Semester? Semester { get; set; }

        /// <summary>
        /// This value is about how much debth is on particular students account in one particular semester
        /// </summary>
        public decimal? Debth { get; set; }
    }
}
