using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ImagerApp.UI_Elements;
using ImagerApp.Screens;

namespace ImagerApp.Screens
{
    class RegistrationScreen: ContentPage
    {
        StackLayout registration_page_stack_layout = new StackLayout() { Padding = 2 };
        Label username_label = new Label() {Text = "Ведите имя пользователя" };
        Label password_label = new Label() {Text = "Ведите пароль" };
        Label repeat_password_label = new Label() {Text = "Повторите пароль" };
        Entry login_register_entry = new Entry() {Placeholder = "Login" };
        Entry password_register_entry = new Entry() {Placeholder = "Enter password", IsPassword = true };
        Entry repeat_password_register_entry = new Entry() {Placeholder = "Repeat password", IsPassword = true };
        AppButton reg_button = new AppButton("Зарегистрировать нового пользователя");
        Button dev_menu_button = new Button() {Text= "dev menu", BackgroundColor= Color.White, TextColor = Color.MediumSpringGreen };


        public RegistrationScreen()
        {
            dev_menu_button.VerticalOptions = LayoutOptions.Start;
            dev_menu_button.HorizontalOptions = LayoutOptions.Start;

            dev_menu_button.Clicked += NavigateToDEvMenu;

            this.Title = "Registration";
            registration_page_stack_layout.Padding = new Thickness(50);
            registration_page_stack_layout.Children.Add(username_label);
            registration_page_stack_layout.Children.Add(login_register_entry);
            registration_page_stack_layout.Children.Add(password_label);
            registration_page_stack_layout.Children.Add(password_register_entry);
            registration_page_stack_layout.Children.Add(repeat_password_label);
            registration_page_stack_layout.Children.Add(repeat_password_register_entry);
            registration_page_stack_layout.Children.Add(reg_button);
            registration_page_stack_layout.Children.Add(dev_menu_button);

            this.Content = registration_page_stack_layout;


        }

        private async void NavigateToDEvMenu(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DevelopmentMenu());
        }
    }
}
