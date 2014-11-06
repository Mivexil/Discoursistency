using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Retrieving
{
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
