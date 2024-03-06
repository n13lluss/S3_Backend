using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Travelblog.Dal.Entities;

public partial class TripTransport
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int TripId { get; set; }

    public int TransportId { get; set; }

    public virtual Transport Transport { get; set; } = null!;

    public virtual Trip Trip { get; set; } = null!;
}
