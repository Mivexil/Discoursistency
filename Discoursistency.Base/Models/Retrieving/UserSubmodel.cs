using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Retrieving
{
    public class UserSubmodel
    {
        public bool admin { get; set; }
        public int? auto_track_topics_after_msecs { get; set; }
        public string avatar_template { get; set; }
        public int badge_count { get; set; }
        public string bio_cooked { get; set; }
        public string bio_excerpt { get; set; }
        public string bio_raw { get; set; }
        public bool can_edit { get; set; }
        public bool can_edit_email { get; set; }
        public bool can_edit_name { get; set; }
        public bool can_edit_username { get; set; }
        public bool can_send_private_message_to_user { get; set; }
        public BadgeModel card_badge { get; set; }
        public string card_image_badge { get; set; }
        public int? card_image_badge_id { get; set; }
        public DateTime created_at { get; set; }
        public int? custom_avatar_upload_id { get; set; }
        public dynamic custom_fields { get; set; }
        public IEnumerable<CustomGroupModel> custom_groups { get; set; }
        public int? digest_after_days { get; set; }
        public bool? disable_jump_reply { get; set; }
        public bool? dynamic_favicon { get; set; }
        public bool? edit_history_public { get; set; }
        public string email { get; set; }
        public bool? email_always { get; set; }
        public bool? email_digests { get; set; }
        public bool? email_direct { get; set; }
        public bool? email_private_messages { get; set; }
        public bool? enable_quoting { get; set; }
        public bool? external_links_in_new_tab { get; set; }
        public IEnumerable<int> featured_user_badge_ids { get; set; }
        public string gravatar_avatar_upload_id { get; set; }
        public bool? has_title_badges { get; set; }
        public int id { get; set; }
        public string invited_by { get; set; }
        public DateTime? last_posted_at { get; set; }
        public DateTime? last_seen_at { get; set; }
        public string locale { get; set; }
        public string location { get; set; }
        public bool? mailing_list_mode { get; set; }
        public bool moderator { get; set; }
        public IEnumerable<int> muted_category_ids { get; set; }
        public string name { get; set; }
        public int? new_topic_duration_minutes { get; set; }
        public int? notification_count { get; set; }
        public PrivateMessagesStatsModel private_messages_stats { get; set; }
        public string profile_background { get; set; }
        public IEnumerable<UserStatsItemModel> stats { get; set; }
        public string title { get; set; }
        public IEnumerable<int> tracked_category_ids { get; set; }
        public int trust_level { get; set; }
        public int uploaded_avatar_id { get; set; }
        public string username { get; set; }
        public IEnumerable<int> watched_category_ids { get; set; }
        public string website { get; set; }
 
    }
}
