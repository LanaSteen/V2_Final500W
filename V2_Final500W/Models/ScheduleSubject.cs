namespace V2_Final500W.Models
{
    /// <summary>
    /// model of combined schedule and subject 
    /// </summary>
    public class ScheduleSubject
    {
        /// <summary>
        /// This is unique/serial Id number of ScheduleSubject (Also PK for it's table)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// This refers to particular schedule id from schedule table 
        /// </summary>
        public int? ScheduleId { get; set; }
        /// <summary>
        /// This refers to particular schedule 
        /// </summary>
        public Schedule? Schedule { get; set; }

        /// <summary>
        /// This refers to particular Subject id from schedule table 
        /// </summary>
        public int? SubjectId { get; set; }

        /// <summary>
        /// This refers to particular Subject  
        /// </summary>
        public Subject? Subject { get; set; }    
    }
}
