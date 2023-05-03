using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtendanceMnagement.Models
{
    public class Attendence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendenceId { get; set; }
        public int SubjectId { get; set; }
        public int UserId { get; set; }
        public DateTime AttendenceDate { get; set; }
        public bool IsPresent { get; set; }        
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Subject? Subject { get; set; }
        public User? User { get; set; }
    }
}
