namespace Permit.Domain.Entities
{
    public class PermitType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public ICollection<Permit>? Permits { get; set; }
    }
}