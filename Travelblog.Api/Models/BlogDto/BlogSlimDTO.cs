namespace Travelblog.Api.Models.BlogDto
{
    public class BlogSlimDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string User_Name { get; set; }
        public DateTime Posted_On { get; set; }
        public int likes { get; set; }
    }
}
