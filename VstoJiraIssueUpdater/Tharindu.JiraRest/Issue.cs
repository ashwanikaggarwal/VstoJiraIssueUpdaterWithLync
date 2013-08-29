using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tharindu.JiraRest
{
    public class Issue
    {        
        public Issue()
        {
            this.Fields = new IssueFields();
        }

        public string Key { get; set; }
        public string Self { get; set; }
        public string Expand { get; set; }
        public string Transitions { get; set; }
        public IssueFields Fields { get; set; }
    }
}
