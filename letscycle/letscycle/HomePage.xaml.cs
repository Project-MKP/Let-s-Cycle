using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity;

namespace letscycle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        List<string> veturiloData;
        List<string> weatherData;

        public HomePage()
        {
            InitializeComponent();
            checkConnection();
            veturiloData = new List<string>();
            weatherData = new List<string>();


            weatherImg.Source = "";
            tempLbl.Text = "";

            Browser.Source = "https://www.veturilo.waw.pl/mapa-stacji-iframe/";
        }

        public async void checkConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("No Internet Connection", "Please, check your internet connection.", "OK");
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            }
        }
    }
}