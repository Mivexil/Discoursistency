using System.Collections.Generic;
using System.Threading.Tasks;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.NotificationRetrieving;

namespace Discoursistency.Base.NotificationRetrieving
{
    public interface IBaseNotificationRetrievalService
    {
        Task<IEnumerable<NotificationModel>> GetNotifications(AuthenticationData authData);
        Task<IEnumerable<NotificationModel>> GetNotificationHistory(AuthenticationData authData,
            NotificationHistoryRequest historyData);
    }
}