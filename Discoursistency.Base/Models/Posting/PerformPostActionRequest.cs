using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Posting
{
    /// <summary>
    /// A model representing a request to perform a post action.
    /// </summary>
    public class PerformPostActionRequest
    {
        public int? id { get; set; }
        public int post_action_type_id { get; set; }
        public bool? flag_topic { get; set; }
        public string message { get; set; }
        public bool? take_action { get; set; }
    }
}
