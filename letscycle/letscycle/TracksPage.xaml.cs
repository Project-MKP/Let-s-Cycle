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
            List<Track> checkList = new List<Track>();
            checkList = ude.ReadUserData(checkList);
            Track track = trackListView.SelectedItem as Track;

            if (!checkList.Contains(track))
            {
                checkList.Add(track);
                ude.ClearFile();
                ude.SaveTracksToFile(checkList);
            }
            else
            {
                DisplayAlert("Error!", "You already have this station in your list!", "Ok i will kiss your feet");
            }
        }
    }
}