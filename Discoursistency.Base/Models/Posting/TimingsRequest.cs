using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Posting
{
    /// <summary>
    /// A model representing a request to mock post reading.
    /// </summary>
    public class TimingsRequest
    {
        public int topic_id { get; set; }
        public int topic_time { get; set; }
        public IDictionary<int, int> timings { get; set; }
    }
}
