using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.PostRetrieving
{
    public class TopicListResponse
    {
        public TopicListModel topic_list { get; set; }
        public IEnumerable<UserRetrieving.SmallUserModel> users { get; set; } 
    }
}
