using System;
using Abp.Notifications;
using RSCO.LoanManagement.Dto;

namespace RSCO.LoanManagement.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}