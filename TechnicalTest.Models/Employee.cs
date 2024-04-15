namespace TechnicalTest.Models;

public partial class Employee
{
    public Guid Id { get; set; }

    public byte DocumentTypeId { get; set; }

    public string DocumentNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Guid? LeaderId { get; set; }

    public byte AreaId { get; set; }

    public byte RolId { get; set; }

    public virtual Area Area { get; set; } = null!;

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual ICollection<ExtraHour> ExtraHours { get; set; } = new List<ExtraHour>();

    public virtual ICollection<Employee> InverseLeader { get; set; } = new List<Employee>();

    public virtual Employee? Leader { get; set; }

    public virtual Role Rol { get; set; } = null!;
}