using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechTalk.JiraRestClient
{
    public class ProjectComponent
    {
        public string self { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public bool isAssigneeTypeValid { get; set; }
    }
}
