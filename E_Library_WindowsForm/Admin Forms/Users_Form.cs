using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace E_Library_WindowsForm
{
    public partial class Users_Form : Form
    {
        // Assuming you have a method to retrieve the bearer token
        public string AccessToken;

        public Users_Form()
        {
            InitializeComponent();
        }

        private async void btnRegisterUser_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            // Assuming your API endpoint is E_Library_Api/register
            string apiUrl = "https://localhost:7091/register";

            // Prepare the data to send
            var data = new
            {
                email = email,
                password = password
            };

            // Convert data to JSON
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            // Create HttpClient
            using (var client = new HttpClient())
            {
                // Set authorization header with bearer token
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",AccessToken);

                // Set content type
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Make POST request
                var response = await client.PostAsync(apiUrl, new StringContent(json, Encoding.UTF8, "application/json"));

                // Check if request was successful
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("User registered successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to register user. Please try again later.");
                }
            }
        }
    }
}
