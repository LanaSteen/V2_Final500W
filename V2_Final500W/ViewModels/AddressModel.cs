using V2_Final500W.Models;

namespace V2_Final500W.ViewModels
{
    public class AddressModel
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
    }
}
