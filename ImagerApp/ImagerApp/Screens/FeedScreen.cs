using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ImagerApp.UI_Elements;
using ImagerApp.Screens;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ImagerApp.Models;
using ImagerApp.Constants;

namespace ImagerApp.Screens
{
    class FeedScreen: ContentPage
    {
        ScrollView feed_scroll = new ScrollView() {Orientation = ScrollOrientation.Vertical };
        StackLayout feed_stack = new StackLayout() {Spacing = 2.5, BackgroundColor = Color.DimGray };
        AppButton refresh_feed_button = new AppButton("Click to refresh") { Margin = new Thickness(2.5) };
        string user_login;
        string user_password;


        public FeedScreen(string login, string password)
        {
            this.user_login = login;
            this.user_password = password;
            this.Title = "Feed";

            GetFeedPostLinks(this, new EventArgs());
            feed_scroll.Content = feed_stack;
            feed_stack.Children.Add(refresh_feed_button);
            refresh_feed_button.Clicked += RefreshFeed;
            this.Content = feed_scroll;
        }

        private async void GetFeedPostLinks(object sender, EventArgs e)
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(Common.GET_JSON_IMAGES_URL1);

            var respose_content = await response.Content.ReadAsStringAsync();
            JObject o = JObject.Parse(respose_content);
            var all_publications = JsonConvert.DeserializeObject<Publication>(o.ToString());
            for (int i = 0; i < all_publications.publications.Count; i++)
            {
                var pub = all_publications.publications[i];
                ImageFrame publication_frame = new ImageFrame($"{pub[1]}", $"{Common.BASE_URL1}{pub[0]}") {Login = this.user_login, Image_id = Convert.ToInt32(pub[2]) };

                feed_stack.Children.Add(publication_frame);
            }

        }

        private void RefreshFeed(object sender, EventArgs e)
        {
            feed_stack.Children.Clear();
            feed_stack.Children.Add(refresh_feed_button);
            GetFeedPostLinks(this, new EventArgs());
        }

    }
}
