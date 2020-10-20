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
    public partial class Tabbed : TabbedPage
    {

        public Tabbed()
        {
            InitializeComponent();
            BackgroundColor = Color.FromHex("#F2C299"); //background
            BarTextColor = Color.Black; //nav letters 
            BarBackgroundColor = Color.FromHex("#E4F2E6"); //navbar 
           // ForegroungColor = Color.FromHex();
                                                           //#353440 , #E4F2E6 , #F2C299 , #D99B84 , #A66658

        }
    }
}