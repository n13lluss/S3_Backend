namespace Travelblog.Dal.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool Deleted { get; set; }

    public bool Suspended { get; set; }

    public string Role { get; set; } = null!;

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<Preference> Preferences { get; set; } = new List<Preference>();

    public virtual ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();

    public virtual ICollection<Report> ReportReporters { get; set; } = new List<Report>();

    public virtual ICollection<Report> ReportResolvers { get; set; } = new List<Report>();

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
