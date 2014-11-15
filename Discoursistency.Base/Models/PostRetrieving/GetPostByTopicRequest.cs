using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.PostRetrieving
{
    public class GetPostByTopicRequest
    {
        public int topic_id { get; set; }
        public int post_id { get; set; }
    }
}
