using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.PostRetrieving
{
    public class TopicListRequest
    {
        public string category_name { get; set; }
        public int page { get; set; }
    }
}
