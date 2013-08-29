using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tharindu.JiraRest
{
    public class IssueTimeTracking
    {
        public int TimeOriginalEstimate { get; set; }
        public int TimeEstimate { get; set; }
        public int TimeSpent { get; set; }
    }
}
