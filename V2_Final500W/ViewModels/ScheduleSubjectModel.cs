

using V2_Final500W.Models;
namespace V2_Final500W.ViewModels
{


    /// <summary>
    /// model of combined schedule and subject 
    /// </summary>
    public class ScheduleSubjectModel
    {

        /// <summary>
        /// This refers to particular schedule id from schedule table 
        /// </summary>
        public int? ScheduleId { get; set; }
        /// <summary>
        /// This refers to particular subject id from subject table
        /// </summary>
        public int? SubjectId { get; set; }

    }
}
