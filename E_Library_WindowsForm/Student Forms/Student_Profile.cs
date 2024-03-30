using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Library_WindowsForm
{
    public partial class Student_Profile : Form
    {
        private bool isEditing = false;
        internal string AccessToken;

        public Student_Profile()
        {
            InitializeComponent();
            LoadDummyData();
            SetReadOnlyMode();
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            SetReadOnlyMode();
        }
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            SetEditMode();
        }
        private void SetEditMode()
        {
            // Enable editing mode
            btnSaveChanges.Enabled = true;
            txtName.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtAge.ReadOnly = false;
            txtOldPassword.ReadOnly = false;
            txtNewPassword.ReadOnly = false;
            btnSaveChanges.Enabled = true;
            txtName.Enabled = true;
            txtEmail.Enabled = true;
            txtPhone.Enabled = true;
            txtAge.Enabled = true;
            txtOldPassword.Enabled = true;
            txtNewPassword.Enabled = true;
        }
        private void LoadDummyData()
        {
            txtName.Text = "John Doe";
            txtEmail.Text = "john.doe@example.com";
            txtPhone.Text = "+1234567890";
            txtAge.Text = "30";
            txtOldPassword.Text = "oldpassword";
        }


        private void SetReadOnlyMode()
        {
            // Set back to read-only mode
            txtName.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtAge.ReadOnly = true;
            txtOldPassword.ReadOnly = true;
            txtNewPassword.ReadOnly = true;
            btnSaveChanges.Enabled = false;
            txtName.Enabled = false;
            txtEmail.Enabled = false;
            txtPhone.Enabled = false;
            txtAge.Enabled = false;
            txtOldPassword.Enabled = false;
            txtNewPassword.Enabled = false;
        }
        
    }
}
