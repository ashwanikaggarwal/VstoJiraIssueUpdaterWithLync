using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tharindu.JiraRest
{
    public class IssueVote
    {
        public string Self { get; set; }
        public int Votes { get; set; }
        public bool HasVoted { get; set; }
    }
}
