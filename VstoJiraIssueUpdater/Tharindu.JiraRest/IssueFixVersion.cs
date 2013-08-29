using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tharindu.JiraRest
{
    public class IssueFixVersion
    {
        public string Self { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public bool Overdue { get; set; }
        public DateTime UserReleaseDate { get; set; }
        public bool Archived { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Released { get; set; }
    }
}
