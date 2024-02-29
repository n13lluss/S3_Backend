namespace Travelblog.Dal.Entities;

public partial class TripTag
{
    public int TripId { get; set; }

    public int TagId { get; set; }

    public virtual Tag Tag { get; set; } = null!;

    public virtual Trip Trip { get; set; } = null!;
}
