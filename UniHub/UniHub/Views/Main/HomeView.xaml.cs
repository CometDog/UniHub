using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniHub.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    partial class HomeView : TabbedPage
    {
        internal HomeView()
        {
            InitializeComponent();
        }
    }
}