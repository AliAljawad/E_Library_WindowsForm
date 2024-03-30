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
    public partial class Student_Dashboard : Form
    {
        internal string AccessToken;

        public Student_Dashboard()
        {
            InitializeComponent();
        }
        private void lblBooks_Click(object sender, EventArgs e)
        {
            Student_Books_Form books = new Student_Books_Form();
            books.AccessToken = AccessToken;
            books.Show();
        }

        private void lblProfile_Click(object sender, EventArgs e)
        {
            Student_Profile profile_Form = new Student_Profile();
            profile_Form.AccessToken = AccessToken;   
            profile_Form.Show();
        }

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            AccessToken = null;
            this.Close();

            // Show the login form
            Login_Form loginForm = new Login_Form();
            loginForm.Show();
        }

    }
}

