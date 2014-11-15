using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.PostRetrieving
{
    public class TopicDetailsModel
    {
        public DateTime? auto_close_at { get; set; }
        public bool auto_close_based_on_last_post { get; set; }
        public int? auto_close_hours { get; set; }
        public bool can_edit { get; set; }
        public bool can_flag_topic { get; set; }
        public bool can_reply_as_new_topic { get; set; }
        public UserRetrieving.SmallUserModel created_by { get; set; }
        public UserRetrieving.SmallUserModel last_poster { get; set; }
        public IEnumerable<ThreadLinkModel> links { get; set; }
        public int notification_level { get; set; }
        public int notifications_reason_id { get; set; }
        public IEnumerable<UserRetrieving.SmallUserModel> participants { get; set; }
        public IEnumerable<SmallTopicModel> suggested_topics { get; set; } 
 
    }
}
