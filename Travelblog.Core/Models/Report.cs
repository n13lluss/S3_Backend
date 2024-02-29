namespace Travelblog.Core.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int Object_Type { get; set; }
        public int Object_Id { get; set; }
        public int Reported_Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int Status { get; set; }
        public User HandeledBy { get; set; }
    }
}
