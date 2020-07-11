using System.ComponentModel;
using System.Runtime.CompilerServices;
using Numerology.Annotations;
using Numerology.Models;

namespace Numerology.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            var letterConverter = new LetterConverter();
            _stringAdder = new StringAdder(letterConverter);
        }

        private readonly IStringAdder _stringAdder;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _inputString = "";

        public string InputString
        {
            get => _inputString;
            set
            {
                _inputString = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public string Result => _stringAdder.Add(InputString);
    }
}
