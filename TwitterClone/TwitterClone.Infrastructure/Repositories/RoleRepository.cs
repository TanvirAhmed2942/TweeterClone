using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private TwitterCloneDbContext _dbContext;
        public RoleRepository(TwitterCloneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRolePermission(RolePermissoin rolePermissoin)
        {
            _dbContext.RolePermissoins.Add(rolePermissoin);
            _dbContext.SaveChanges();
        }

        public List<Role> GetAllRoles()
        {
            return _dbContext.Roles.ToList();
        }

        public Role? GetRoleByRoleName(string name)
        {
            var role = _dbContext.Roles.SingleOrDefault(r => r.RoleName == name);
            return role;
        }
    }
}
