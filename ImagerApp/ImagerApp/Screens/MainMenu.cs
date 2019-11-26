using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ImagerApp.UI_Elements;
using ImagerApp.Screens;

namespace ImagerApp.Screens
{
    class MainMenu: TabbedPage
    {
        ProfileScreen profile = new ProfileScreen();
        FeedScreen feed;
        FavoritesScreen favorite;
        public MainMenu(string login, string password)
        {
            this.Title = "Back";
            this.SelectedTabColor = Color.MediumSpringGreen;
            
            this.Children.Add(profile);
            this.Children.Add(feed = new FeedScreen(login, password));
            this.Children.Add(favorite = new FavoritesScreen(login, password));
        }
    }
}
