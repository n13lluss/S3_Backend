using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travelblog.Dal.Entities;

public partial class BlogCountry
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int BlogId { get; set; }

    public int CountryId { get; set; }

    public virtual Blog Blog { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;
}
