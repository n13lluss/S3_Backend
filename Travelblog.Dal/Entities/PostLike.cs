namespace Travelblog.Dal.Entities;

public partial class PostLike
{
    public int PostId { get; set; }

    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public bool Status { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
