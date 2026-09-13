using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public interface ICommentable
    {
        bool CanBeCommented(Guid userId, string comment);
    }
}
