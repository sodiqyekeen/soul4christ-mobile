using Soul4Christ.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Soul4Christ.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddVersePage : ContentPage
    {
        public AddVersePage()
        {
            InitializeComponent();
            BindingContext = new AddVerseViewModel();
        }
    }
}