using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechTalk.JiraRestClient
{
    public class Project
    {
        public string self { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string description { get; set; }
        public string assigneeType { get; set; }
        public string name { get; set; }

        public List<ProjectComponent> components { get; set; }
        public List<Version> versions { get; set; }

        public Project()
        {
            this.components = new List<ProjectComponent>();
            this.versions = new List<Version>();
        }
    }
}
