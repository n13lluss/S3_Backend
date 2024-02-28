namespace Travelblog.Dal.Entities;

public partial class Post
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime PostedOn { get; set; }

    public bool Prive { get; set; }

    public bool Suspended { get; set; }

    public bool Deleted { get; set; }

    public int TripId { get; set; }

    public virtual Trip Trip { get; set; } = null!;
}
