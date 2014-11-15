using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.CategoryRetrieving
{
    public class CategoryModel
    {
        public string background_url { get; set; }
        public string color { get; set; }
        public string description { get; set; }
        public string description_excerpt { get; set; }
        public string description_text { get; set; }
        public IEnumerable<int> featured_user_ids { get; set; }
        public int id { get; set; }
        public string logo_url { get; set; }
        public string name { get; set; }
        public int? notification_level { get; set; }
        public string permission { get; set; }
        public int post_count { get; set; }
        public int posts_day { get; set; }
        public int posts_month { get; set; }
        public int posts_week { get; set; }
        public int posts_year { get; set; }
        public bool read_restricted { get; set; }
        public string slug { get; set; }
        public IEnumerable<int> subcategory_ids { get; set; }
        public string text_color { get; set; }
        public int topic_count { get; set; }
        public string topic_url { get; set; }
        public IEnumerable<PostRetrieving.SmallTopicModel> topics { get; set; }
        public int topics_day { get; set; }
        public int topics_month { get; set; }
        public int topics_week { get; set; }
        public int topics_year { get; set; }
    }
}
