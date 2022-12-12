using V2_Final500W.Models;

namespace V2_Final500W.ViewModels
{
    public class RoomModel
    {
        public string Description { get; set; }
        public bool IsFree { get; set; }
        public int MaxNumberOfStudents { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
    }
}
