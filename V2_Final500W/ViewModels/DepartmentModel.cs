using V2_Final500W.Models;

namespace V2_Final500W.ViewModels
{
    public class DepartmentModel
    {
        public string Name { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
