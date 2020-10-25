using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading;
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
            try
            {
                myTracksList = ude.RemoveTrack(myTrackListView.SelectedItem as Track, myTracksList.ToList());
                myTrackListView.ItemsSource = null;
                myTrackListView.ItemsSource = myTracksList;

                todayBikers.Text = CountTodaysBikers().ToString();
            }
            catch
            {
                DisplayAlert("Błąd!", "Najpierw zaznacz element!", "OK");
            }
        }

        private int CountTodaysBikers()
        {
            int bikers = 0;
            foreach(Track track in myTracksList)
            {
                bikers += int.Parse(track.bikersToday);
            }
            return bikers;
        }

        public void RefreshList()
        {
            myTracksList.Clear();
            myTracksList = ude.ReadUserData(myTracksList);
            myTrackListView.ItemsSource = null;
            myTrackListView.ItemsSource = myTracksList;

            todayBikers.Text = CountTodaysBikers().ToString();
        }

        private void removeTrackBtn_Pressed(object sender, EventArgs e)
        {
            removeTrackBtn.BackgroundColor = Color.FromHex("#DAE6E8");
        }

        private void removeTrackBtn_Released(object sender, EventArgs e)
        {
            removeTrackBtn.BackgroundColor = Color.Transparent;
        }

        void OnTapped(object sender, EventArgs e)
        {
            var frameSender = (Frame)sender;
            frameSender.BackgroundColor = Color.Red;
        }
    }
}