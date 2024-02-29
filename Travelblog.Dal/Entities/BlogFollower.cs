namespace Travelblog.Dal.Entities;

public partial class BlogFollower
{
    public int FollowerId { get; set; }

    public int BlogId { get; set; }

    public virtual Blog Blog { get; set; } = null!;

    public virtual User Follower { get; set; } = null!;
}
