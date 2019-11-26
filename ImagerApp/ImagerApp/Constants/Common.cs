using System;
using System.Collections.Generic;
using System.Text;

namespace ImagerApp.Constants
{
    class Common
    {
        const string BASE_URL = "http://sigmatestqa.pythonanywhere.com:80";
        const string LOGIN_URL = "http://sigmatestqa.pythonanywhere.com:80/login/";
        const string GET_JSON_IMAGES_URL = "http://sigmatestqa.pythonanywhere.com:80/get_json_images/";
        const string ADD_TO_FAVS_URL = "http://sigmatestqa.pythonanywhere.com:80/add_to_favs/";
        const string GET_MY_FAVS_URL = "http://sigmatestqa.pythonanywhere.com:80/get_my_favs/";

        public static string BASE_URL1 => BASE_URL;

        public static string LOGIN_URL1 => LOGIN_URL;

        public static string GET_JSON_IMAGES_URL1 => GET_JSON_IMAGES_URL;

        public static string ADD_TO_FAVS_URL1 => ADD_TO_FAVS_URL;

        public static string GET_MY_FAVS_URL1 => GET_MY_FAVS_URL;
    }
}
