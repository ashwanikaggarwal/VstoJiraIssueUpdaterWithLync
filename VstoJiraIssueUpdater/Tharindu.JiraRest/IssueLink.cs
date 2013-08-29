using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tharindu.JiraRest
{
    public class IssueLink
    {
        public string IssueKey { get; set; }
        public string Issue { get; set; }
        public IssueLinkType Type { get; set; }
    }

    public class IssueLinkType
    {
        public string Name { get; set; }
        public string Direction { get; set; }
    }
}
