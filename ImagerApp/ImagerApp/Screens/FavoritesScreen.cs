using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ImagerApp.UI_Elements;
using ImagerApp.Screens;


namespace ImagerApp.Screens
{
    class FavoritesScreen: ContentPage
    {
        ListView images_list = new ListView();


        public FavoritesScreen()
        {
            this.Title = "Favorites";
        }

        private async void GetFavoritePostsLinks(object sender, EventArgs e)
        {

        }

    }
}
