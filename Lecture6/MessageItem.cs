using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lecture6
{
    public class MessageItem : INotifyPropertyChanged
    {
        private string _sender;
        private string _message;

        public string Sender
        {
            get => _sender;
            set => SetProperty(ref _sender, value);
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public MessageItem(string sender, string message)
        {
            _sender = sender;
            _message = message;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (Equals(field, value))
                return;
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
