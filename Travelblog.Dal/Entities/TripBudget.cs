namespace Travelblog.Dal.Entities;

public partial class TripBudget
{
    public int TripId { get; set; }

    public int BudgetId { get; set; }

    public virtual Budget Budget { get; set; } = null!;

    public virtual Trip Trip { get; set; } = null!;
}
