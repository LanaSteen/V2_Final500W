using V2_Final500W.Models;

namespace V2_Final500W.ViewModels
{
    public class SemesterModel
    {
        public string Name { get; set; }
        public int AvaliableGPA { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
