namespace Discoursistency.Base.Models.UserRetrieving
{
    /// <summary>
    /// A model representing user statistics in <see cref="UserSubmodel"/>
    /// </summary>
    public class UserStatsItemModel
    {
        public int action_type { get; set; }
        public int count { get; set; }
        public int? id { get; set; }
    }
}
