using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soul4Christ.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Soul4Christ.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VersesPage : ContentPage
    {
        readonly VersesViewModel _viewModel;
        public VersesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new VersesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}