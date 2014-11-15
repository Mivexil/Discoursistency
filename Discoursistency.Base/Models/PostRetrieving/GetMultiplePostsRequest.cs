using System.Collections.Generic;

namespace Discoursistency.Base.Models.PostRetrieving
{
    /// <summary>
    /// A request for multiple posts in the topic. Uses global post IDs.
    /// </summary>
    public class GetMultiplePostsRequest
    {
        public int? topicId { get; set; }
        public IEnumerable<int> post_ids { get; set; }
        public bool? include_raw { get; set; }
 
    }
}
