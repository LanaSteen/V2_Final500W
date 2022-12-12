using V2_Final500W.Models;

namespace V2_Final500W.ViewModels
{
    public class StudentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public int StartYear { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
    }
}
