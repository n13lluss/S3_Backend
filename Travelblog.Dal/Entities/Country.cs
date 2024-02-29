namespace Travelblog.Dal.Entities;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Continent { get; set; } = null!;
}
