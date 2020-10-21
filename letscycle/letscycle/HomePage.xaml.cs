using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            veturiloData = new List<string>();
            weatherData = new List<string>();


            weatherImg.Source = "";
            tempLbl.Text = "";

        }
    }
}