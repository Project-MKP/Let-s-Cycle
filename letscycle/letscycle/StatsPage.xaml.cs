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
    public partial class StatsPage : ContentPage
    {
        public IList<Track> myTracksList { get; set; }
        public StatsPage()
        {
            InitializeComponent();
            myTracksList = new List<Track>();
            myTracksList.Add(new Track() { imgPath = "woloska.png", street = "Wołoska", bikersToday = "122" });
            BindingContext = this;
        }
    }
}