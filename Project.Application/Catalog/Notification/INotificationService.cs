using Project.ViewModels.Catalog.Noftication;
using Project.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Catalog.Notification
{
    public interface INotificationService
    {
        Task<bool> CreateNewNotification(AddNotificationRequest request);
        Task<ResultModel<NotificationViewModel>> GetNotificationPaging(Guid user, GetNotificationPagingRequest request);
    }
}
