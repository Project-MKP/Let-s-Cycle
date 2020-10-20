using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace letscycle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatsPage : ContentPage
    {
        public IList<Track> myTracksList { get; set; }
        UserDataEditor ude;

        public StatsPage()
        {
            InitializeComponent();
            ude = new UserDataEditor();
            myTracksList = new List<Track>();

            myTracksList = ude.ReadUserData(myTracksList.ToList());
            myTrackListView.ItemsSource = null;
            myTrackListView.ItemsSource = myTracksList;
            BindingContext = this;
        }

        private void removeTrackBtn_Clicked(object sender, System.EventArgs e)
        {
            myTracksList = ude.RemoveTrack(myTrackListView.SelectedItem as Track, myTracksList.ToList());
            myTrackListView.ItemsSource = null;
            myTrackListView.ItemsSource = myTracksList;
        }
    }
}