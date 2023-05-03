using AtendanceMnagement.Models;

namespace AtendanceMnagement.DAO
{
    public class SubjectDAO
    {
        public int SubjectId { get; set; }
        public String? SubjectName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
