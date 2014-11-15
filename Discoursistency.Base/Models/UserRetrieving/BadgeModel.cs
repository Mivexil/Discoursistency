namespace Discoursistency.Base.Models.UserRetrieving
{
    /// <summary>
    /// A model representing badge data in <see cref="UserModel"/>
    /// </summary>
    public class BadgeModel
    {
        public bool allow_title { get; set; }
        public int badge_grouping_id { get; set; }
        public int badge_type_id { get; set; }
        public string description { get; set; }
        public bool enabled { get; set; }
        public int grant_count { get; set; }
        public string icon { get; set; }
        public int id { get; set; }
        public string image { get; set; }
        public bool listable { get; set; }
        public bool multiple_grant { get; set; }
        public string name { get; set; }
        public bool system { get; set; }
    }
}
