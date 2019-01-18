using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkComRoomTest
{
    public partial class AlertContactsListForm : Form
    {
        private bool SetFullName = false;
        private bool SetEmailAddress = false;


        public AlertContactsListForm()
        {
            InitializeComponent();

            // this is to show grid even if there is not data to display
    
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ClearAddEditFields();


            Form1.instance.alertContactButton = !Form1.instance.alertContactButton;

            Form1.instance.alertContactsListForm.Enabled = false;
            Form1.instance.alertContactsListForm.Visible = false;

            Form1.instance.Activate();
            Form1.instance.Enabled = true;
            //Form1.instance.BringToFront();
        }

        private void txtBoxFullName_TextChanged(object sender, EventArgs e)
        {
            SetFullName = false;


            // if this has a string & email txtbox has a string enable saving.
            if(txtBoxFullName.Text.Length == 0)
            {
                SetFullName = false;
                SetSaveButtonState();

                return;
            }
            if(txtBoxFullName.Text.Length > 0)
            {
                SetFullName = true;

                SetSaveButtonState();
            }

        }

        private void txtBoxEmail_TextChanged(object sender, EventArgs e)
        {
            SetEmailAddress = false;

            // if this has a string & email txtbox has a string enable saving.
            if (txtBoxEmail.Text.Length > 0 && txtBoxEmail.Text.Contains('@') && txtBoxEmail.Text.Contains('.'))
            {
                SetEmailAddress = true;

                SetSaveButtonState();
                
            }
            if (txtBoxEmail.Text.Length == 0 || !txtBoxEmail.Text.Contains('@') || !txtBoxEmail.Text.Contains('.'))
            {                
                SetEmailAddress = false;

                SetSaveButtonState();
            }
        }

        private bool SetSaveButtonState()
        {
            // enable the save button or disable it


            if (SetFullName == true && SetEmailAddress == true)
            {
                this.btnSave.Enabled = true;
                this.btnSave.Refresh();

                LogHelper.Log(LogTarget.File, $"Save Button Successfully enabled. {DateTime.Now}");

                return true;
            }
            else if (SetFullName == false && SetEmailAddress == false || SetFullName == true && SetEmailAddress == false || SetFullName == false && SetEmailAddress == true)
            {
                this.btnSave.Enabled = false;
                this.btnSave.Refresh();

                LogHelper.Log(LogTarget.File, $"Save Button Successfully disabled. {DateTime.Now}");

                return false;
            }

            else
            {
                LogHelper.Log(LogTarget.ErrorFile, $"Setting Save Button State Error: SetFullName = {SetFullName}, SetEmailAddress = {SetEmailAddress}. {DateTime.Now}");

                return false;
            }
                

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAddEditFields();
        }

        private void ClearAddEditFields()
        {
            txtBoxFullName.Text = "";
            txtBoxEmail.Text = "";

            txtBoxFullName.Refresh();
            txtBoxEmail.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // saves the new or edited item to a list. then saves thelist to a ContactsList.CSV
            // then updates the datagridView list to reflect the new list.

        }
    }
}
