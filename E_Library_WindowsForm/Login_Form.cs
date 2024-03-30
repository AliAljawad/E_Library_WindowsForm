using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace E_Library_WindowsForm
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            string email = txtEmail.Text;
            string password = txtPassword.Text;

            // Assuming your API endpoint is E_Library_Api/login
            string apiUrl = "https://localhost:7091/login";

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
                // Set content type
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // Make POST request
                var response = await client.PostAsync(apiUrl, new StringContent(json, Encoding.UTF8, "application/json"));

                // Check if request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read response content
                    string responseContent = await response.Content.ReadAsStringAsync();

                    // Deserialize JSON response to dynamic object
                    dynamic responseData = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);

                    // Extract access token from response
                    string accessToken = responseData.accessToken;
                    // Check if the email contains certain domains associated with admin accounts
                    bool isAdmin = email.Contains("@ids.com");
                    if (accessToken != null)
                    {
                        // Redirect to the appropriate dashboard form
                        if (isAdmin)
                        {
                            this.Hide();
                            Admin_Dashboard dashboard = new Admin_Dashboard();
                            // Pass access token to the dashboard form
                            dashboard.AccessToken = accessToken;
                            dashboard.Show();
                        }
                        else
                        {
                            this.Hide();
                            Student_Dashboard dashboard = new Student_Dashboard();
                            // Pass access token to the dashboard form
                            dashboard.AccessToken = accessToken;
                            dashboard.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Failed to log in. Please try again later.");
                }
            }
        }
    }
}
