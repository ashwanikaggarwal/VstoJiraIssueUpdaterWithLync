using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tharindu.JiraRest
{
    public class IssueWatcher
    {
        public string Self { get; set; }
        public bool IsWatching { get; set; }
        public int WatchCount { get; set; }
    }
}
