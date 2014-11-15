using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.PostRetrieving
{
    public class TopicModel
    {
        public IEnumerable<ActionSummaryItem> actions_summary { get; set; }
        public string archetype { get; set; }
        public bool archived { get; set; }
        public int category_id { get; set; }
        public bool closed { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? deleted_at { get; set; }
        public string deleted_by { get; set; }
        public TopicDetailsModel details { get; set; }
        public string draft { get; set; }
        public string draft_key { get; set; }
        public int draft_sequence { get; set; }
        public string fancy_title { get; set; }
        public bool has_summary { get; set; }
        public int highest_post_number { get; set; }
        public int id { get; set; }
        public DateTime last_posted_at { get; set; }
        public int last_read_post_number { get; set; }
        public int like_count { get; set; }
        public int participant_count { get; set; }
        public bool pinned { get; set; }
        public DateTime? pinned_at { get; set; }
        public bool pinned_globally { get; set; }
        public PostStreamModel post_stream { get; set; }
        public bool posted { get; set; }
        public int posts_count { get; set; }
        public int reply_count { get; set; }
        public string slug { get; set; }
        public bool starred { get; set; }
        public string title { get; set; }
        public bool? unpinned { get; set; }
        public int views { get; set; }
        public bool visible { get; set; }
        public int word_count { get; set; }
    }
}
