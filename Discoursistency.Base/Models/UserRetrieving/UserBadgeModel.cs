using System;

namespace Discoursistency.Base.Models.UserRetrieving
{
    /// <summary>
    /// A model representing a badge owned by the user in <see cref="UserModel"/>
    /// </summary>
    public class UserBadgeModel
    {
        public int badge_id { get; set; }
        public DateTime granted_at { get; set; }
        public int granted_by_id { get; set; }
        public int id { get; set; }
        public int user_id { get; set; }
    }
}
