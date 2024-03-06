using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Travelblog.Dal.Entities;

public partial class ReactionLike
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int ReactionId { get; set; }

    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public bool Status { get; set; }

    public virtual Reaction Reaction { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
