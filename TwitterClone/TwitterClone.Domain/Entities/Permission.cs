namespace TwitterClone.Domain.Entities
{
    public class Permission : BaseEntity
    {
        public Permission(Guid id) : base(id)
        {
        }

        public required string PermissionName { get; set; }

        public List<RolePermissoin> RolePermissoins { get; set; } = new List<RolePermissoin>();
    }
}
