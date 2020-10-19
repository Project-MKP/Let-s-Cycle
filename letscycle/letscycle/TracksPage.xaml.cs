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
    public partial class TracksPage : ContentPage
    {
        public IList<Track> tracksList { get; set; }
        public TracksPage()
        {
            InitializeComponent();
            tracksList = new List<Track>();
            tracksList.Add(new Track() { imgPath = "swieto.png", street = "Świętokrzyska", bikersToday = "324" });
            tracksList.Add(new Track() { imgPath = "woloska.png", street = "Wołoska", bikersToday = "122" });
            BindingContext = this;
        }
    }
}