﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Retrieving
{
    public class PrivateMessagesStatsModel
    {
        public int all { get; set; }
        public int mine { get; set; }
        public int unread { get; set; }
    }
}
