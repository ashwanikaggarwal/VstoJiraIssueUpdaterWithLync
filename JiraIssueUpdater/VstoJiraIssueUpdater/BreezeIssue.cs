using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VstoJiraIssueUpdater
{
    internal class BreezeIssue
    {
        internal BreezeIssue()
        {
            this.Type = Properties.Settings.Default.Type;
            this.Priority = Properties.Settings.Default.DefaultPriority;
            this.Assignee = Properties.Settings.Default.Assignee;
            this.FixIterations = Properties.Settings.Default.FixVersion;
            this.Categories = Properties.Settings.Default.Component_Team;
            this.Status = Properties.Settings.Default.Status;
        }

        internal string Type { get; private set; }        
        internal string Assignee { get; private set; }
        internal string FixIterations { get; private set; }
        internal string Categories { get; private set; }
        internal string Status { get; private set; }

        internal int RowIndex { get; set; }
        internal string Key { get; set; }
        internal string Description { get; set; }
        internal string Priority { get; set; }
        internal string UserStoryKey  { get; set; }
        internal string Summary { get; set; }
        internal string OriginalEstimate { get; set; }
    }
}
