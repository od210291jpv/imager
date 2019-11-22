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
}
