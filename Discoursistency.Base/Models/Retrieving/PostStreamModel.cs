using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Retrieving
{
    public class PostStreamModel
    {
        public IEnumerable<PostModel> posts { get; set; }
        public IEnumerable<int> stream { get; set; } 
    }
}
