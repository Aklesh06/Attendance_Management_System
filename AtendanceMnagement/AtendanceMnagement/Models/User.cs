using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace AtendanceMnagement.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int UserId { get; set; }
        public int RolesId { get; set; }
        public String UserName { get; set; }
        public String UserPassword { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Gender { get; set; }
        public String CurrentAddress { get; set; }
        public String PermanentAddress { get; set; }
        public String City { get; set; }
        public String Nationality { get; set; }
        public int PinCode { get; set; }
        public String Email { get; set; }
        public Int64 Phoneno { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Roles? Roles { get; set; }
    }
}
