namespace TwitterClone.Domain.Entities
{
    public class RolePermissoin : BaseEntity
    {
        public RolePermissoin(Guid id) : base(id)
        {
        }

        public required Guid RoleId { get; set; }
        public required Guid PermissionId { get; set; }

        public Role? Role { get; set; }
        public Permission? Permission { get; set; }

    }
}
