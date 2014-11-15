using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.PostRetrieving
{
    public class ThreadLinkModel
    {
        public int clicks { get; set; }
        public string domain { get; set; }
        public string fancy_title { get; set; }
        public bool @internal { get; set; }
        public bool reflection { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public int user_id { get; set; }
    }
}
