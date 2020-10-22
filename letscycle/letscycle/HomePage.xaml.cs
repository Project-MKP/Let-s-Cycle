using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity;
using Org.BouncyCastle.Asn1.BC;

namespace letscycle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        const string sql = "SELECT * FROM veturilo";
        const string sql1 = "SELECT * FROM wheather";
        const string connStr = "server=remotemysql.com;user=rsnE4IGWZE;database=rsnE4IGWZE;password=DwbWHpJ6zr;";
        public SqlConnector sc;

        List<string> veturiloData;
        List<string> weatherData;

        public HomePage()
        {
            InitializeComponent();
            checkConnection();
            veturiloData = new List<string>();
            weatherData = new List<string>();
            sc = new SqlConnector();

            weatherData = sc.GetWeather(connStr, sql1);

            weatherImg.Source = weatherData[3];
            tempLbl.Text = weatherData[0];
            weatherLbl.Text = weatherData[1];
            airConditionLbl.Text = weatherData[2];

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    RefreshPage();
                    Thread.Sleep(15000);
                }
            });

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

        public void RefreshPage()
        {
            veturiloData = sc.GetVeturilo(connStr, sql);

            stationsLbl.Text = veturiloData[0];
            allBikesLbl.Text = veturiloData[1];
            freeBikesLbl.Text = veturiloData[2];
        }
    }
}