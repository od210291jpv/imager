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
using ImagerApp.UI_Elements;


namespace ImagerApp.Screens
{
    class FeedScreen: ContentPage
    {
        ScrollView feed_scroll = new ScrollView() {Orientation = ScrollOrientation.Vertical };
        StackLayout feed_stack = new StackLayout() {Spacing = 2.5, BackgroundColor = Color.DimGray };
        AppButton refresh_feed_button = new AppButton("Click to refresh") { Margin = new Thickness(2.5) };


        public FeedScreen()
        {
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
            HttpResponseMessage response = await client.GetAsync("http://sigmatestqa.pythonanywhere.com:80/get_json_images/");

            var respose_content = await response.Content.ReadAsStringAsync();
            JObject o = JObject.Parse(respose_content);
            var all_publications = JsonConvert.DeserializeObject<Publication>(o.ToString());
            for (int i = 0; i < all_publications.publications.Count; i++)
            {
                var pub = all_publications.publications[i];
                feed_stack.Children.Add(new Image() {Source = new UriImageSource() {CachingEnabled = false, Uri = new Uri($"http://sigmatestqa.pythonanywhere.com:80{pub[0]}") } });
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
