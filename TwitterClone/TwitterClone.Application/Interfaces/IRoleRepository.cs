using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IRoleRepository
    {
        Role? GetRoleByRoleName(string name);
        List<Role> GetAllRoles();

        void AddRolePermission(RolePermissoin rolePermissoin);
    }
}
