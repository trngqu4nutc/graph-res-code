using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string url = "https://graph.facebook.com/me?access_token=abc";
            var result = await GetWebRes(url);
            textBox1.Text = result.ToString();
        }
        private async Task<int> GetWebRes(string url)
        {
            Error resTest = null;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                resTest = await response.Content.ReadAsAsync<Error>();
            }
            return resTest.error.code;
        }
    }
}
