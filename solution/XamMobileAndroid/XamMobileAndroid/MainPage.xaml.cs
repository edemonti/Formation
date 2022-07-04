using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using XamMobileAndroid.Views;

namespace XamMobileAndroid
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNextPageButtonClicked(object sender, EventArgs e)
        {
            var dateDuJour = DateTime.Now.ToString("F");
            await Navigation.PushAsync(new FirstPage(dateDuJour));
        }
    }
}
