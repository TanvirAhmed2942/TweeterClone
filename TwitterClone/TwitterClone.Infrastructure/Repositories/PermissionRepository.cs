using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;


namespace TwitterClone.Infrastructure.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private TwitterCloneDbContext _dbContext;



        public PermissionRepository(TwitterCloneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Permission? GetPermissionByName(string name)
        {
            var permissions = _dbContext.Permissions.SingleOrDefault(p => p.PermissionName == name);
            return permissions;
        }


    }
}
