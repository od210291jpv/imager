using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

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

        public ImageFrame(string title, string img_src)
        {

            

            this.BackgroundColor = Color.DimGray;
            this.BorderColor = Color.MediumSpringGreen;
            this.CornerRadius = 10;
            this.Padding = 5;
            this.Content = frame_stack;
            frame_stack.Children.Add(title_label = new AppLabel() {Text = title });
            frame_stack.Children.Add(content_image = new Image() { Source = img_src });
            frame_stack.Children.Add(add_to_favs_button);
        }

    }
}
