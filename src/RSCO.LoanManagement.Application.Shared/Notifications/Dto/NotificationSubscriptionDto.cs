using System.ComponentModel.DataAnnotations;
using Abp.Notifications;

namespace RSCO.LoanManagement.Notifications.Dto
{
    public class NotificationSubscriptionDto
    {
        [Required]
        [MaxLength(NotificationInfo.MaxNotificationNameLength)]
        public string Name { get; set; }

        public bool IsSubscribed { get; set; }
    }
}