namespace VstoJiraIssueUpdater
{
    partial class RibbonIFS : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonIFS()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl1 = this.Factory.CreateRibbonDialogLauncher();
            Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl2 = this.Factory.CreateRibbonDialogLauncher();
            this.tabIFS = this.Factory.CreateRibbonTab();
            this.groupJira = this.Factory.CreateRibbonGroup();
            this.buttonAddModify = this.Factory.CreateRibbonButton();
            this.buttonAddSheet = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.editBoxServerURL = this.Factory.CreateRibbonEditBox();
            this.editBoxReporter = this.Factory.CreateRibbonEditBox();
            this.editBoxPassword = this.Factory.CreateRibbonEditBox();
            this.groupDefaultValues = this.Factory.CreateRibbonGroup();
            this.editBoxProjectId = this.Factory.CreateRibbonEditBox();
            this.editBoxTeam = this.Factory.CreateRibbonEditBox();
            this.separator3 = this.Factory.CreateRibbonSeparator();
            this.editBoxFixIteration = this.Factory.CreateRibbonEditBox();
            this.editBoxAssignee = this.Factory.CreateRibbonEditBox();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.buttonCheckDefaults = this.Factory.CreateRibbonButton();
            this.tabIFS.SuspendLayout();
            this.groupJira.SuspendLayout();
            this.group2.SuspendLayout();
            this.groupDefaultValues.SuspendLayout();
            // 
            // tabIFS
            // 
            this.tabIFS.Groups.Add(this.groupJira);
            this.tabIFS.Groups.Add(this.group2);
            this.tabIFS.Groups.Add(this.groupDefaultValues);
            this.tabIFS.Label = "JIRA Tools";
            this.tabIFS.Name = "tabIFS";
            // 
            // groupJira
            // 
            this.groupJira.DialogLauncher = ribbonDialogLauncherImpl1;
            this.groupJira.Items.Add(this.buttonAddModify);
            this.groupJira.Items.Add(this.buttonAddSheet);
            this.groupJira.Label = "Sub Task Manager";
            this.groupJira.Name = "groupJira";
            this.groupJira.DialogLauncherClick += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.groupJira_DialogLauncherClick);
            // 
            // buttonAddModify
            // 
            this.buttonAddModify.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.buttonAddModify.Label = "Save";
            this.buttonAddModify.Name = "buttonAddModify";
            this.buttonAddModify.OfficeImageId = "FileSave";
            this.buttonAddModify.ShowImage = true;
            this.buttonAddModify.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonAddModify_Click);
            // 
            // buttonAddSheet
            // 
            this.buttonAddSheet.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.buttonAddSheet.Label = "Add New Sheet";
            this.buttonAddSheet.Name = "buttonAddSheet";
            this.buttonAddSheet.OfficeImageId = "AdpDiagramNewTable";
            this.buttonAddSheet.ShowImage = true;
            this.buttonAddSheet.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonAddSheet_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.editBoxServerURL);
            this.group2.Items.Add(this.editBoxReporter);
            this.group2.Items.Add(this.editBoxPassword);
            this.group2.Label = "Login Information";
            this.group2.Name = "group2";
            // 
            // editBoxServerURL
            // 
            this.editBoxServerURL.Label = "Server URL:";
            this.editBoxServerURL.Name = "editBoxServerURL";
            this.editBoxServerURL.SizeString = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            this.editBoxServerURL.Text = null;
            // 
            // editBoxReporter
            // 
            this.editBoxReporter.Label = "Reporter:";
            this.editBoxReporter.Name = "editBoxReporter";
            this.editBoxReporter.SizeString = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            this.editBoxReporter.Text = null;
            // 
            // editBoxPassword
            // 
            this.editBoxPassword.Label = "Password:";
            this.editBoxPassword.Name = "editBoxPassword";
            this.editBoxPassword.SizeString = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            this.editBoxPassword.Text = null;
            // 
            // groupDefaultValues
            // 
            this.groupDefaultValues.DialogLauncher = ribbonDialogLauncherImpl2;
            this.groupDefaultValues.Items.Add(this.editBoxProjectId);
            this.groupDefaultValues.Items.Add(this.editBoxTeam);
            this.groupDefaultValues.Items.Add(this.separator3);
            this.groupDefaultValues.Items.Add(this.editBoxFixIteration);
            this.groupDefaultValues.Items.Add(this.editBoxAssignee);
            this.groupDefaultValues.Items.Add(this.separator1);
            this.groupDefaultValues.Items.Add(this.buttonCheckDefaults);
            this.groupDefaultValues.Label = "Default Values";
            this.groupDefaultValues.Name = "groupDefaultValues";
            this.groupDefaultValues.DialogLauncherClick += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.groupDefaultValues_DialogLauncherClick);
            // 
            // editBoxProjectId
            // 
            this.editBoxProjectId.Label = "Project Id:";
            this.editBoxProjectId.Name = "editBoxProjectId";
            this.editBoxProjectId.Text = null;
            // 
            // editBoxTeam
            // 
            this.editBoxTeam.Label = "Team:";
            this.editBoxTeam.Name = "editBoxTeam";
            this.editBoxTeam.Text = null;
            // 
            // separator3
            // 
            this.separator3.Name = "separator3";
            // 
            // editBoxFixIteration
            // 
            this.editBoxFixIteration.Label = "Fix Iteration:";
            this.editBoxFixIteration.Name = "editBoxFixIteration";
            this.editBoxFixIteration.SizeString = "xxxxxxxxxxxxxxxxxxxxxxxxx";
            this.editBoxFixIteration.Text = null;
            // 
            // editBoxAssignee
            // 
            this.editBoxAssignee.Label = "Assignee:";
            this.editBoxAssignee.Name = "editBoxAssignee";
            this.editBoxAssignee.ScreenTip = "E.g. cprilk (Chathurika Priyadarshana)";
            this.editBoxAssignee.SizeString = "xxxxxxxxxxxxxxxxxxxxxxxxx";
            this.editBoxAssignee.Text = null;
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // buttonCheckDefaults
            // 
            this.buttonCheckDefaults.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.buttonCheckDefaults.Label = "Check Defaults";
            this.buttonCheckDefaults.Name = "buttonCheckDefaults";
            this.buttonCheckDefaults.OfficeImageId = "AcceptInvitation";
            this.buttonCheckDefaults.ShowImage = true;
            this.buttonCheckDefaults.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonCheckDefaults_Click);
            // 
            // RibbonIFS
            // 
            this.Name = "RibbonIFS";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tabIFS);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonIFS_Load);
            this.tabIFS.ResumeLayout(false);
            this.tabIFS.PerformLayout();
            this.groupJira.ResumeLayout(false);
            this.groupJira.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.groupDefaultValues.ResumeLayout(false);
            this.groupDefaultValues.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabIFS;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupJira;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonAddModify;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonAddSheet;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator3;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBoxProjectId;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBoxTeam;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBoxFixIteration;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBoxAssignee;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBoxServerURL;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBoxReporter;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBoxPassword;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupDefaultValues;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonCheckDefaults;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonIFS RibbonIFS
        {
            get { return this.GetRibbon<RibbonIFS>(); }
        }
    }
}
