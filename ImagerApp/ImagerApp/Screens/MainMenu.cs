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
        FeedScreen feed = new FeedScreen();
        FavoritesScreen favorite = new FavoritesScreen();
        public MainMenu()
        {
            this.Children.Add(profile);
            this.Children.Add(feed);
            this.Children.Add(favorite);
        }
    }
}
