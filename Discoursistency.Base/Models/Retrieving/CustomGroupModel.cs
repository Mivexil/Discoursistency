using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Retrieving
{
    public class CustomGroupModel
    {
        public int? alias_level { get; set; }
        public bool automatic { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int user_count { get; set; }
        public bool visible { get; set; }
    }
}
