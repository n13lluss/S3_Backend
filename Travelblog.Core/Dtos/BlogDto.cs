namespace Travelblog.Core.Dtos
{
    public class BlogDto
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int Likes { get; set; }
        public bool IsPrive { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsDeleted { get; set; }
    }
}
