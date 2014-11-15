using System.Collections.Generic;

namespace Discoursistency.Base.Models.UserRetrieving
{
    /// <summary>
    /// A model representing user data.
    /// </summary>
    public class UserModel
    {
        public IEnumerable<BadgeTypeModel> badge_types { get; set; }
        public IEnumerable<BadgeModel> badges { get; set; }
        public UserSubmodel user { get; set; }
        public IEnumerable<UserBadgeModel> user_badges { get; set; }
        public IEnumerable<SmallUserModel> users { get; set; } 
    }
}
