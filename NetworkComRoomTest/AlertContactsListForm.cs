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

        private int selectedID = -1;
        private bool loadingContactsFile = false;
        private bool savingContactsFile = false;

        List<ContactInfo> contactData = new List<ContactInfo>();


        public AlertContactsListForm()
        {
            InitializeComponent();

            // this is to show grid even if there is not data to display
    
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ClearAddEditFields();

            UpdateContactInfoList();

            // save contacts to file
            if (contactData.Count > 0)
            {
                SaveFile saveContacts = new SaveFile();
                saveContacts.ContactInfo(contactData);
            }

            // switch to main form
            Form1.instance.alertContactButton = !Form1.instance.alertContactButton;

            Form1.instance.alertContactsListForm.Enabled = false;
            Form1.instance.alertContactsListForm.Visible = false;

            
            Form1.instance.Enabled = true;
            Form1.instance.Activate();
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

            
            LogHelper.Log(LogTarget.ErrorFile, $"Setting Save Button State Error: SetFullName = {SetFullName}, SetEmailAddress = {SetEmailAddress}. {DateTime.Now}");

            return false;
        }

        private int GetNextNewUserIndex()
        {
            if (dataGridView1.Rows.Count == 0)
                return 0;

            int userCounter = 0;
            foreach (var contact in dataGridView1.Rows)
            {
                userCounter++;
            }
            

            return userCounter;
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

            AddNewUser();




        }

        private void AddNewUser()
        {
            // check if user exists already
            if (!NewOrExistingUser())
            {
                int newID = GetNextNewUserIndex();

                dataGridView1.Rows.Add(newID, txtBoxFullName.Text, txtBoxEmail.Text);

                ClearAddEditFields();
            }
            else
            {
                dataGridView1.Rows[selectedID].Cells[1].Value = txtBoxFullName.Text;
                dataGridView1.Rows[selectedID].Cells[2].Value = txtBoxEmail.Text;

                ClearAddEditFields();
                selectedID = -1;
            }

        }

        private bool NewOrExistingUser()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow user in dataGridView1.Rows)
                {
                    // does the current user's email exsit in the datagrid already?
                    if (user.Cells[2].Value.ToString().Contains(txtBoxEmail.Text))
                    {
                        user.Cells[1].Value = txtBoxFullName.Text;
                        user.Cells[2].Value = txtBoxEmail.Text;

                        return true;
                    }
                }
            }

            return false;
        }

        private void RemoveSelectedContact()
        {
            if (dataGridView1.Rows.Count == 0)
                return;

            // check if we have a selected contact
            

            // get index of the selected object and remove it
          //  int selectedID = dataGridView1.SelectedRows[dataGridView1.SelectionChanged]


            // adjust all remaining indexes to be index -= 1 or reindex the entier list.

        }

        private void EditSelectedUser(int selectedID)
        {

            // with the selected row info like ID find this user and load that info into the 
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow user in dataGridView1.Rows)
                {
                    if (Convert.ToInt32(user.Cells[0].Value) == selectedID)
                    {
                        selectedID = Convert.ToInt32(user.Cells[0].Value);
                        txtBoxFullName.Text = user.Cells[1].Value.ToString();
                        txtBoxEmail.Text = user.Cells[2].Value.ToString();
                    }
                }
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.RowCount == 0)
            {
                btnRemove.Enabled = false;
                btnEditSelected.Enabled = false;

                return;
            }


            //selectedID = dataGridView1.SelectedRows[0].Index;
            selectedID = dataGridView1.CurrentCell.RowIndex;

            btnRemove.Enabled = true;
            btnEditSelected.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                return;

            selectedID = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows.RemoveAt(selectedID);

            UpdateDataGridViewsIndexes();

        }

        private void UpdateDataGridViewsIndexes()
        {
            if (dataGridView1.RowCount == 0)
                return;

            int currentIndex = 0;
            foreach (DataGridViewRow user in dataGridView1.Rows)
            {
                user.Cells[0].Value = currentIndex;

                currentIndex++;
            }
        }

        private void btnEditSelected_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                return;

            selectedID = dataGridView1.CurrentCell.RowIndex;

            EditSelectedUser(selectedID);
        }

        private void UpdateContactInfoList()
        {
            if (dataGridView1.Rows.Count == 0)
                return;

            contactData.Clear();


            foreach(DataGridViewRow user in dataGridView1.Rows)
            {
                if (user.Cells[0].Value == null)
                    continue;


                int id = Convert.ToInt32(user.Cells[0].Value);
                string name = user.Cells[1].Value.ToString();
                string email = user.Cells[2].Value.ToString();

                ContactInfo newContact = new ContactInfo(id, name, email);

//LogHelper.Log(LogTarget.File, $"Index: {id}, FullName: {name}, Email: {email} ");

                contactData.Add(newContact);
            }
        }

        private void AlertContactsListForm_Load(object sender, EventArgs e)
        {
            if (loadingContactsFile)
                return;

            loadingContactsFile = true;

            LoadFile loadContacts = new LoadFile();
            loadContacts.ContactInfo(contactData);

            if (contactData.Count > 0)
            {
                LogHelper.Log(LogTarget.File, $"index count of dataGridView BEFORE: {dataGridView1.Rows.Count}");

                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                LogHelper.Log(LogTarget.File, $"index count of dataGridView AFTER: {dataGridView1.Rows.Count}");

                foreach (ContactInfo user in contactData)
                {
                    dataGridView1.Rows.Add(user.ID, user.FullName, user.Email);
                    
                }

                dataGridView1.Refresh();

                loadingContactsFile = false;
            }
        }
    }
}
