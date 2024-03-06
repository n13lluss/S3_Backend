using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Travelblog.Dal.Entities;

public partial class TripBudget
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int TripId { get; set; }

    public int BudgetId { get; set; }

    public virtual Budget Budget { get; set; } = null!;

    public virtual Trip Trip { get; set; } = null!;
}
