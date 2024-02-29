namespace Travelblog.Dal.Entities;

public partial class Reaction
{
    public int Id { get; set; }

    public string Message { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime PostDate { get; set; }

    public bool Prive { get; set; }

    public bool Suspended { get; set; }

    public bool Deleted { get; set; }

    public virtual User User { get; set; } = null!;
}
