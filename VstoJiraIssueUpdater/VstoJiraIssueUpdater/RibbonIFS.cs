using System;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;
using VstoJiraIssueUpdater.CustomTaskPanes;
using VstoJiraIssueUpdater.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace VstoJiraIssueUpdater
{
    public partial class RibbonIFS
    {
        private FormSave mySave;
        private JiraLync myJiraLync;
        private Microsoft.Office.Tools.CustomTaskPane myCustomTaskPane;

        private void RibbonIFS_Load(object sender, RibbonUIEventArgs e)
        {
            try
            {
                myCustomTaskPane = Globals.ThisAddIn.CustomTaskPanes.Add(new DefaultValueManager(), "JIRA Tools Default Values");
                myCustomTaskPane.DockPositionRestrict = Microsoft.Office.Core.MsoCTPDockPositionRestrict.msoCTPDockPositionRestrictNoHorizontal;

                myJiraLync = new JiraLync();
            }
            catch (Exception)
            {
            }

            try
            {
                mySave = new FormSave();
                if (myJiraLync != null)
                {
                    mySave.MyJiraLync = this.myJiraLync;
                }

                editBoxServerURL.Text = Properties.Settings.Default.JiraServer;
                editBoxReporter.Text = Properties.Settings.Default.UserName;
                editBoxPassword.Text = Properties.Settings.Default.Password;

                editBoxProjectId.Text = Properties.Settings.Default.JiraProjectID;
                editBoxTeam.Text = Properties.Settings.Default.Component_Team;
                editBoxFixIteration.Text = Properties.Settings.Default.FixVersion;
                editBoxAssignee.Text = Properties.Settings.Default.Assignee;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddModify_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                Properties.Settings.Default.JiraProjectID = editBoxProjectId.Text.Trim();
                Properties.Settings.Default.Component_Team = editBoxTeam.Text.Trim();
                Properties.Settings.Default.FixVersion = editBoxFixIteration.Text.Trim();
                Properties.Settings.Default.Assignee = editBoxAssignee.Text.Trim();

                Properties.Settings.Default.JiraServer = editBoxServerURL.Text;
                Properties.Settings.Default.UserName = editBoxReporter.Text;
                Properties.Settings.Default.Password = editBoxPassword.Text;

                mySave.ShowDialog();

                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Jira Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddSheet_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                Excel.Worksheet newWorksheet = null;
                Excel.Sheets worksheetList = Globals.ThisAddIn.Application.Sheets;
                foreach (Excel.Worksheet worksheet in worksheetList)
                {
                    if (worksheet.Name == Properties.Settings.Default.WorkSheetName)
                    {
                        newWorksheet = worksheet;
                        break;
                    }
                }
                if (newWorksheet == null)
                {
                    newWorksheet = Globals.ThisAddIn.Application.Sheets.Add();
                    newWorksheet.Name = Properties.Settings.Default.WorkSheetName;
                }
                newWorksheet.Activate();

                Excel.Range myRange = newWorksheet.UsedRange;
                Excel.Range headerRow = myRange.Rows[1];

                myRange.Application.ActiveWindow.SplitRow = 1;
                myRange.Application.ActiveWindow.FreezePanes = true;

                Excel.Range headerCell_A = headerRow.Cells[1, 1];
                Excel.Range headerCell_B = headerRow.Cells[1, 2];
                Excel.Range headerCell_C = headerRow.Cells[1, 3];
                Excel.Range headerCell_D = headerRow.Cells[1, 4];
                Excel.Range headerCell_E = headerRow.Cells[1, 5];
                Excel.Range headerCell_F = headerRow.Cells[1, 6];

                headerCell_A.Value2 = "User Story ID";
                headerCell_B.Value2 = "Task ID";
                headerCell_C.Value2 = "Task Summary";
                headerCell_D.Value2 = "Original Estimate (In hours)";
                headerCell_E.Value2 = "Priority";
                headerCell_F.Value2 = "Description";

                headerRow.EntireRow.Font.Bold = true;
                headerRow.EntireRow.Font.Color = System.Drawing.Color.ForestGreen;

                newWorksheet.get_Range("A1", "F1").EntireColumn.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Jira Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupJira_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            try
            {
                if (myJiraLync != null)
                {
                    myJiraLync.SendMessage(Properties.Settings.Default.DefaultErrorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lync Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupDefaultValues_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            try
            {
                myCustomTaskPane.Visible = !myCustomTaskPane.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Default Value Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCheckDefaults_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                Properties.Settings.Default.JiraProjectID = editBoxProjectId.Text.Trim();
                Properties.Settings.Default.Component_Team = editBoxTeam.Text.Trim();
                Properties.Settings.Default.FixVersion = editBoxFixIteration.Text.Trim();
                Properties.Settings.Default.Assignee = editBoxAssignee.Text.Trim();

                Properties.Settings.Default.JiraServer = editBoxServerURL.Text;
                Properties.Settings.Default.UserName = editBoxReporter.Text;
                Properties.Settings.Default.Password = editBoxPassword.Text;

                if (mySave.CheckDefaultValues())
                {
                    MessageBox.Show("Everything checks out!", "Default Value Check Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Default Value Check Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}