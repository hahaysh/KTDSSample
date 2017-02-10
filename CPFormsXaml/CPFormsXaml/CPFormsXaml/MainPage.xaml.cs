using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CPFormsXaml
{
    public partial class MainPage : ContentPage
    {
        private string userName = string.Empty;
        public string Username { get; set; }

        private string password = string.Empty;
        public string Password { get; set; }


        public MainPage()
        {
            InitializeComponent();
        }
    }
}
