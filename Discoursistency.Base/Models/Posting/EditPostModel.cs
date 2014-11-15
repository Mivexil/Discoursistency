using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Posting
{
    /// <summary>
    /// A sub-model representing a post being edited in <see cref="EditPostRequest"/>
    /// </summary>
    public class EditPostModel
    {
        public string raw { get; set; }
        public string edit_reason { get; set; }
    }
}
