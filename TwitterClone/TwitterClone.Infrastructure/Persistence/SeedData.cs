using TwitterClone.Domain.Constants;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static Role[] Roles()
        {
            return new Role[]
            {
                new Role(Guid.Parse("0de2e620-3b56-42db-ba52-62d1849234ea")){RoleName= RoleNames.Admin},
                new Role(Guid.Parse("5e74994f-5528-4cca-913b-b25d90e1dcf1")){RoleName = RoleNames.Moderator},
                new Role(Guid.Parse("b9d25054-8918-4131-bf18-a3cd86d1e85f")){RoleName = RoleNames.User}
            };
        }

        public static Permission[] Permissions()
        {
            return new Permission[]
            {
                new Permission(Guid.Parse("0de2e620-3b56-42db-ba52-62d184923401")){PermissionName = PermissionNames.UsersRead},
                new Permission(Guid.Parse("5e74994f-5528-4cca-913b-b25d90e1dc02")){PermissionName = PermissionNames.RolesManage},
                new Permission(Guid.Parse("b9d25054-8918-4131-bf18-a3cd86d1e803")){PermissionName = PermissionNames.UsersDelete}
            };
        }

        public static RolePermissoin[] RolePermissoins()
        {
            return new RolePermissoin[]
            {
                new RolePermissoin(Guid.Parse("b9d25054-8918-4131-bf18-a3cd86d1e501")){RoleId = Guid.Parse("0de2e620-3b56-42db-ba52-62d1849234ea"),PermissionId = Guid.Parse("0de2e620-3b56-42db-ba52-62d184923401")},
                new RolePermissoin(Guid.Parse("b9d25054-8918-4131-bf18-a3cd86d1e502")){RoleId = Guid.Parse("0de2e620-3b56-42db-ba52-62d1849234ea"),PermissionId = Guid.Parse("5e74994f-5528-4cca-913b-b25d90e1dc02")},
                new RolePermissoin(Guid.Parse("b9d25054-8918-4131-bf18-a3cd86d1e503")){RoleId = Guid.Parse("0de2e620-3b56-42db-ba52-62d1849234ea"),PermissionId = Guid.Parse("b9d25054-8918-4131-bf18-a3cd86d1e803")},


                new RolePermissoin(Guid.Parse("b9d25054-8918-4131-bf18-a3cd86d1e601")){RoleId = Guid.Parse("5e74994f-5528-4cca-913b-b25d90e1dcf1"),PermissionId = Guid.Parse("0de2e620-3b56-42db-ba52-62d184923401")},
                new RolePermissoin(Guid.Parse("b9d25054-8918-4131-bf18-a3cd86d1e602")){RoleId = Guid.Parse("5e74994f-5528-4cca-913b-b25d90e1dcf1"),PermissionId = Guid.Parse("5e74994f-5528-4cca-913b-b25d90e1dc02")},


            };

        }
    }
}
