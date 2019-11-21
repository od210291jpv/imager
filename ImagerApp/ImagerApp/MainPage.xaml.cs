using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ImagerApp.UI_Elements;
using ImagerApp.Screens;

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
    }
}
