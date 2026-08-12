using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public sealed class SystemNotification : Notification
    {
        public SystemNotification() : base(Guid.NewGuid(), NotificationType.System)
        {

        }

        public void AddMessage(string message)
        {
            SetMessage("New Version Available", false);
        }

        public override string DescribeRecord()
        {
            return base.DescribeRecord();

        }
    }
}
