using System;
using System.Collections.Generic;
using System.Text;

namespace ImagerApp.Models
{

    class PublicationItem
    {
        string[] publication_item = new string[2];

        public string[] Publication_item { get => publication_item; set => publication_item = value; }
    }
    class Publication
    {
        public List<List<string>> publications { get; set; }


    }
}
