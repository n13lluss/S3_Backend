namespace Travelblog.Dal.Entities;

public partial class Blog
{
    public int Id { get; set; }

    public int CreatorId { get; set; }

    public string Name { get; set; } = null!;
    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public int Likes { get; set; }

    public bool Prive { get; set; }

    public bool Suspended { get; set; }

    public bool Deleted { get; set; }

    public int? TripId { get; set; }

    public virtual User Creator { get; set; } = null!;

    public virtual Trip? Trip { get; set; }
}
