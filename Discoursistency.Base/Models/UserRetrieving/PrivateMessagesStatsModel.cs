namespace Discoursistency.Base.Models.UserRetrieving
{
    /// <summary>
    /// A model representing private message statistics in <see cref="UserSubmodel"/>
    /// </summary>
    public class PrivateMessagesStatsModel
    {
        public int all { get; set; }
        public int mine { get; set; }
        public int unread { get; set; }
    }
}
