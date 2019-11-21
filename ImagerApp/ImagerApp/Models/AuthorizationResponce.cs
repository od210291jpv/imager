using System;
using System.Collections.Generic;
using System.Text;

namespace ImagerApp.Models
{
    class AuthorizationResponce
    {
        string state;
        string reason;

        public string State { get => state; set => state = value; }
        public string Reason { get => reason; set => reason = value; }
    }
}
