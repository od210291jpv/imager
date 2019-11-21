using System;
using System.Collections.Generic;
using System.Text;

namespace ImagerApp.Models
{
    class UserCredentials
    {
        string username;
        string password;

        public string Password { get => password; set => password = value; }
        public string Username { get => username; set => username = value; }

    }
}
