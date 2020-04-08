using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace TFTHelper2.ViewModels.GlobalResources
{
    public class ViewResource : INotifyPropertyChanged, IDisposable
    {
        private ContentView _contentView;

        private string _title { get; set; }

        private Color _bgColor { get; set; }

        public bool IsVisible { get; set; }

        public ContentView ActionContentView
        {
            get => _contentView;
            set
            {
                IsVisible = value != null;
                _contentView = value;
                OnPropertyChanged("ActionContentView");
                OnPropertyChanged("IsVisible");
            }
        }

        public string ContentViewTitle
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged("ContentViewTitle");
            }
        }

        public Color HeaderBackgroundColor
        {
            get => _bgColor;

            set
            {
                _bgColor = value;
                OnPropertyChanged("HeaderBackgroundColor");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            ActionContentView = null;
        }
    }
    
}
