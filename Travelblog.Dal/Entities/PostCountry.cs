namespace Travelblog.Dal.Entities;

public partial class PostCountry
{
    public int PostId { get; set; }

    public int CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;
}
