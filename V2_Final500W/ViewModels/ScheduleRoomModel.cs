using V2_Final500W.Models;
namespace V2_Final500W.ViewModels
{


    /// <summary>
    /// model of combined schedule and room 
    /// </summary>
    public class ScheduleRoomModel
    {

        

        /// <summary>
        /// This refers to particular schedule id from schedule table 
        /// </summary>
        public int? ScheduleId { get; set; }
        /// <summary>
        /// This refers to particular schedule 
        /// </summary>
        public int? RoomId { get; set; }

    }
}
