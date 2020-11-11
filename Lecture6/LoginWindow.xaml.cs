using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Lecture6
{
    public partial class LoginWindow : Window
    {
        private static readonly Random random = new Random();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            LoginText.IsEnabled = false;
            PasswordText.IsEnabled = false;
            LoginButton.IsEnabled = false;

            var login = LoginText.Text;
            var password = PasswordText.Password;

            var t = new Thread(() =>
            {
                try
                {
                    var sessionId = Login(login, password);
                    Dispatcher.InvokeAsync(() => OnLoginSuccess(sessionId));
                }
                catch (InvalidOperationException e)
                {
                    Dispatcher.InvokeAsync(() => OnLoginFail(e.Message));
                }
            });
            t.Start();
        }

        private static Guid Login(string login, string password)
        {
            Debug.WriteLine(login);
            Debug.WriteLine(password);
            Thread.Sleep(2000);

            var r = random.NextDouble();
            if (r < 0.5)
            {
                // TODO: Моделируем неуспешную попытку входа
                throw new InvalidOperationException("Неправильный логин или пароль!");
            }
            else
            {
                // TODO: Моделируем успешную попытку входа
                return Guid.Empty;
            }
        }

        private void OnLoginSuccess(Guid sessionId)
        {
            Application.Current.MainWindow = new ChatWindow(sessionId) { Owner = this };
            Application.Current.MainWindow.Show();
            Application.Current.MainWindow.Owner = null;
            Close();
        }

        private void OnLoginFail(string message)
        {
            MessageBox.Show(this, message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            LoginText.IsEnabled = true;
            PasswordText.IsEnabled = true;
            LoginButton.IsEnabled = true;
        }
    }
}
