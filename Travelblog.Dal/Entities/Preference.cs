namespace Travelblog.Dal.Entities;

public partial class Preference
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? Theme { get; set; }

    public virtual User User { get; set; } = null!;
}
