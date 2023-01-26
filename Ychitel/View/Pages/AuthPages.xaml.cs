using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ychitel.Model;

namespace Ychitel.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPages.xaml
    /// </summary>
    public partial class AuthPages : Page
    {
        Core db = new Core();
        public AuthPages()
        {
            InitializeComponent();
        }

        private void SignInButtonClick(object sender, RoutedEventArgs e)
        {
            try

            {

                //считаем количество записей в таблице с заданными параметрами (логин, пароль)
                Users logUsers = db.context.Users.Where(
                x => x.Login == LogInTextBox.Text && x.Password == AuthPasswordBox.Password
                ).FirstOrDefault();

                if (logUsers == null)
                {
                    MessageBox.Show("Такой пользователь отсутствует!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                }
                else

                {

                    switch (logUsers.IdRole)
                    {

                        case 1:
                            this.NavigationService.Navigate(new StudentPage());

                            break;
                        case 2:
                            this.NavigationService.Navigate(new ListTeacherPage());

                            break;

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критический сбор в работе приложения:" + ex.Message.ToString(),
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
            }
        }


        private void RegTextBlockClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegPage());
        }
    }
}
