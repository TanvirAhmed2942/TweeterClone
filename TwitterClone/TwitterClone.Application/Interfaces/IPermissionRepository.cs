using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IPermissionRepository
    {
        Permission? GetPermissionByName(string name);
    }
}
