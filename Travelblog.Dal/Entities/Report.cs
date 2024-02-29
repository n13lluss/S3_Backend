namespace Travelblog.Dal.Entities;

public partial class Report
{
    public int Id { get; set; }

    public int ObjectType { get; set; }

    public int ObjectId { get; set; }

    public int ReporterId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }

    public int Status { get; set; }

    public int? ResolverId { get; set; }

    public virtual User Reporter { get; set; } = null!;

    public virtual User? Resolver { get; set; }
}
