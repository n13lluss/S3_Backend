namespace Travelblog.Dal.Entities;

public partial class Trip
{
    public int Id { get; set; }

    public int CreatorId { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public int Likes { get; set; }

    public string Type { get; set; } = null!;

    public DateTime PostedOn { get; set; }

    public bool Prive { get; set; }

    public bool Suspended { get; set; }

    public bool Deleted { get; set; }

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual User Creator { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
