namespace TechnicalTest.Models;

public partial class ExtraHour
{
    public Guid Id { get; set; }

    public Guid EmployeeId { get; set; }

    public DateOnly Date { get; set; }

    public byte Hours { get; set; }

    public string Description { get; set; } = null!;

    public bool? LeaderApproval { get; set; }

    public bool? HumanResourcesApproval { get; set; }

    public bool? ManagerApproval { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<RejectedExtraHour> RejectedExtraHours { get; set; } = new List<RejectedExtraHour>();
}