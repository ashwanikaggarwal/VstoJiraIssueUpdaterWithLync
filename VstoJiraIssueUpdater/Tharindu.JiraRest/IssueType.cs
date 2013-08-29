using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tharindu.JiraRest
{
    public class IssueType
    {
        public string Self { get; set; }
        public string Name { get; set; }
        public bool SubTask { get; set; }
    }
}
