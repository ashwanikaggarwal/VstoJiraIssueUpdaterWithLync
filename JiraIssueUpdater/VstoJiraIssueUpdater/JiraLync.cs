using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Lync.Model;
using Microsoft.Lync.Model.Extensibility;

namespace VstoJiraIssueUpdater
{
    internal class JiraLync
    {
        private Automation _Automation;
        private List<string> inviteeList;
        private Dictionary<AutomationModalitySettings, object> _ModalitySettings;
        private AutomationModalities _ChosenMode;

        internal JiraLync()
        {
            try
            {
                _Automation = LyncClient.GetAutomation();

                // Create a generic List object to contain a contact URI.
                // Ensure that a valid URI is added.
                inviteeList = new List<string>();
                inviteeList.Add(Properties.Settings.Default.SupportPerson);

                // Create a generic Dictionary object to contain conversation setting objects.
                _ModalitySettings = new Dictionary<AutomationModalitySettings, object>();
                _ModalitySettings.Add(AutomationModalitySettings.Subject, "JIRA Tool Issues");
                _ModalitySettings.Add(AutomationModalitySettings.SendFirstInstantMessageImmediately, true);
                
                _ChosenMode = AutomationModalities.InstantMessage;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void SendMessage(string imText)
        {
            try
            {
                if (_ModalitySettings.ContainsKey(AutomationModalitySettings.FirstInstantMessage))
                {
                    _ModalitySettings[AutomationModalitySettings.FirstInstantMessage] = "JIRA Tool Error! : " + imText;
                }
                else
                {
                    _ModalitySettings.Add(AutomationModalitySettings.FirstInstantMessage, "JIRA Tool Error! : " + imText);
                }
                // Start the conversation.
                IAsyncResult ar = _Automation.BeginStartConversation(_ChosenMode,
                                                                     inviteeList,
                                                                     _ModalitySettings,
                                                                     null,
                                                                     null);
                

                //Block UI thread until conversation is started
                _Automation.EndStartConversation(ar);
            }
            catch (Exception)
            {
                
            }
        }
    }
}
