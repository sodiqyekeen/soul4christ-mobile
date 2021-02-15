using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Soul4Christ.Models;
using Soul4Christ.Views;
using Xamarin.Forms;

namespace Soul4Christ.ViewModels
{
    public class VersesViewModel : BaseViewModel
    {
        private Verse _selectedVerse;
        public ObservableCollection<Verse> Verses { get; }
        public Command LoadVerseCommand { get; }
        public Command AddVerseCommand { get; }
        public Command<Verse> VerseTappedCommand { get; }
        public VersesViewModel()
        {
            Title = "Verses";
            Verses = new ObservableCollection<Verse>();
            LoadVerseCommand = new Command(async () => await ExecuteLoadVerseCommand());
            AddVerseCommand = new Command(OnAddVerse);
            VerseTappedCommand = new Command<Verse>(OnVerseSelected);
        }

        private async void OnVerseSelected(Verse verse)
        {
            if (verse == null) return;
            await Shell.Current.GoToAsync($"{nameof(VerseDetailPage)}?{nameof(VerseDetailViewModel.VerseId)}={verse.VerseId}");
        }

        private async void OnAddVerse() =>
            await Shell.Current.GoToAsync(nameof(AddVersePage));

        async Task ExecuteLoadVerseCommand()
        {
            IsBusy = true;
            try
            {
                Verses.Clear();
                var verses = await MockDataStore.GetItemsAsync();
                foreach (var verse in verses)
                    Verses.Add(verse);
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Verse SelectedVerse
        {
            get => _selectedVerse;
            set
            {
                SetProperty(ref _selectedVerse, value);
                OnVerseSelected(value);
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedVerse = null;
        }
    }
}
