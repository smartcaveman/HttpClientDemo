﻿using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace HttpClientDemo.WebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session["test"] = "test content";
        }

        protected void ButtonRun_Click(object sender, EventArgs e)
        {
            var option = TextBoxOption.Text;
            var response = ClientNetFX.Program.GetResponseAsync(option).Result;
            TextBoxResponse.Text = response;
        }

        protected void ButtonRunAsync_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ButtonRunAsync_ClickAsync));
        }

        private async Task ButtonRunAsync_ClickAsync()
        {
            var option = TextBoxOption.Text;
            var response = await ClientNetFX.Program.GetResponseAsync(option);
            TextBoxResponse.Text = response;
        }
    }
}