using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Posting
{
    /// <summary>
    /// A model representing a request to delete the post.
    /// </summary>
    public class PostDeleteRequest
    {
        public int? id { get; set; }
        public string context { get; set; }
    }
}
