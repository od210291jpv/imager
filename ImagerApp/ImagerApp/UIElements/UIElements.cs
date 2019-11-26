using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ImagerApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using ImagerApp.Constants;


namespace ImagerApp.UI_Elements
{
   class AppButton: Button
    {
        public AppButton(string button_text)
        {
            this.Text = button_text;
            this.BackgroundColor = Color.MediumSpringGreen;
            this.TextColor = Color.White;
            this.CornerRadius = 10;
        }
    }

    class AppEntry : Entry
    {
        public AppEntry(string placeholder = "")
        {
            this.Placeholder = placeholder;
            this.PlaceholderColor = Color.White;
            this.TextColor = Color.White;
        }
    }

    class AppLabel : Label
    {
        public AppLabel()
        {
            this.TextColor = Color.White;
            this.FontAttributes = FontAttributes.Bold;
            this.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            this.Margin = new Thickness(5);
        }
    }

    class ImageFrame : Frame
    {
        public StackLayout frame_stack = new StackLayout() {Orientation = StackOrientation.Vertical };
        public Image content_image;
        AppLabel title_label;
        public AppButton add_to_favs_button = new AppButton("Добавить в избранные" );
        string login;
        int image_id;

        public string Login { get => login; set => login = value; }
        public int Image_id { get => image_id; set => image_id = value; }

        public ImageFrame(string title, string img_src)
        {

            

            this.BackgroundColor = Color.DimGray;
            this.BorderColor = Color.MediumSpringGreen;
            this.CornerRadius = 10;
            this.Padding = 5;
            this.Content = frame_stack;
            add_to_favs_button.Clicked += AddToFavorites;
            frame_stack.Children.Add(title_label = new AppLabel() {Text = title });
            frame_stack.Children.Add(content_image = new Image() { Source = img_src });
            frame_stack.Children.Add(add_to_favs_button);
        }

        private async void AddToFavorites(object sender, EventArgs e)
        {
            if (this.Login != null)
            {
                var add_to_favs_payload = new AddToFavorite { username = Login, image_id = Image_id };
                string json = JsonConvert.SerializeObject(add_to_favs_payload);

                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsync(Common.ADD_TO_FAVS_URL1, content);
                var respose_content = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(respose_content);
                var auth_info = JsonConvert.DeserializeObject<AuthorizationResponce>(o.ToString());
                if (auth_info.State == "ok")
                {
                    this.add_to_favs_button.Text = "В избранном";
                }
                else
                {
                    this.add_to_favs_button.Text = "Error occured";
                }

            }
        }


    }
}
