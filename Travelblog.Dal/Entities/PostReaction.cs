using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Travelblog.Dal.Entities;

public partial class PostReaction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int PostId { get; set; }

    public int ReactionId { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual Reaction Reaction { get; set; } = null!;
}
