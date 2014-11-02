using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Retrieving
{
    public class PostModel
    {
        public IEnumerable<ActionSummaryItem> actions_summary { get; set; }
        public bool admin { get; set; }
        public string avatar_template { get; set; }
        public int avg_time { get; set; }
        public bool can_delete { get; set; }
        public bool can_edit { get; set; }
        public bool can_recover { get; set; }
        public bool can_view_edit_history { get; set; }
        public string cooked { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? deleted_at { get; set; }
        public string display_username { get; set; }
        public string edit_reason { get; set; }
        public bool hidden { get; set; }
        public int? hidden_reason_id { get; set; }
        public int id { get; set; }
        public int incoming_link_count { get; set; }
        public bool moderator { get; set; }
        public string name { get; set; }
        public int post_number { get; set; }
        public int post_type { get; set; }
        public string primary_group_name { get; set; }
        public int quote_count { get; set; }
        public string raw { get; set; }
        public bool? read { get; set; }
        public int reads { get; set; }
        public int reply_count { get; set; }
        public int? reply_to_post_number { get; set; }
        public Decimal score { get; set; }
        public bool staff { get; set; }
        public DateTime? topic_auto_close_at { get; set; }
        public int topic_id { get; set; }
        public string topic_slug { get; set; }
        public int trust_level { get; set; }
        public DateTime? updated_at { get; set; }
        public int uploaded_avatar_id { get; set; }
        public bool user_deleted { get; set; }
        public int user_id { get; set; }
        public string user_title { get; set; }
        public string username { get; set; }
        public int version { get; set; }
        public bool wiki { get; set; }
        public bool yours { get; set; }

    }
}
