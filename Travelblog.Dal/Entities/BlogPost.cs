namespace Travelblog.Dal.Entities;

public partial class BlogPost
{
    public int BlogId { get; set; }

    public int PostId { get; set; }

    public virtual Blog Blog { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;
}
