using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public interface IShareable
    {
        bool CanBeShared(Guid userId);
    }
}
