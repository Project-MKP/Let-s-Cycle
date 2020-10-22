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
            BackgroundColor = Color.FromHex("#E9F5F7");
            BarBackgroundColor = Color.FromHex("#F2C299");
        }
    }
}