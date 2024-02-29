namespace Travelblog.Core.Models
{
    public class Reaction
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string User_Name { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
