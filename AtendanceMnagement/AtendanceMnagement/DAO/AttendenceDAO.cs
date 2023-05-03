namespace AtendanceMnagement.DAO
{
    public class AttendenceDAO
    {
        public int AttendenceId { get; set; }
        public int SubjectId { get; set; }
        public int UserId { get; set; }
        public DateTime AttendenceDate { get; set; }
        public bool IsPresent { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
