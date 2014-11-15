using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.PostRetrieving
{
    public class SmallTopicModel
    {
        public string archetype { get; set; }
        public bool archived { get; set; }
        public bool bumped { get; set; }
        public DateTime bumped_at { get; set; }
        public int category_id { get; set; }
        public bool closed { get; set; }
        public DateTime created_at { get; set; }
        public string excerpt { get; set; }
        public string fancy_title { get; set; }
        public bool? has_summary { get; set; }
        public int highest_post_number { get; set; }
        public int id { get; set; }
        public string image_url { get; set; }
        public DateTime last_posted_at { get; set; }
        public string last_poster_username { get; set; }
        public int last_read_post_number { get; set; }
        public int like_count { get; set; }
        public int new_posts { get; set; }
        public int notification_level { get; set; }
        public bool pinned { get; set; }
        public IEnumerable<UserRetrieving.PosterModel> posters { get; set; }
        public int posts_count { get; set; }
        public int reply_count { get; set; }
        public string slug { get; set; }
        public bool? starred { get; set; }
        public string title { get; set; }
        public bool? unpinned { get; set; }
        public int unread { get; set; }
        public bool unseen { get; set; }
        public int views { get; set; }
        public bool visible { get; set; }
    }
}
