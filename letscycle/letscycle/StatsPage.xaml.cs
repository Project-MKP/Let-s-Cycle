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
        public List<Track> myTracksList { get; set; }
        UserDataEditor ude;

        public StatsPage()
        {
            InitializeComponent();

            ude = new UserDataEditor();
            myTracksList = new List<Track>();
        }

        protected async override void OnAppearing()
        {
            RefreshList();
        }

        private void removeTrackBtn_Clicked(object sender, System.EventArgs e)
        {
            myTracksList = ude.RemoveTrack(myTrackListView.SelectedItem as Track, myTracksList.ToList());
            myTrackListView.ItemsSource = null;
            myTrackListView.ItemsSource = myTracksList;

            todayBikers.Text = CountTodaysBikers();
        }

        private string CountTodaysBikers()
        {
            int bikers = 0;
            foreach(Track track in myTracksList)
            {
                bikers += int.Parse(track.bikersToday);
            }
            return bikers.ToString();
        }

        public void RefreshList()
        {
            myTracksList.Clear();
            myTracksList = ude.ReadUserData(myTracksList);
            myTrackListView.ItemsSource = null;
            myTrackListView.ItemsSource = myTracksList;

            todayBikers.Text = CountTodaysBikers();
        }
    }
}