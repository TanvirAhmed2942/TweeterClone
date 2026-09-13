using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public interface INotifiable
    {
       
          void AddNotification(Guid notificationId);
        
    }
}
