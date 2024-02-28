namespace Travelblog.Dal.Entities;

public partial class BlogCountry
{
    public int BlogId { get; set; }

    public int CountryId { get; set; }

    public virtual Blog Blog { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;
}
