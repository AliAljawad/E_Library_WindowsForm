using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Net.Http.Json;
using System.Text.Json;
using System.Linq;
using Azure.Core;
using System.Net.Http.Headers;

namespace E_Library_WindowsForm
{
    public partial class BooksForm : Form
    {
        // Define Book class 
        public class Book
        {
            public Guid Guid { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
            public string AvailabilityStatus { get; set; }
            public int AvailableQuantity { get; set; }
            public int BorrowedQuantity { get; set; }
            public DateTime PublishDate { get; set; }
            public Genre Genre { get; set; }
        }

        // Define Genre class
        public class Genre
        {
            public Guid Guid { get; set; }
            public string GenreName { get; set; }
            public override string ToString()
            {
                return GenreName;
            }
        }

        private List<Book> books = new List<Book>();
        private List<Genre> genres = new List<Genre>();
        internal string AccessToken;

        public BooksForm()
        {
            InitializeComponent();
            NonEditMode();
            LoadBooks();
            LoadGenres();
            dataGridViewBooks.DataSource = books;
        }

        private void SetEditMode()
        {
            // Set TextBoxes to read-only
            txtBookID.ReadOnly = false;
            txtEditTitle.ReadOnly = false;
            txtEditAuthor.ReadOnly = false;
            txtEditDesc.ReadOnly = false;
            EditPublishDate.Enabled = true; // Enable editing for DateTimePicker
            txtEditQuantity.ReadOnly = false;
        }

        private void NonEditMode()
        {
            // Set TextBoxes to read-only
            txtBookID.ReadOnly = true;
            txtEditTitle.ReadOnly = true;
            txtEditAuthor.ReadOnly = true;
            txtEditDesc.ReadOnly = true;
            EditPublishDate.Enabled = false; // Disable editing for DateTimePicker
            txtEditQuantity.ReadOnly = true;
        }

        private async void btnAddBook_Click(object sender, EventArgs e)
        {
            // Check if the quantity is a valid integer
            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Quantity must be a valid integer.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if any of the text fields are empty
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtAuthor.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please fill in all the fields.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Genre selectedGenre = cmbGenres.SelectedItem as Genre; 
            Book newBook = new Book
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Description = txtDescription.Text,
                PublishDate = datePickerPublishDate.Value,
                AvailableQuantity = quantity,
                Quantity = quantity,
                Genre= selectedGenre,
            };
            string jsonData = JsonSerializer.Serialize(newBook);

            try
            {
                using (var client = new HttpClient())
                {
                    // Send a POST request to the API endpoint
                    var response = await client.PostAsync("https://localhost:7091/api/Book", new StringContent(jsonData, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        // Book added successfully
                        MessageBox.Show("Book added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear the form fields
                        ClearFields();

                        // Refresh the books list
                        await LoadBooks();
                    }
                    else
                    {
                        // Failed to add book
                        MessageBox.Show($"Failed to add book. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private async Task LoadGenres()
        {
            try
            {
                genres = await GetGenresFromApi();

                // Populate the ComboBox with genre names
                cmbGenres.DataSource = genres;
                cmbGenres.DisplayMember = "GenreName";
                cmbGenres.ValueMember = "Guid";
                cmbEditGenre.DataSource = genres;
                cmbEditGenre.DisplayMember = "GenreName";
                cmbEditGenre.ValueMember = "Guid";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading genres: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<List<Genre>> GetGenresFromApi()
        {
            List<Genre> retrievedGenres = new List<Genre>();

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("https://localhost:7091/api/Genre");

                    if (response.IsSuccessStatusCode)
                    {
                        retrievedGenres = await response.Content.ReadFromJsonAsync<List<Genre>>();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to retrieve genres. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            return retrievedGenres;
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
                            // Update the books list with fetched data  
                            books = booksData;

                            // Update availability status for each book
                            foreach (var book in books)
                            {
                                book.AvailabilityStatus = CalculateAvailabilityStatus(book);
                            }

                            // Set the DataGridView's DataSource to books
                            dataGridViewBooks.DataSource = books;

                            // Refresh the DataGridView
                            dataGridViewBooks.Refresh();
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


        private void dataGridViewBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewBooks.Rows.Count)
            {
                DataGridViewRow row = dataGridViewBooks.Rows[e.RowIndex];
                txtBookID.Text = row.Cells[0].Value.ToString();
                txtEditTitle.Text = row.Cells["Title"].Value.ToString();
                txtEditAuthor.Text = row.Cells["Author"].Value.ToString();
                txtEditDesc.Text = row.Cells["Description"].Value.ToString();
                EditPublishDate.Value = Convert.ToDateTime(row.Cells["PublishDate"].Value);
                txtEditQuantity.Text = row.Cells["Quantity"].Value.ToString();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Check if any of the required fields are empty
            if (string.IsNullOrEmpty(txtEditTitle.Text) || string.IsNullOrEmpty(txtEditAuthor.Text) || string.IsNullOrEmpty(txtDescription.Text) || string.IsNullOrEmpty(txtEditQuantity.Text))
            {
                MessageBox.Show("Please fill in all the fields.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Retrieve the Book's GUID from the BookID TextBox
            if (!Guid.TryParse(txtBookID.Text, out Guid bookGuid))
            {
                MessageBox.Show("Invalid Book ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a new Book object with the updated data
            Book updatedBook = new Book
            {
                Guid = bookGuid,
                Title = txtEditTitle.Text,
                Author = txtEditAuthor.Text,
                Description = txtDescription.Text,
                PublishDate = EditPublishDate.Value,
                Quantity = int.Parse(txtEditQuantity.Text),
            };

            // Retrieve the selected genre from the cmbGenres ComboBox
            string genreName = cmbEditGenre.SelectedItem?.ToString().Trim();

            // Check if a genre is selected
            if (string.IsNullOrEmpty(genreName))
            {
                MessageBox.Show("Please select a genre.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                // Convert the book object to JSON
                string jsonData = JsonSerializer.Serialize(updatedBook);

                try
                {
                    using (var client = new HttpClient())
                    {
                        // Send a PUT request to the API endpoint with the Book's GUID included
                        var response = await client.PutAsync($"https://localhost:7091/api/Book/{bookGuid}", new StringContent(jsonData, Encoding.UTF8, "application/json"));

                        if (response.IsSuccessStatusCode)
                        {
                            // Book updated successfully
                            MessageBox.Show("Book updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear the form fields
                            ClearFields();

                            // Refresh the books list
                            await LoadBooks();
                        }
                        else
                        {
                            // Failed to update book
                            MessageBox.Show($"Failed to update book. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void EditButton_Click(object sender, EventArgs e)
        {
            SetEditMode();
        }
        private void ClearFields()
        {
            txtEditTitle.Clear();
            txtEditAuthor.Clear();
            txtEditDesc.Clear();
            EditPublishDate.Value = DateTime.Now;
            txtEditQuantity.Clear();
            // Clear other fields if needed
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
        private void RefreshDataGridView(List<Book> books)
        {
            dataGridViewBooks.DataSource = null;
            dataGridViewBooks.DataSource = books;
            dataGridViewBooks.Refresh();
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

        private async void BooksForm_Load(object sender, EventArgs e)
        {
            await LoadGenres();
        }
    }
}
