using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Travelblog.Dal.Entities;

public partial class TripDuration
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int TripId { get; set; }

    public int DurationId { get; set; }

    public virtual Duration Duration { get; set; } = null!;

    public virtual Trip Trip { get; set; } = null!;
}
