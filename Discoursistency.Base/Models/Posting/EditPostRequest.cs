using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Posting
{
    /// <summary>
    /// A model representing a request to edit a post.
    /// </summary>
    public class EditPostRequest
    {
        public int? id { get; set; }
        public EditPostModel post { get; set; }
    }
}
