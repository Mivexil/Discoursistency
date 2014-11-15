namespace Discoursistency.Base.Models.NotificationRetrieving
{
    /// <summary>
    /// A model for notification details in <see cref="NotificationModel"/>
    /// </summary>
    public class NotificationData
    {
        public int? badge_id { get; set; }
        public string badge_name { get; set; }
        public string display_username { get; set; }
        public int? original_post_id { get; set; }
        public string original_username { get; set; }
        public string topic_title { get; set; }
    }
}
