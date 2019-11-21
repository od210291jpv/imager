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


namespace ImagerApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        StackLayout login_page_stack_layout = new StackLayout() {Padding = 2 };
        Entry login_entry = new Entry() {Placeholder = "Login", VerticalOptions = LayoutOptions.Center};
        Entry password_entry = new Entry() { Placeholder = "Password", IsPassword = true, VerticalOptions = LayoutOptions.Center };
        AppButton login_button = new AppButton("Логин");
        AppButton registration_button = new AppButton("Регистрация");

        public MainPage()
        {
            this.Title = "Login";
            registration_button.Clicked += NavigateToRegistration;
            login_button.Clicked += SendLogin;
            InitializeComponent();
            login_page_stack_layout.Children.Add(login_entry);
            login_page_stack_layout.Children.Add(password_entry);
            login_page_stack_layout.Children.Add(login_button);
            login_page_stack_layout.Children.Add(registration_button);


            login_page_stack_layout.Padding = new Thickness(50);

            this.Content = login_page_stack_layout;
            
            
        }

        private async void NavigateToRegistration(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationScreen());
        }

        //public class AuthorizationState

        private async void SendLogin(object sender, EventArgs e)
        {


            var credentials = new UserCredentials {Username = login_entry.Text, Password = password_entry.Text };
            Dictionary<string, string> credss = new Dictionary<string, string>(2);
            string json = JsonConvert.SerializeObject(credentials);


            string host_url = "http://sigmatestqa.pythonanywhere.com:80/login/";
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri(host_url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(json, Encoding.UTF8, "application/json-patch+json");
            HttpResponseMessage response = await client.SendAsync(request);

            var respose_content = await response.Content.ReadAsStringAsync();

            JObject o = JObject.Parse(respose_content);
            var state_value = o.SelectToken(@"$.state");
            var auth_info = JsonConvert.DeserializeObject<AuthorizationResponce>(state_value.ToString());

            Label auth_state = new Label() {Text = Convert.ToString(auth_info) };


            //auth_state.Text = auth_info.State;
            login_page_stack_layout.Children.Add(auth_state);

            /////////


        }
    }
}
