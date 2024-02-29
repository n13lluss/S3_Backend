namespace Travelblog.Dal.Entities;

public partial class TripTransport
{
    public int TripId { get; set; }

    public int TransportId { get; set; }

    public virtual Transport Transport { get; set; } = null!;

    public virtual Trip Trip { get; set; } = null!;
}
