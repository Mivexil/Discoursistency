using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Posting
{
    /// <summary>
    /// A model representing a request to create a post.
    /// </summary>
    public class PostRequest
    {
        public string raw { get; set; }
        public bool is_warning { get; set; }
        public int category { get; set; }
        public string archetype { get; set; }
        public string title { get; set; }
        public int? topic_id { get; set; }
        public int? reply_to_post_number { get; set; }

    }
}
