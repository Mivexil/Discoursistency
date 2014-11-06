using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Retrieving
{
    public class UserModel
    {
        public IEnumerable<BadgeTypeModel> badge_types { get; set; }
        public IEnumerable<BadgeModel> badges { get; set; }
        public UserSubmodel user { get; set; }
        public IEnumerable<UserBadgeModel> user_badges { get; set; }
        public IEnumerable<SmallUserModel> users { get; set; } 
    }
}
