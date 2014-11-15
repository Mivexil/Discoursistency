using System;

namespace Discoursistency.Base.Models.NotificationRetrieving
{
    /// <summary>
    /// A request for historical notifications for the user.
    /// </summary>
    public class NotificationHistoryRequest
    {
        public DateTime? before { get; set; }
        public string username { get; set; }
    }
}
