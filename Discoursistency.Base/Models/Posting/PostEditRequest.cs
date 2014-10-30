using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Posting
{
    /// <summary>
    /// A model representing a request to edit a post.
    /// </summary>
    public class PostEditRequest
    {
        public int? id { get; set; }
        public PostEditPostModel post { get; set; }
    }
}
