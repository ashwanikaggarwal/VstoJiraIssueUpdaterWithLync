using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechTalk.JiraRestClient
{
    public class Version
    {
        public string self { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public bool archived { get; set; }
        public bool released { get; set; }
    }
}
