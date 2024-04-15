namespace TechnicalTest.Models;

public partial class RejectedExtraHour
{
    public Guid Id { get; set; }

    public Guid ExtraHourId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ExtraHour ExtraHour { get; set; } = null!;
}