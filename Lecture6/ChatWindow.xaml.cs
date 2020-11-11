using System;
using System.Windows;

namespace Lecture6
{
    public partial class ChatWindow : Window
    {
        private readonly Guid _sessionId;

        public ChatWindow(Guid sessionId)
        {
            _sessionId = sessionId;
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_sessionId.ToString());
        }
    }
}
