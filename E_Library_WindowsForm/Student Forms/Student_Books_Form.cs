    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace E_Library_WindowsForm
    {
        public partial class Student_Books_Form : Form
        {
            private List<Book> books = new List<Book>();
        internal string AccessToken;

        public class Book
            {
                public string Guid { get; set; }
                public string Title { get; set; }
                public string Author { get; set; }
                public string AvailabilityStatus { get; set; }
                public DateTime PublishDate { get; set; }
                public string ImageURL { get; set; }
                public string Description { get; set; }
                public int Quantity { get; set; }
                public int AvailableQuantity { get; set; }
                public int BorrowedQuantity { get; set; }
                public string Genre { get; set; }
            }
            

            public  Student_Books_Form()
            {
                InitializeComponent();
                _ = LoadBooks();
                InitializeDataGridView();
            }

            private void InitializeDataGridView()
            {
                dataGridViewBooks.AutoGenerateColumns = false; // Set AutoGenerateColumns to false

                // Define columns manually
                dataGridViewBooks.Columns.Add("Title", "Title");
                dataGridViewBooks.Columns.Add("Author", "Author");
                dataGridViewBooks.Columns.Add("Description", "Description");
                dataGridViewBooks.Columns.Add("PublishDate", "Publish Date");
                dataGridViewBooks.Columns.Add("GenreName", "Genre");
                dataGridViewBooks.Columns.Add("Availability Status", "Availability Status");

                // Add "Return" button column
                DataGridViewButtonColumn returnButtonColumn = new DataGridViewButtonColumn();
                returnButtonColumn.HeaderText = "Return Book";
                returnButtonColumn.Text = "Return";
                returnButtonColumn.UseColumnTextForButtonValue = true;
                dataGridViewBooks.Columns.Add(returnButtonColumn);

                // Add "Borrow" button column
                DataGridViewButtonColumn borrowButtonColumn = new DataGridViewButtonColumn();
                borrowButtonColumn.HeaderText = "Borrow Book";
                borrowButtonColumn.Text = "Borrow";
                borrowButtonColumn.UseColumnTextForButtonValue = true;
                dataGridViewBooks.Columns.Add(borrowButtonColumn);
            }


            private async void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridViewBooks.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                // Check if the clicked cell is the "Return Book" button
                if (dataGridViewBooks.Columns[e.ColumnIndex].HeaderText == "Return Book")
                {
                    // Get the selected book
                    Book selectedBook = books[e.RowIndex];
                    string bookTitle = selectedBook.Title;

                    // Show a confirmation dialog
                    DialogResult result = MessageBox.Show($"Are you sure you want to return and delete the book '{bookTitle}'?", "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // If the user clicks "Yes", proceed with deletion
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // Call the delete API to remove the book
                            using (var client = new HttpClient())
                            {
                                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7091/api/Book/{selectedBook.Guid}?bookGuid={selectedBook.Guid}");

                                if (response.IsSuccessStatusCode)
                                {
                                    // Remove the book from the list
                                    books.RemoveAt(e.RowIndex);
                                    // Refresh the DataGridView
                                    await LoadBooks();

                                    MessageBox.Show($"The book '{bookTitle}' has been returned and removed from the list.", "Book Returned and Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show($"Failed to delete the book. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (HttpRequestException ex)
                        {
                            MessageBox.Show($"Failed to connect to the server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                // Check if the clicked cell is the "Borrow" button
                else if (dataGridViewBooks.Columns[e.ColumnIndex].HeaderText == "Borrow Book")
                {
                    string availabilityStatus = dataGridViewBooks.Rows[e.RowIndex].Cells["Availability Status"].Value.ToString();
                    Book selectedBook = books[e.RowIndex];
                    string bookTitle = selectedBook.Title;
                    // Check if the availability status is "Out of Stock"
                    if (availabilityStatus == "Out of Stock")
                    {
                        MessageBox.Show($"The book {bookTitle} is out of stock please choose another book or try again later.", "Can't borrow book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                } 


            }
            else
        {
            // Update text fields with selected row data
            DataGridViewRow row = dataGridViewBooks.Rows[e.RowIndex];
            txtTitle.Text = row.Cells["Title"].Value?.ToString();
            txtAuthor.Text = row.Cells["Author"].Value?.ToString();
            txtDesc.Text = row.Cells["Description"].Value?.ToString();
            txtPublishDate.Text = row.Cells["PublishDate"].Value?.ToString();
            //txtGenre.Text = row.Cells["Genre"].Value?.ToString();
        }
    }

            private async Task LoadBooks()
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        var response = await client.GetAsync("https://localhost:7091/api/Book");

                        if (response.IsSuccessStatusCode)
                        {
                            var booksData = await response.Content.ReadFromJsonAsync<List<Book>>();
                            if (booksData != null)
                            { 
                                books.Clear();
                                foreach (var book in booksData)
                                {
                                    books.Add(book);
                                
                                }
                                RefreshDataGridView(books);
                            }
                            else
                            {
                                MessageBox.Show("No books data received from the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Failed to retrieve books. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Failed to connect to the server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        private void RefreshDataGridView(List<Book> books)
        {
            dataGridViewBooks.Rows.Clear();
            foreach (var book in books)
            {
                string availabilityStatus = CalculateAvailabilityStatus(book);
                dataGridViewBooks.Rows.Add(
                    book.Title,
                    book.Author,
                    book.Description,
                    book.PublishDate.ToString("MM/dd/yyyy"),
                    book.Genre,
                    availabilityStatus
                );
            }
        }
        private string CalculateAvailabilityStatus(Book book)
        {
            if (book.AvailableQuantity > book.BorrowedQuantity)
            {
                return "Available";
            }
            else
            {
                return "Out of Stock";
            }
        }


        private async void  refreshButton_Click(object sender, EventArgs e)
            {
                await LoadBooks();
            }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.ToLower(); // Convert search text to lowercase for case-insensitive search

            // Filter books based on title or author containing the search text
            List<Book> filteredBooks = books.Where(book =>
                book.Title.ToLower().Contains(searchText) ||
                book.Author.ToLower().Contains(searchText)
            ).ToList();

            // Refresh the DataGridView with filtered books
            RefreshDataGridView(filteredBooks);
        }

    }
}
