using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace letscycle
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TracksPage : ContentPage
    {
        const string connStr = "server=remotemysql.com;user=rsnE4IGWZE;database=rsnE4IGWZE;password=DwbWHpJ6zr;"; 
        const string query = "SELECT * FROM data";
        public IList<Track> tracksList { get; set; }
        public List<Track> myTracks { get; set; }
        UserDataEditor ude;
        public SqlConnector conn;

        public TracksPage()
        {
            InitializeComponent();

            ude = new UserDataEditor();
            tracksList = new List<Track>();
            myTracks = new List<Track>();

            conn = new SqlConnector();
            tracksList =  conn.Connect(connStr, query);

            myTracks = ude.ReadUserData(myTracks);

            BindingContext = this;
        }

        private void addTrackBtn_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                List<Track> checkList = new List<Track>();
                checkList = ude.ReadUserData(checkList);
                Track track = trackListView.SelectedItem as Track;


                if (!checkListElements(checkList, track))
                {
                    checkList.Add(track);
                    ude.ClearFile();
                    ude.SaveTracksToFile(checkList);
                }
                else
                {
                    DisplayAlert("Błąd!", "Posiadasz już ten licznik na swojej liście!", "OK");
                }
            }
            catch
            {
                DisplayAlert("Błąd!", "Najpierw zaznacz element!", "OK");
            }
        }

        private bool checkListElements(List<Track> list, Track track)
        {
            bool final = false;
            foreach(Track t in list)
            {
                if((track.imgPath == t.imgPath) && (track.street == t.street) && (track.bikersToday == t.bikersToday))
                {
                    final = true;
                    break;
                }
            }
            return final;
        }

        private void addTrackBtn_Pressed(object sender, EventArgs e)
        {
            addTrackBtn.BackgroundColor = Color.FromHex("#DAE6E8");
        }

        private void addTrackBtn_Released(object sender, EventArgs e)
        {
            addTrackBtn.BackgroundColor = Color.Transparent;
        }
    }
}