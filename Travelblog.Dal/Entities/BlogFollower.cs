using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Travelblog.Dal.Entities;

public partial class BlogFollower
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int FollowerId { get; set; }

    public int BlogId { get; set; }

    public virtual Blog Blog { get; set; } = null!;

    public virtual User Follower { get; set; } = null!;
}
