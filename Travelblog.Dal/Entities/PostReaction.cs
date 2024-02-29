namespace Travelblog.Dal.Entities;

public partial class PostReaction
{
    public int PostId { get; set; }

    public int ReactionId { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual Reaction Reaction { get; set; } = null!;
}
