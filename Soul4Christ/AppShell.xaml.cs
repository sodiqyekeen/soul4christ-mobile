using Soul4Christ.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Soul4Christ
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddVersePage), typeof(AddVersePage));
            Routing.RegisterRoute(nameof(VerseDetailPage), typeof(VerseDetailPage));
            //Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
        }
    }
}