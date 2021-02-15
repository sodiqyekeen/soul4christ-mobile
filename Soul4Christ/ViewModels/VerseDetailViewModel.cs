using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Soul4Christ.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Soul4Christ.ViewModels
{
    [QueryProperty(nameof(VerseId), nameof(VerseId))]
    public class VerseDetailViewModel : BaseViewModel
    {
        private string verseId;
        private string book;
        private string content;
        private string comment;
        private DateTime date;

        public Command ShareVerseCommand { get; }
        public Command ReadVerseCommand { get; }
        public VerseDetailViewModel()
        {
            ShareVerseCommand = new Command(OnShare);
            ReadVerseCommand = new Command(OnRead);
        }

        private async void OnRead() =>
            await TextToSpeech.SpeakAsync($"{Content} {Book.RemoveTranslation().Replace("-"," to ")}");

        private async void OnShare() =>
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = $"Verse of the Day - {Date:d}\n\n{Content}\n\n - {Book}",
                Subject= $"Verse of the Day - {Date:d}",
                Title ="Share!"
            });

        public string Id { get; set; }
        public string VerseId
        {
            get => verseId;
            set
            {
                verseId = value;
                LoadVerseById(value);
            }
        }
        public string Book
        {
            get => book;
            set => SetProperty(ref book, value);
        }
        public string Content
        {
            get => content;
            set => SetProperty(ref content, value);
        }
        public string Comment
        {
            get => comment;
            set => SetProperty(ref comment, value);
        }
        public DateTime Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        private async void LoadVerseById(string verseId)
        {
            try
            {
                var verse = await MockDataStore.GetItemAsync(verseId);
                Title = verse.Date.ToString("D");
                Id = verse.VerseId;
                Book = verse.Book;
                Content = verse.Content;
                Comment = verse.Comment;
                Date = verse.Date;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                await Shell.Current.DisplayAlert("Error", "Error getting verse.", "OK");
            }
        }
    }
}
