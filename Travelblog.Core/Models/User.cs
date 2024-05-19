namespace Travelblog.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? IdString { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public bool Suspended { get; set; }
        public Preference? Preference { get; set; }
        public string? Role { get; set; }
    }
}
