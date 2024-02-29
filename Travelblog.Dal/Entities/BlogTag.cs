namespace Travelblog.Dal.Entities;

public partial class BlogTag
{
    public int BlogId { get; set; }

    public int TagId { get; set; }

    public virtual Blog Blog { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
