namespace TechnicalTest.Models;

public partial class DocumentType
{
    public byte Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}