using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Soul4Christ.Models;
using Soul4Christ.Services;
using Xamarin.Forms;

namespace Soul4Christ.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Verse> MockDataStore => DependencyService.Get<IDataStore<Verse>>();

        bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value)) return false;
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null) return;
            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
