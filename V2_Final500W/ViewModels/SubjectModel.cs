using V2_Final500W.Models;

namespace V2_Final500W.ViewModels
{
    public class SubjectModel
    {
        public int Credit { get; set; }
        public string Name { get; set; }
        public int LowerBound { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
    }
}
