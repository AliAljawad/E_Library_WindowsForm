using System;
using System.Windows.Forms;

namespace E_Library_WindowsForm
{
    partial class BooksForm
    {
        // Define controls for adding a book
        private Label lblAddNewBook;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtDescription;
        private DateTimePicker datePickerPublishDate;
        private Button btnAddBook;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewBooks;
        private TextBox textBoxSearch;

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
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.lblAddNewBook = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.datePickerPublishDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPublishDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEditQuantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.EditButton = new System.Windows.Forms.Button();
            this.EditPublishDate = new System.Windows.Forms.DateTimePicker();
            this.txtEditDesc = new System.Windows.Forms.TextBox();
            this.txtEditAuthor = new System.Windows.Forms.TextBox();
            this.txtEditTitle = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.LabelEditGenre = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbGenres = new System.Windows.Forms.ComboBox();
            this.cmbEditGenre = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Location = new System.Drawing.Point(12, 487);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.ReadOnly = true;
            this.dataGridViewBooks.RowHeadersWidth = 51;
            this.dataGridViewBooks.Size = new System.Drawing.Size(1173, 342);
            this.dataGridViewBooks.TabIndex = 0;
            this.dataGridViewBooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBooks_CellClick);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(410, 449);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(300, 22);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // lblAddNewBook
            // 
            this.lblAddNewBook.AutoSize = true;
            this.lblAddNewBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddNewBook.Location = new System.Drawing.Point(200, 53);
            this.lblAddNewBook.Name = "lblAddNewBook";
            this.lblAddNewBook.Size = new System.Drawing.Size(0, 25);
            this.lblAddNewBook.TabIndex = 2;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(231, 44);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 22);
            this.txtTitle.TabIndex = 3;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(231, 90);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(200, 22);
            this.txtAuthor.TabIndex = 4;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(231, 138);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 22);
            this.txtDescription.TabIndex = 5;
            // 
            // datePickerPublishDate
            // 
            this.datePickerPublishDate.Location = new System.Drawing.Point(231, 266);
            this.datePickerPublishDate.Name = "datePickerPublishDate";
            this.datePickerPublishDate.Size = new System.Drawing.Size(200, 22);
            this.datePickerPublishDate.TabIndex = 6;
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(263, 294);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(100, 25);
            this.btnAddBook.TabIndex = 7;
            this.btnAddBook.Text = "Add Book";
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(118, 53);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(33, 16);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Title";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(118, 96);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(45, 16);
            this.lblAuthor.TabIndex = 9;
            this.lblAuthor.Text = "Author";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(118, 144);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(75, 16);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Description";
            // 
            // lblPublishDate
            // 
            this.lblPublishDate.AutoSize = true;
            this.lblPublishDate.Location = new System.Drawing.Point(118, 272);
            this.lblPublishDate.Name = "lblPublishDate";
            this.lblPublishDate.Size = new System.Drawing.Size(83, 16);
            this.lblPublishDate.TabIndex = 11;
            this.lblPublishDate.Text = "Publish Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Quantity";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(231, 187);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(200, 22);
            this.txtQuantity.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(288, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 22);
            this.label2.TabIndex = 14;
            this.label2.Text = "Add Book";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Genre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(849, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 22);
            this.label4.TabIndex = 29;
            this.label4.Text = "Edit Book";
            // 
            // txtEditQuantity
            // 
            this.txtEditQuantity.Location = new System.Drawing.Point(798, 231);
            this.txtEditQuantity.Name = "txtEditQuantity";
            this.txtEditQuantity.Size = new System.Drawing.Size(200, 22);
            this.txtEditQuantity.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(685, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(685, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "Publish Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(685, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "Description";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(685, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 16);
            this.label8.TabIndex = 24;
            this.label8.Text = "Author";
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(755, 346);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(100, 25);
            this.EditButton.TabIndex = 23;
            this.EditButton.Text = "Edit Book";
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // EditPublishDate
            // 
            this.EditPublishDate.Location = new System.Drawing.Point(798, 318);
            this.EditPublishDate.Name = "EditPublishDate";
            this.EditPublishDate.Size = new System.Drawing.Size(200, 22);
            this.EditPublishDate.TabIndex = 22;
            // 
            // txtEditDesc
            // 
            this.txtEditDesc.Location = new System.Drawing.Point(798, 190);
            this.txtEditDesc.Name = "txtEditDesc";
            this.txtEditDesc.Size = new System.Drawing.Size(200, 22);
            this.txtEditDesc.TabIndex = 21;
            // 
            // txtEditAuthor
            // 
            this.txtEditAuthor.Location = new System.Drawing.Point(798, 142);
            this.txtEditAuthor.Name = "txtEditAuthor";
            this.txtEditAuthor.Size = new System.Drawing.Size(200, 22);
            this.txtEditAuthor.TabIndex = 20;
            // 
            // txtEditTitle
            // 
            this.txtEditTitle.Location = new System.Drawing.Point(798, 90);
            this.txtEditTitle.Name = "txtEditTitle";
            this.txtEditTitle.Size = new System.Drawing.Size(200, 22);
            this.txtEditTitle.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(685, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 16);
            this.label10.TabIndex = 31;
            this.label10.Text = "Title";
            // 
            // LabelEditGenre
            // 
            this.LabelEditGenre.AutoSize = true;
            this.LabelEditGenre.Location = new System.Drawing.Point(685, 271);
            this.LabelEditGenre.Name = "LabelEditGenre";
            this.LabelEditGenre.Size = new System.Drawing.Size(44, 16);
            this.LabelEditGenre.TabIndex = 32;
            this.LabelEditGenre.Text = "Genre";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(685, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 16);
            this.label9.TabIndex = 34;
            this.label9.Text = "Book ID";
            // 
            // txtBookID
            // 
            this.txtBookID.Location = new System.Drawing.Point(798, 44);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.Size = new System.Drawing.Size(200, 22);
            this.txtBookID.TabIndex = 33;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(879, 346);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.TabIndex = 38;
            this.btnSave.Text = "Save ";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbGenres
            // 
            this.cmbGenres.FormattingEnabled = true;
            this.cmbGenres.Location = new System.Drawing.Point(231, 223);
            this.cmbGenres.Name = "cmbGenres";
            this.cmbGenres.Size = new System.Drawing.Size(200, 24);
            this.cmbGenres.TabIndex = 39;
            // 
            // cmbEditGenre
            // 
            this.cmbEditGenre.FormattingEnabled = true;
            this.cmbEditGenre.Location = new System.Drawing.Point(798, 269);
            this.cmbEditGenre.Name = "cmbEditGenre";
            this.cmbEditGenre.Size = new System.Drawing.Size(200, 24);
            this.cmbEditGenre.TabIndex = 40;
            // 
            // BooksForm
            // 
            this.ClientSize = new System.Drawing.Size(1186, 908);
            this.Controls.Add(this.cmbEditGenre);
            this.Controls.Add(this.cmbGenres);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBookID);
            this.Controls.Add(this.LabelEditGenre);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEditQuantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.EditPublishDate);
            this.Controls.Add(this.txtEditDesc);
            this.Controls.Add(this.txtEditAuthor);
            this.Controls.Add(this.txtEditTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPublishDate);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.datePickerPublishDate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblAddNewBook);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.dataGridViewBooks);
            this.Name = "BooksForm";
            this.Text = "Books";
            this.Load += new System.EventHandler(this.BooksForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private Label lblTitle;
        private Label lblAuthor;
        private Label lblDescription;
        private Label lblPublishDate;
        private object newSystem;
        private Label label1;
        private TextBox txtQuantity;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtEditQuantity;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button EditButton;
        private DateTimePicker EditPublishDate;
        private TextBox txtEditDesc;
        private TextBox txtEditAuthor;
        private TextBox txtEditTitle;
        private Label label10;
        private Label LabelEditGenre;
        private Label label9;
        private TextBox txtBookID;
        private Button btnSave;
        private ComboBox cmbGenres;
        private ComboBox cmbEditGenre;

        #endregion

        // Additional code for event handlers, methods, etc.
    }
}
