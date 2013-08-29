using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tharindu.JiraRest
{
    public class IssueProject
    {
        public IssueProject()
        {
            this.Roles = new List<string>();
        }

        public string Self { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public List<string> Roles { get; set; }
    }
}
