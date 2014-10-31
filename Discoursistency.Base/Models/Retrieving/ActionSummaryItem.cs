using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Discoursistency.Base.Exceptions;

namespace Discoursistency.Base.Models.Retrieving
{
    public class ActionSummaryItem
    {
        public bool can_act { get; set; }
        public bool? can_defer_flags { get; set; }
        public int count { get; set; }
        public bool hidden { get; set; }
        public int id { get; set; }
    }
}
