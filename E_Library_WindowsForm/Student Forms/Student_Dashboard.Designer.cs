namespace E_Library_WindowsForm
{
    partial class Student_Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblBooks = new System.Windows.Forms.Label();
            this.lblLogOut = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProfile = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.SaddleBrown;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(173, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(627, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Student Dashboard";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBooks
            // 
            this.lblBooks.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBooks.ForeColor = System.Drawing.Color.Black;
            this.lblBooks.Location = new System.Drawing.Point(-1, 196);
            this.lblBooks.Name = "lblBooks";
            this.lblBooks.Size = new System.Drawing.Size(184, 34);
            this.lblBooks.TabIndex = 3;
            this.lblBooks.Text = "Books";
            this.lblBooks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBooks.Click += new System.EventHandler(this.lblBooks_Click);
            // 
            // lblLogOut
            // 
            this.lblLogOut.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogOut.ForeColor = System.Drawing.Color.Black;
            this.lblLogOut.Location = new System.Drawing.Point(-4, 241);
            this.lblLogOut.Name = "lblLogOut";
            this.lblLogOut.Size = new System.Drawing.Size(175, 34);
            this.lblLogOut.TabIndex = 5;
            this.lblLogOut.Text = "Log Out";
            this.lblLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLogOut.Click += new System.EventHandler(this.lblLogOut_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SaddleBrown;
            this.panel1.Controls.Add(this.lblProfile);
            this.panel1.Controls.Add(this.lblLogOut);
            this.panel1.Controls.Add(this.lblBooks);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 450);
            this.panel1.TabIndex = 6;
            // 
            // lblProfile
            // 
            this.lblProfile.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfile.ForeColor = System.Drawing.Color.Black;
            this.lblProfile.Location = new System.Drawing.Point(-1, 144);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(187, 34);
            this.lblProfile.TabIndex = 6;
            this.lblProfile.Text = "Profile";
            this.lblProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProfile.Click += new System.EventHandler(this.lblProfile_Click);
            // 
            // Student_Dashboard
            // 
            this.BackgroundImage = global::E_Library_WindowsForm.Properties.Resources.BackGround_Image;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.Name = "Student_Dashboard";
            this.Text = "Admin Dashboard";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblBooks;
        private System.Windows.Forms.Label lblLogOut;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblProfile;
    }
}
