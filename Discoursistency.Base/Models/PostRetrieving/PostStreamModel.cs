using System.Collections.Generic;

namespace Discoursistency.Base.Models.PostRetrieving
{
    /// <summary>
    /// A model representing an actual post stream in <see cref="MultiplePostsModel"/>
    /// </summary>
    public class PostStreamModel
    {
        public IEnumerable<PostModel> posts { get; set; }
        public IEnumerable<int> stream { get; set; } 
    }
}
