using System;

namespace Discoursistency.Base.Models.NotificationRetrieving
{
    /// <summary>
    /// A model for a notification.
    /// </summary>
    public class NotificationModel
    {
        public DateTime created_at { get; set; }
        public NotificationData data { get; set; }
        public int notification_type { get; set; }
        public int? post_number { get; set; }
        public bool read { get; set; }
        public string slug { get; set; }
        public int? topic_id { get; set; }
    }
}
