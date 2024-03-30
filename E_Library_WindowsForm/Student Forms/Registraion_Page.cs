using System;
using System.Windows.Forms;

namespace E_Library_WindowsForm
{
    public partial class Registraion_Page : Form
    {
        public Registraion_Page()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.BackGround_Image;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Login_Form loginForm = new Login_Form();
                loginForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while opening the login form: " + ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Check if any of the text fields are empty
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAge.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all the fields.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            
            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
