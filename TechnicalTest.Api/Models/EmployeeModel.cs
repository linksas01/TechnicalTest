namespace TechnicalTest.Api.Models
{
    public class EmployeeModel
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
    }
}
