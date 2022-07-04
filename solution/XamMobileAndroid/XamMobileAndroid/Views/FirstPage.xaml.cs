using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamMobileAndroid.Models;

namespace XamMobileAndroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage : ContentPage
    {
        public FirstPage(string dateDuJour)
        {
            InitializeComponent();
            LabelDateDuJour.Text = dateDuJour;
        }

        private async void OnPreviousPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnNextPageButtonClicked(object sender, EventArgs e)
        {

            var contact = new Contact
            {
                Name = "Manu",
                Occupation = "Developer"
            };

            var secondPage = new SecondPage();
            secondPage.BindingContext = contact;

            await Navigation.PushAsync(secondPage);
        }
    }
}