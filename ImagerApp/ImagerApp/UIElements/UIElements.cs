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
        public ImageFrame()
        {
            this.BackgroundColor = Color.DimGray;
            this.BorderColor = Color.MediumSpringGreen;
            this.CornerRadius = 10;
            this.Padding = 5;
            this.Content = frame_stack;
        }

    }
}
