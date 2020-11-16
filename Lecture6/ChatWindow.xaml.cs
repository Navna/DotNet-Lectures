using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;

namespace Lecture6
{
    public partial class ChatWindow : Window
    {
        private readonly Timer _timer;
        private readonly Guid _sessionId;
        private readonly ObservableCollection<MessageItem> _messages = new ObservableCollection<MessageItem> { new MessageItem("Alexander", "Hello") };

        public ChatWindow()
        {
            InitializeComponent();

            MyListBox.ItemsSource = _messages;
            _timer = new Timer(OnTick, null, 2000, 2000);
        }

        public ChatWindow(Guid sessionId) : this()
        {
            _sessionId = sessionId;
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
        }

        private void OnClosed(object sender, EventArgs e)
        {
            _timer.Dispose();
        }

        private void OnTick(object state)
        {
            var message = new MessageItem("Anna", "Hey?");

            Dispatcher.Invoke(() =>
                _messages.Add(message)
            );
        }
    }
}
