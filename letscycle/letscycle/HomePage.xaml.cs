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

            toUserLbl.Text = CreateToUserMessage();

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


        private string CreateToUserMessage()
        {
            int temp = int.Parse(weatherData[0].Remove(weatherData[0].Length -2, 2));

            if ((weatherData[1] != "Deszcz" && weatherData[1] != "Przelotne opady" && weatherData[1] != "Częściowo słonecznie z przelotnymi opadami") && temp > 15)
            {
                toUserLbl.TextColor = Color.FromHex("#05E610");
                return "Perfect weather for bike!";
            }
            else if((weatherData[1] != "Deszcz" && weatherData[1] != "Przelotne opady" && weatherData[1] != "Częściowo słonecznie z przelotnymi opadami") && temp > 5)
            {
                toUserLbl.TextColor = Color.FromHex("#25B9EB");
                return "Good weather for bike. Remember to wear something warm!";
            }
            else if ((weatherData[1] != "Deszcz" && weatherData[1] != "Przelotne opady" && weatherData[1] != "Częściowo słonecznie z przelotnymi opadami") && temp < 5)
            {
                toUserLbl.TextColor = Color.FromHex("#42A3EB");
                return "Good weather for bike. Remember to wear warm jacket!";
            }
            else
            {
                toUserLbl.TextColor = Color.FromHex("#F03925");
                return "Crazy weather";
            }
        }
    }
}