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

            BindingContext = this;
        }

        private void addTrackBtn_Clicked(object sender, System.EventArgs e)
        {
            myTracks.Add(trackListView.SelectedItem as Track);
            ude.SaveTracksToFile(myTracks);
        }
    }
}