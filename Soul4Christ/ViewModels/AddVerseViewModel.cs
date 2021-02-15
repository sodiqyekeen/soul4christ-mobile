using System;
using System.Collections.Generic;
using System.Text;
using Soul4Christ.Models;
using Xamarin.Forms;

namespace Soul4Christ.ViewModels
{
    public class AddVerseViewModel : BaseViewModel
    {
        private string book;
        private string content;
        private string comment;
        private DateTime date = DateTime.Now;

        public AddVerseViewModel()
        {
            Title = "New Verse";
            SaveCommand = new Command(OnSave, ValidateVerse);
            CancelCommand = new Command(OnCancel);
            PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }


        private async void OnCancel() =>
            await Shell.Current.GoToAsync("..");

        private async void OnSave()
        {
            Verse newVerse = new Verse
            {
                Book = Book,
                Comment = Comment,
                Content = Content,
                Date = Date,
                VerseId = Guid.NewGuid().ToString()
            };
            await MockDataStore.AddItemAsync(newVerse);
            await Shell.Current.GoToAsync("..");
        }

        private bool ValidateVerse() =>
            !string.IsNullOrEmpty(book) && !string.IsNullOrEmpty(content);

    }
}
