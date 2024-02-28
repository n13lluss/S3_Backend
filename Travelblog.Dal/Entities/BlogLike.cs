namespace Travelblog.Dal.Entities;

public partial class BlogLike
{
    public int BlogId { get; set; }

    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public bool Status { get; set; }

    public virtual Blog Blog { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
