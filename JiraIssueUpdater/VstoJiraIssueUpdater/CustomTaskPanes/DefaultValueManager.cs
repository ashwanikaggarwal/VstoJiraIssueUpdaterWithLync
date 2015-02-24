using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VstoJiraIssueUpdater.CustomTaskPanes
{
    public partial class DefaultValueManager : UserControl
    {
        public DefaultValueManager()
        {
            InitializeComponent();
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Are you sure?", "Making Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Properties.Settings.Default.Reload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Default Value Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Default Value Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Are you sure?", "Making Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Properties.Settings.Default.Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Default Value Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpgrade_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Are you sure?", "Making Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Properties.Settings.Default.Upgrade();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Default Value Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
