using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Retrieving
{
    public class UserBadgeModel
    {
        public int badge_id { get; set; }
        public DateTime granted_at { get; set; }
        public int granted_by_id { get; set; }
        public int id { get; set; }
        public int user_id { get; set; }
    }
}
