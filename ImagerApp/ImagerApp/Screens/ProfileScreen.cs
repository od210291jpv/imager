using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ImagerApp.UI_Elements;
using ImagerApp.Screens;

namespace ImagerApp.Screens
{
    class ProfileScreen: ContentPage
    {
        ScrollView base_scroll = new ScrollView();
        StackLayout profile_stack_layout = new StackLayout() { BackgroundColor = Color.DimGray };
        Image avatar_img = new Image() {Source = "https://assets.pernod-ricard.com/nz/media_images/test.jpg?hUV74FvXQrWUBk1P2.fBvzoBUmjZ1wct" };
        AppLabel username_label = new AppLabel() {Text = "Username" };
        AppLabel Friends = new AppLabel() {Text = "Friends: 100" };
        AppLabel Publications = new AppLabel() {Text = "Publications: 100" };
        AppLabel Messages = new AppLabel() {Text = "Messages: 100" };
        AppButton find_friends_button = new AppButton("Find Friends") {Margin = new Thickness(2.5), WidthRequest = Application.Current.MainPage.Width/2 };
        AppButton messages_button = new AppButton("My Messages") { Margin = new Thickness(2.5), WidthRequest = Application.Current.MainPage.Width / 2 };
       


        public ProfileScreen()
        {
            this.Title = "Profile";

            base_scroll.Content = profile_stack_layout;
            profile_stack_layout.Padding = new Thickness(0);
            profile_stack_layout.Margin = new Thickness(0);
            profile_stack_layout.HorizontalOptions = LayoutOptions.Start;
            profile_stack_layout.WidthRequest = Application.Current.MainPage.Width;

            profile_stack_layout.Children.Add(avatar_img);
            profile_stack_layout.Children.Add(username_label);
            profile_stack_layout.Children.Add(Friends);
            profile_stack_layout.Children.Add(Publications);
            profile_stack_layout.Children.Add(Messages);
            profile_stack_layout.Children.Add(find_friends_button);
            profile_stack_layout.Children.Add(messages_button);

            avatar_img.Scale = 1;
            avatar_img.BackgroundColor = Color.Black;
            avatar_img.WidthRequest = Application.Current.MainPage.Width;
            avatar_img.HeightRequest = Application.Current.MainPage.Height / 3;
            



            this.Content = base_scroll;
        }
    }
}
