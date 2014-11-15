using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.PostRetrieving
{
    public class TopicListModel
    {
        public bool can_create_topic { get; set; }
        public string draft { get; set; }
        public string draft_key { get; set; }
        public int draft_sequence { get; set; }
        public string more_topics_url { get; set; }
        public IEnumerable<SmallTopicModel> topics { get; set; } 
    }
}
