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
    public partial class Admin_Dashboard : Form
    {
        public string AccessToken;
        public Admin_Dashboard()
        {
            InitializeComponent();
        }
        private void lblUsers_Click_1(object sender, EventArgs e)
        {
            Users_Form users = new Users_Form();
            users.AccessToken = AccessToken;
            users.Show();

        }

        private void lblBooks_Click(object sender, EventArgs e)
        {
            BooksForm books = new BooksForm();
            books.AccessToken = AccessToken;
            books.Show();
        }

        private void lblProfile_Click(object sender, EventArgs e)
        {
            Profile_Form profile_Form = new Profile_Form();
            profile_Form.AccessToken = AccessToken;
            profile_Form.Show();
        }

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            AccessToken = null;
            this.Close();
            Login_Form loginForm = new Login_Form();
            loginForm.Show();

        }
    }
    }

