using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Net.Http;
using System.Net;


namespace ImagerApp.Screens
{
    class DevelopmentMenu: ContentPage
    {
        StackLayout dev_menu_stack_layout = new StackLayout();
        Label ip_addres_label = new Label() {Text = "host ip", Margin = 5 };
        Entry ip_address_entry = new Entry() { Placeholder = "IP" };
        Button check_connection_button = new Button() {Text = "Check connection with host" };
        Label connection_state_label = new Label() { Text = "Connection State: " };

        public DevelopmentMenu()
        {
            this.Title = "Development menu";
            check_connection_button.Clicked += CheckConnectionCallback;

            dev_menu_stack_layout.Children.Add(ip_addres_label);
            dev_menu_stack_layout.Children.Add(ip_address_entry);
            dev_menu_stack_layout.Children.Add(check_connection_button);
            dev_menu_stack_layout.Children.Add(connection_state_label);

            this.Content = dev_menu_stack_layout;
        }

        private async void CheckConnectionCallback(object sender, EventArgs e)
        {
            string host_ip = ip_address_entry.Text;
            string host_url = $"http://{host_ip}:8000/";


            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri(host_url);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                connection_state_label.Text = "Connection State: Connected";
                connection_state_label.TextColor = Color.Green;
            }
            else
            {
                connection_state_label.Text = "Connection State: Offline";
                connection_state_label.TextColor = Color.Red;
            }
        }
    }
}
