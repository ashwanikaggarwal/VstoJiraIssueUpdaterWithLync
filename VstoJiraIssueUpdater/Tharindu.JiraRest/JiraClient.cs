using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Deserializers;
using System.Net;

namespace Tharindu.JiraRest
{
    public class JiraClient
    {
        private readonly string username;
        private readonly string password;
        private readonly RestClient client;
        private readonly JsonDeserializer deserializer;
        
        public JiraClient(string url, string username, string password)
        {
            this.username = username;
            this.password = password;
            this.deserializer = new JsonDeserializer();
            this.client = new RestClient(url);
        }

        private RestRequest CreateRequest(Method method, String path)
        {
            RestRequest request = new RestRequest(path, method);

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", this.username, this.password))));
            
            return request;
        }

        private void AssertStatus(IRestResponse response, HttpStatusCode status)
        {
            if (response.ErrorException != null)
            {
                throw new Exception("Transport level error: " + response.ErrorMessage, response.ErrorException);
            }
            if (response.StatusCode != status)
            {
                throw new Exception("JIRA returned wrong status: " + response.StatusDescription + "[" + response.Content + "]");
            }
        }

        public Issue GetIssue(String key)
        {
            try
            {
                string path = String.Format("issue/{0}", key);
                RestRequest request = this.CreateRequest(Method.GET, path);

                IRestResponse response = client.Execute(request);
                this.AssertStatus(response, HttpStatusCode.OK);

                Issue issue = deserializer.Deserialize<Issue>(response);
                return issue;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not load issue", ex);
            }
        }

        public Issue CreateIssue(Issue newIssue)
        {
            try
            {
                RestRequest request = this.CreateRequest(Method.POST, "issue");
                request.AddHeader("ContentType", "application/json");

                //request.AddBody(newIssue);

                request.AddBody(new
                {
                    Fields = new
                    {
                        Project = new { Key = newIssue.Fields.Project.Value.Key },
                        IssueType = new { Name = "Bug" },
                        Summary = newIssue.Fields.Summary.Value,
                        //Components = new { Name = newIssue.Fields.Components.Value },
                        //Parent = new { IssueKey = newIssue.Fields.Parent.Value.IssueKey }
                    }
                });

                IRestResponse response = client.Execute(request);
                this.AssertStatus(response, HttpStatusCode.Created);

                newIssue = deserializer.Deserialize<Issue>(response);
                return newIssue;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not create issue", ex);
            }
        }
    }
}
