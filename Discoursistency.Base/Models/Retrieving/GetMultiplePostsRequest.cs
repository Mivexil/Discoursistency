using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Retrieving
{
    public class GetMultiplePostsRequest
    {
        public int? topicId { get; set; }
        public IEnumerable<int> post_ids { get; set; }
 
    }
}
