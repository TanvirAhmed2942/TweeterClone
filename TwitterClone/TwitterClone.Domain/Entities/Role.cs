namespace TwitterClone.Domain.Entities
{
    public class Role : BaseEntity
    {
        public Role(Guid id) : base(id)
        {
        }

        public required string RoleName { get; set; }

        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public List<RolePermissoin> RolePermissoins { get; set; } = new List<RolePermissoin>();
    }
}
