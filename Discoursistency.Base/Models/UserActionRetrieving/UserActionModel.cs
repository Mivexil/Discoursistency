using System;

namespace Discoursistency.Base.Models.UserActionRetrieving
{
    /// <summary>
    /// A model representing an action taken by an user.
    /// </summary>
    public class UserActionModel
    {
        public string acting_avatar_template { get; set; }
        public string acting_name { get; set; }
        public int? acting_uploaded_avatar_id { get; set; }
        public int acting_user_id { get; set; }
        public string acting_username { get; set; }
        public int action_type { get; set; }
        public string avatar_template { get; set; }
        public int category_id { get; set; }
        public DateTime created_at { get; set; }
        public bool deleted { get; set; }
        public string excerpt { get; set; }
        public bool? hidden { get; set; }
        public bool moderator_action { get; set; }
        public string name { get; set; }
        public int? post_id { get; set; }
        public int post_number { get; set; }
        public int? reply_to_post_number { get; set; }
        public string slug { get; set; }
        public string target_name { get; set; }
        public int target_user_id { get; set; }
        public string target_username { get; set; }
        public string title { get; set; }
        public int topic_id { get; set; }
        public int? uploaded_avatar_id { get; set; }
        public int user_id { get; set; }
        public string username { get; set; }
    }
}
