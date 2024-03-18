using System.ComponentModel;
using System.Drawing.Imaging;
using System.Net.Http.Headers;
using System.Reflection;
using Newtonsoft.Json;

namespace WinFormsApp2
{
    public partial class dalle : Form
    {
        //Created by Nat, for The AI Observer audience
        public dalle()
        {
            InitializeComponent();
            resultDisplay.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var prompt = promptInput.Text;
            if (string.IsNullOrEmpty(prompt))
            {
                MessageBox.Show("Please enter a prompt.");
                return;
            }


            await CallDalleApi(prompt);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resultDisplay.Image.Save(@"E:\dalle\image.png", ImageFormat.Png);
        }
        private async Task CallDalleApi(string userPrompt, string imageDimension = "1024x1024", string imageQuality = "hd", string model = "dall-e-3", int nbFinalImage = 1)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "API-KEY-HERE");

                var requestBody = JsonConvert.SerializeObject(new
                {
                    model = model,
                    prompt = userPrompt,
                    size = imageDimension,
                    quality = imageQuality,
                    n = nbFinalImage
                });

                var content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync("https://api.openai.com/v1/images/generations", content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"API Error: {response.StatusCode} - {responseString}");
                        MessageBox.Show("An error occurred while fetching the image. Please check the console for more details.");
                        return;
                    }

                    var data = JsonConvert.DeserializeObject<dynamic>(responseString);
                    DisplayResult(userPrompt, data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message + "\nStack Trace: " + ex.StackTrace);
                    MessageBox.Show("An error occurred while fetching the image. Please check the console for more details.");
                }
            }
        }
        private void DisplayResult(string prompt, dynamic data)
        {
            var imageUrl = data.data[0].url;
            resultDisplay.Load(imageUrl.ToString());
            promptDisplay.Text = prompt;
            resultDisplay.LoadCompleted += ResultDisplay_LoadCompleted;
        }
        private void ResultDisplay_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Calculate new form size
            int newWidth = resultDisplay.Image.Width + resultDisplay.Left + 20; // 20 for padding or margins
            int newHeight = resultDisplay.Image.Height + resultDisplay.Top + 40; // 40 for padding, margins, and title bar

            // Get the screen working area
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;

            // Ensure the new size doesn't exceed screen size
            if (newWidth > screen.Width)
                newWidth = screen.Width;
            if (newHeight > screen.Height)
                newHeight = screen.Height;

            // Set the new size
            this.Size = new Size(newWidth, newHeight);
        }
    }
}