namespace Travelblog.Dal.Entities;

public partial class ReactionLike
{
    public int ReactionId { get; set; }

    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public bool Status { get; set; }

    public virtual Reaction Reaction { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
