using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ImagerApp.UI_Elements;
using ImagerApp.Screens;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ImagerApp.Constants;
using ImagerApp.Models;



namespace ImagerApp.Screens
{
    class FavoritesScreen: ContentPage
    {
        ScrollView favs_scroll = new ScrollView() { Orientation = ScrollOrientation.Vertical };
        StackLayout favs_stack = new StackLayout() { Spacing = 2.5, BackgroundColor = Color.DimGray };
        AppButton refresh_favs_button = new AppButton("Click to refresh") { Margin = new Thickness(2.5) };
        string user_login;
        string user_password;


        public FavoritesScreen(string login, string password)
        {
            this.user_login = login;
            this.user_password = password;
            this.Title = "Favorites";

            GetFavoritePostsLinks(this, new EventArgs());
            refresh_favs_button.Clicked += RefreshFavs;
            favs_scroll.Content = favs_stack;
            favs_stack.Children.Add(refresh_favs_button);
            this.Content = favs_scroll;
        }

        private async void GetFavoritePostsLinks(object sender, EventArgs e)
        {
            var credentials = new UserCredentials { Username = user_login, Password = user_password };
            string json = JsonConvert.SerializeObject(credentials);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(Common.GET_MY_FAVS_URL1, content);

            var respose_content = await response.Content.ReadAsStringAsync();
            JObject o = JObject.Parse(respose_content);
            var all_favorites = JsonConvert.DeserializeObject<Favorites>(o.ToString());
            for (int i = 0; i < all_favorites.favorites.Count; i++)
            {
                var pub = all_favorites.favorites[i];
                ImageFrame publication_frame = new ImageFrame($"{pub[1]}", $"{Common.BASE_URL1}{pub[0]}") { Login = this.user_login, Image_id = Convert.ToInt32(pub[2]) };

                favs_stack.Children.Add(publication_frame);

            }
        }

        private void RefreshFavs(object sender, EventArgs e)
        {
            favs_stack.Children.Clear();
            favs_stack.Children.Add(refresh_favs_button);
            GetFavoritePostsLinks(this, new EventArgs());
        }

    }
}
