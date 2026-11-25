namespace TwitterClone.Domain.Entities
{
    public class UserRole : BaseEntity
    {

        public UserRole(Guid id) : base(id)
        {
        }

        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public required User User { get; set; }
        public required Role Role { get; set; }
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    }
}
