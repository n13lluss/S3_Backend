namespace Travelblog.Dal.Entities;

public partial class TripDuration
{
    public int TripId { get; set; }

    public int DurationId { get; set; }

    public virtual Duration Duration { get; set; } = null!;

    public virtual Trip Trip { get; set; } = null!;
}
