namespace AtendanceMnagement.DAO
{
    public class TopicDAO
    {
        public int TopicId { get; set; }
        public int TeacherId { get; set; }
        public String? Notes { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
