using System;
using Soul4Christ.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Soul4Christ
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockVerseDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
