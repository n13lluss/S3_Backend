namespace Travelblog.Dal.Entities;

public partial class TripCountry
{
    public int TripId { get; set; }

    public int CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual Trip Trip { get; set; } = null!;
}
