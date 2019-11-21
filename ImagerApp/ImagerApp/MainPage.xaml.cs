using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImagerApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        StackLayout login_page_stack_layout = new StackLayout() {Padding = 2 };
        Entry login_entry = new Entry() {Placeholder = "Login", VerticalOptions = LayoutOptions.Center};
        Entry password_entry = new Entry() {IsPassword = true, VerticalOptions = LayoutOptions.Center };
        Button login_button = new Button() {
            Text = "Логин",
            BackgroundColor = Color.MediumSpringGreen,
            TextColor = Color.White,
            VerticalOptions = LayoutOptions.Center,
            
        };

        Button registration_button = new Button() {
            Text = "Регистрация",
            BackgroundColor = Color.MediumSpringGreen,
            TextColor = Color.White,
            VerticalOptions = LayoutOptions.Center
        };
        public MainPage()
        {
            InitializeComponent();
            login_page_stack_layout.Children.Add(login_entry);
            login_page_stack_layout.Children.Add(password_entry);
            login_page_stack_layout.Children.Add(login_button);
            login_page_stack_layout.Children.Add(registration_button);
            login_page_stack_layout.Padding = new Thickness(50);

            this.Content = login_page_stack_layout;
            
            
        }
    }
}
