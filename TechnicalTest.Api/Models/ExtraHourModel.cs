namespace TechnicalTest.Api.Models
{
    public class ExtraHourModel
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public DateOnly Date { get; set; }

        public byte Hours { get; set; }

        public string Description { get; set; } = null!;

        public bool? LeaderApproval { get; set; }

        public bool? HumanResourcesApproval { get; set; }

        public bool? ManagerApproval { get; set; }
    }
}
