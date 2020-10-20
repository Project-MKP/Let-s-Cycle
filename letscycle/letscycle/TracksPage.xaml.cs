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
        const string connStr = "server=remotemysql.com;user=rsnE4IGWZE;database=rsnE4IGWZE;password=DwbWHpJ6zr;"; 
        //const string connStr = "server=remotemysql.com;user id=rsnE4IGWZE;password=rsnE4IGWZE;initial catalog=DwbWHpJ6zr;";
        const string query = "SELECT * FROM data";
        public IList<Track> tracksList { get; set; }
        public SqlConnector conn;

        public TracksPage()
        {
            
            InitializeComponent();
            tracksList = new List<Track>();
            conn = new SqlConnector();
            tracksList =  conn.Connect(connStr, query);

            BindingContext = this;
        }
    }
}