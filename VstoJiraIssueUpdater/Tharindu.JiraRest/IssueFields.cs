using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tharindu.JiraRest
{
    public class IssueFields
    {
        public IssueFields()
        {
            this.Assignee = new NamedEntity<IssueUser>();
            this.Attachment = new NamedEntity<List<string>>();
            this.Components = new NamedEntity<List<IssueComponent>>();
            this.Created = new NamedEntity<DateTime>();
            this.Description = new NamedEntity<string>();
            this.DueDate = new NamedEntity<DateTime>();
            this.Environment = new NamedEntity<string>();
            this.FixVersions = new NamedEntity<List<IssueFixVersion>>();
            this.IssueType = new NamedEntity<IssueType>();
            this.Labels = new NamedEntity<List<string>>();
            this.Links = new NamedEntity<List<IssueLink>>();
            this.Parent = new NamedEntity<IssueLink>();
            this.Priority = new NamedEntity<IssuePriority>();
            this.Project = new NamedEntity<IssueProject>();
            this.Reporter = new NamedEntity<IssueUser>();
            this.Status = new NamedEntity<IssueStatus>();
            this.SubTasks = new NamedEntity<List<IssueLink>>();
            this.Summary = new NamedEntity<string>();
            this.TimeTracking = new NamedEntity<IssueTimeTracking>();
            this.Updated = new NamedEntity<DateTime>();
            this.Versions = new NamedEntity<List<string>>();
            this.Votes = new NamedEntity<List<IssueVote>>();
            this.Watcher = new NamedEntity<IssueWatcher>();
            this.Worklog = new NamedEntity<string>();

            this.Components.Value = new List<IssueComponent>();
            this.IssueType.Value = new IssueType();
            this.Parent.Value = new IssueLink();
            this.Project.Value = new IssueProject();
        }

        public NamedEntity<IssueProject> Project { get; set; }
        public NamedEntity<string> Summary { get; set; }
        public NamedEntity<IssueType> IssueType { get; set; }
        public NamedEntity<IssueStatus> Status { get; set; }

        public NamedEntity<string> Description { get; set; }
        public NamedEntity<IssuePriority> Priority { get; set; }
        public NamedEntity<IssueUser> Assignee { get; set; }
        public NamedEntity<IssueUser> Reporter { get; set; }
        public NamedEntity<List<IssueFixVersion>> FixVersions { get; set; }
        public NamedEntity<List<IssueComponent>> Components { get; set; }
        
        public NamedEntity<IssueTimeTracking> TimeTracking { get; set; }

        public NamedEntity<List<IssueVote>> Votes { get; set; }
        public NamedEntity<DateTime> Created { get; set; }
        public NamedEntity<DateTime> Updated { get; set; }
        public NamedEntity<DateTime> DueDate { get; set; }
        public NamedEntity<IssueWatcher> Watcher { get; set; }
        public NamedEntity<string> Worklog { get; set; }
        public NamedEntity<List<string>> Labels { get; set; }
        public NamedEntity<IssueLink> Parent { get; set; }
        public NamedEntity<List<IssueLink>> Links { get; set; }
        public NamedEntity<List<string>> Attachment { get; set; }
        public NamedEntity<List<IssueLink>> SubTasks { get; set; }
        public NamedEntity<List<string>> Versions { get; set; }
        public NamedEntity<string> Environment { get; set; }
    }
}
