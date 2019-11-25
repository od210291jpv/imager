using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ImagerApp.UI_Elements;
using ImagerApp.Screens;
using System.Net;
using System.Net.Http;
using ImagerApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using FFImageLoading;
using FFImageLoading.Forms;


namespace ImagerApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        StackLayout login_page_stack_layout = new StackLayout() {Padding = 2, BackgroundColor = Color.DimGray };
        Entry login_entry = new Entry() {Placeholder = "Login", VerticalOptions = LayoutOptions.Center, PlaceholderColor = Color.White, TextColor = Color.White};
        Entry password_entry = new Entry() { Placeholder = "Password", IsPassword = true, VerticalOptions = LayoutOptions.Center, PlaceholderColor = Color.White, TextColor = Color.White };
        AppButton login_button = new AppButton("Логин");
        AppButton registration_button = new AppButton("Регистрация");
        Label login_failed_label = new Label() { Text = "" };

        public MainPage()
        {
            this.Title = "Login";
            registration_button.Clicked += NavigateToRegistration;
            login_button.Clicked += SendLogin;
            login_entry.Focused += OnLoginEntryFocused;
            login_entry.Unfocused += OnLoginEntryUnfocused;
            password_entry.Focused += OnPasswordEntryfocused;
            password_entry.Unfocused += OnPasswordEntryUnfocused;

            InitializeComponent();
            login_page_stack_layout.Children.Add(login_entry);
            login_page_stack_layout.Children.Add(password_entry);
            login_page_stack_layout.Children.Add(login_button);
            login_page_stack_layout.Children.Add(registration_button);
            login_page_stack_layout.Children.Add(login_failed_label);


            login_page_stack_layout.Padding = new Thickness(50);

            this.Content = login_page_stack_layout;
            
            
        }
        private void OnLoginEntryUnfocused(object sender, EventArgs e)
        {
            if (login_entry.Text == null | login_entry.Text == "")
            {
                login_entry.Placeholder = "Login";
            }
        }

        private void OnLoginEntryFocused(object sender, EventArgs e)
        {
            if (login_entry.Text != "" | login_entry.Text != null )
            {
                login_entry.Placeholder = "";
            }
        }

        private void OnPasswordEntryfocused(object sender, EventArgs e)
        {
            if (password_entry.Text != "" | password_entry.Text != null)
            {
                password_entry.Placeholder = "";
            }
        }

        private void OnPasswordEntryUnfocused(object sender, EventArgs e)
        {
            if (password_entry.Text == null | password_entry.Text == "")
            {
                password_entry.Placeholder = "Password";
            }
        }

        private async void NavigateToRegistration(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationScreen());
        }

        private async void SendLogin(object sender, EventArgs e)
        {


            var credentials = new UserCredentials {Username = login_entry.Text, Password = password_entry.Text };
            string json = JsonConvert.SerializeObject(credentials);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync("http://sigmatestqa.pythonanywhere.com:80/login/", content);


            var respose_content = await response.Content.ReadAsStringAsync();
            JObject o = JObject.Parse(respose_content);
            var auth_info = JsonConvert.DeserializeObject<AuthorizationResponce>(o.ToString());
            if (auth_info.State == "ok")
            {
                await Navigation.PushAsync(new MainMenu());
            }
            else
            {
                
                login_failed_label.TextColor = Color.Red;
                login_failed_label.Text = "Авторизация не удалась\n Проверьте логин или пароль";
            }

        }
    }
}
