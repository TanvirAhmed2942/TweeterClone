using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public sealed class SystemNotification : Notification
    {
        public SystemNotification() : base( NotificationType.System)
        {

        }

        public void AddMessage(string message)
        {
            SetMessage("New Version Available", false);
        }

        public override string GetMessage()
        {
            return $"A new version of the application is available.";
        }

        public override string DescribeRecord()
        {
            return base.DescribeRecord();

        }
    }
}
