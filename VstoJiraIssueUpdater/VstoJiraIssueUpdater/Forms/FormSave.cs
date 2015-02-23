using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using TechTalk.JiraRestClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace VstoJiraIssueUpdater.Forms
{
    public partial class FormSave : Form
    {
        private delegate void backgroundWorkerSave_ProgressChangedDelegate(object sender, ProgressChangedEventArgs e);

        private delegate void backgroundWorkerSave_RunWorkerCompletedDelegate(object sender, RunWorkerCompletedEventArgs e);

        private JiraClient MyJira { get; set; }

        internal JiraLync MyJiraLync { private get; set; }

        public FormSave()
        {
            InitializeComponent();
        }

        private void FormSave_Load(object sender, EventArgs e)
        {
            try
            {
                this.MyJira = new JiraClient(Properties.Settings.Default.JiraServer.Trim(),
                                             Properties.Settings.Default.UserName.Trim(),
                                             Properties.Settings.Default.Password.Trim());

                buttonCancel.Text = "Cancel";

                if (backgroundWorkerSave.IsBusy == false)
                {
                    backgroundWorkerSave.RunWorkerAsync();
                }
                else
                {
                    throw new Exception("Application Is busy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (MyJiraLync != null)
                {
                    MyJiraLync.SendMessage(ex.Message);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorkerSave.CancelAsync();

                if (buttonCancel.Text == "OK")
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cancel Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (MyJiraLync != null)
                {
                    MyJiraLync.SendMessage(ex.Message);
                }
            }
        }

        private void backgroundWorkerSave_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Do not access the form's BackgroundWorker reference directly.
                // Instead, use the reference provided by the sender parameter.
                BackgroundWorker worker = sender as BackgroundWorker;

                if (worker.CancellationPending == false)
                {
                    worker.ReportProgress(0);

                    List<BreezeIssue> breezeIssueList = this.GetBreezeIssueListFromExcel();

                    this.SaveJiraIssue(breezeIssueList, worker, e);

                    worker.ReportProgress(100);
                }

                // If the operation was canceled by the user,
                // set the DoWorkEventArgs.Cancel property to true.
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception)
            {
                //throw the exception so that RunWorkerCompleted can catch it.
                throw;
            }
        }

        private void backgroundWorkerSave_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new backgroundWorkerSave_ProgressChangedDelegate(backgroundWorkerSave_ProgressChanged), new object[] { sender, e });
                }
                else
                {
                    if (e.ProgressPercentage == progressBarSave.Minimum)
                    {
                        pictureBoxProgress.Image = Properties.Resources.ajax_loader;
                    }

                    progressBarSave.Value = e.ProgressPercentage;

                    Globals.ThisAddIn.Application.StatusBar = "Progress: " + e.ProgressPercentage + "%";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void backgroundWorkerSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new backgroundWorkerSave_RunWorkerCompletedDelegate(backgroundWorkerSave_RunWorkerCompleted), new object[] { sender, e });
                }
                else
                {
                    buttonCancel.Text = "OK";

                    if (e.Error != null)
                    {
                        MessageBox.Show(this, e.Error.Message, "Jira Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (e.Cancelled == false)
                        {
                            this.CheckErrors(e.Result as List<BreezeIssue>);
                        }
                    }

                    Globals.ThisAddIn.Application.StatusBar = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Jira Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (MyJiraLync != null)
                {
                    MyJiraLync.SendMessage(ex.Message);
                }
            }
        }

        private void CheckErrors(List<BreezeIssue> UnsuccessfulBreezeIssueList)
        {
            if (UnsuccessfulBreezeIssueList.Count > 0)
            {
                if (UnsuccessfulBreezeIssueList.Count == UnsuccessfulBreezeIssueList.Capacity)
                {
                    MessageBox.Show(this, "Not even one Issue was correctly saved. What were you thinking...", "Error: Issues were not successful saved.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string message = "[";
                    foreach (BreezeIssue UnsuccessfulBreezeIssue in UnsuccessfulBreezeIssueList)
                    {
                        if (UnsuccessfulBreezeIssueList.IndexOf(UnsuccessfulBreezeIssue) == 0)
                        {
                            message += UnsuccessfulBreezeIssue.Summary;
                        }
                        else
                        {
                            message += UnsuccessfulBreezeIssue.Summary + ", ";
                        }
                    }
                    message += "]";

                    MessageBox.Show(this, "Some of the issue were not correctly saved! \r\n" + message, "Error: Issues were not successful saved.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                pictureBoxProgress.Image = Properties.Resources.passed;

                MessageBox.Show("Jira Issues Updated Successfully", "Jira Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        internal bool CheckDefaultValues()
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.JiraServer) ||
                string.IsNullOrWhiteSpace(Properties.Settings.Default.UserName) ||
                string.IsNullOrWhiteSpace(Properties.Settings.Default.Password))
            {
                throw new Exception("'Server URL' and 'Reporter' and 'Password' must have values!");
            }

            this.MyJira = new JiraClient(Properties.Settings.Default.JiraServer.Trim(),
                                         Properties.Settings.Default.UserName.Trim(),
                                         Properties.Settings.Default.Password.Trim());

            Project JiraProjec = this.MyJira.GetProject(Properties.Settings.Default.JiraProjectID);
            if (JiraProjec == null)
            {
                throw new Exception("JIRA Project ID does not Exist!");
            }
            List<ProjectComponent> teamList = JiraProjec.components.Where(c => c.name == Properties.Settings.Default.Component_Team).ToList();
            if (teamList == null && teamList.Count < 1)
            {
                throw new Exception("Team does not Exist!");
            }
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.FixVersion) == false)
            {
                List<TechTalk.JiraRestClient.Version> fixIterationsList = JiraProjec.versions.Where(v => v.name == Properties.Settings.Default.FixVersion).ToList();
                if (fixIterationsList == null || fixIterationsList.Count < 1)
                {
                    throw new Exception("Fix Iteration does not Exist!");
                }
            }
            return true;
        }

        private List<BreezeIssue> GetBreezeIssueListFromExcel()
        {
            List<BreezeIssue> breezeIssueList = new List<BreezeIssue>();
            Excel.Worksheet ifsWorksheet = Globals.ThisAddIn.Application.ActiveSheet;
            int rowIndex;
            string userStoryKey;
            string key;
            string summary;
            object originalEstimate;
            string priority;
            string description;

            if (ifsWorksheet.Name == Properties.Settings.Default.WorkSheetName)
            {
                Excel.Range myRange = ifsWorksheet.UsedRange;

                BreezeIssue bIssue;
                foreach (Excel.Range myRow in myRange.Rows)
                {
                    if (myRow.Row == 1)
                    {
                        continue;
                    }

                    rowIndex = myRow.Row;
                    userStoryKey = myRow.Cells[1, 1].Value2; //A

                    if (string.IsNullOrWhiteSpace(userStoryKey) == false)
                    {
                        key = myRow.Cells[1, 2].Value2; //B
                        summary = myRow.Cells[1, 3].Value2; //C
                        originalEstimate = myRow.Cells[1, 4].Value2; //D
                        priority = myRow.Cells[1, 5].Value2; //E
                        description = myRow.Cells[1, 6].Value2; //F

                        if (string.IsNullOrWhiteSpace(summary))
                        {
                            throw new Exception("'Task Summary' is empty in row[" + rowIndex + "]");
                        }

                        bIssue = new BreezeIssue();
                        bIssue.RowIndex = rowIndex;
                        bIssue.UserStoryKey = userStoryKey.Trim();
                        if (string.IsNullOrWhiteSpace(key) == false)
                        {
                            bIssue.Key = key.Trim();
                        }
                        bIssue.Summary = summary.Trim();
                        if (originalEstimate != null)
                        {
                            bIssue.OriginalEstimate = originalEstimate.ToString().Trim() + Properties.Settings.Default.OriginalEstimateIn;
                        }
                        else
                        {
                            bIssue.OriginalEstimate = "0" + Properties.Settings.Default.OriginalEstimateIn;
                        }
                        if (string.IsNullOrWhiteSpace(priority) == false)
                        {
                            bIssue.Priority = priority.Trim();
                        }
                        if (string.IsNullOrWhiteSpace(description) == false)
                        {
                            bIssue.Description = description.Trim();
                        }

                        breezeIssueList.Add(bIssue);
                    }
                }
            }
            else
            {
                throw new Exception("Worksheet Name is not '" + Properties.Settings.Default.WorkSheetName + "'");
            }
            return breezeIssueList;
        }

        private void SaveJiraIssue(List<BreezeIssue> breezeIssueList, BackgroundWorker worker, DoWorkEventArgs e)
        {
            int increment = 100 / breezeIssueList.Count;
            int currentProgress = 0;

            Issue myIssue;
            List<BreezeIssue> UnsuccessfulBreezeIssueList = new List<BreezeIssue>(breezeIssueList.Count);
            foreach (BreezeIssue bIssue in breezeIssueList)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    Excel.Range myRange = ((Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet).UsedRange;

                    try
                    {
                        if (string.IsNullOrWhiteSpace(bIssue.Key))
                        {
                            myIssue = new Issue();
                            myIssue.fields.reporter = new JiraUser() { name = Properties.Settings.Default.UserName };
                            myIssue.fields.parent = new Issue() { key = bIssue.UserStoryKey };
                        }
                        else
                        {
                            myIssue = this.MyJira.LoadIssue(bIssue.Key);
                            if (myIssue.fields.reporter.name != Properties.Settings.Default.UserName)
                            {
                                throw new Exception("It's not your Sub Task to update.");
                            }
                        }

                        myIssue.fields.summary = bIssue.Summary;
                        myIssue.fields.description = bIssue.Description;
                        myIssue.fields.priority = new Priority() { name = bIssue.Priority };

                        myIssue.fields.timetracking.originalEstimate = bIssue.OriginalEstimate;

                        if (myIssue.fields.components.Exists(c => c.name == bIssue.Categories) == false)
                        {
                            myIssue.fields.components.Add(new IssueComponent() { name = bIssue.Categories });
                        }

                        if (string.IsNullOrWhiteSpace(bIssue.Assignee) == false &&
                            myIssue.fields.assignee.name != bIssue.Assignee)
                        {
                            myIssue.fields.assignee = new JiraUser() { name = bIssue.Assignee };
                        }

                        if (string.IsNullOrWhiteSpace(bIssue.FixIterations) == false &&
                            myIssue.fields.fixVersions.Exists(c => c.name == bIssue.FixIterations) == false)
                        {
                            myIssue.fields.fixVersions.Add(new IssueFixVersion() { name = bIssue.FixIterations });
                        }

                        if (string.IsNullOrWhiteSpace(bIssue.Key))
                        {
                            myIssue = this.MyJira.CreateIssue(Properties.Settings.Default.JiraProjectID, bIssue.Type, myIssue.fields);

                            myRange.Rows[bIssue.RowIndex].Cells[1, 2].Value2 = myIssue.key;
                        }
                        else
                        {
                            this.MyJira.UpdateIssue(myIssue);
                        }
                    }
                    catch (Exception)
                    {
                        UnsuccessfulBreezeIssueList.Add(bIssue);
                    }

                    currentProgress += increment;
                    worker.ReportProgress(currentProgress);
                }
            }

            e.Result = UnsuccessfulBreezeIssueList;
        }
    }
}