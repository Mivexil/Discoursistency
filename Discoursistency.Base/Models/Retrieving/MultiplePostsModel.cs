using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Retrieving
{
    public class MultiplePostsModel
    {
        public int id { get; set; }
        public PostStreamModel post_stream { get; set; }
    }
}
