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
using Ychitel.Controlers;
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
                UsersController obj = new UsersController();
                bool result = obj.Auth(LogInTextBox.Text, AuthPasswordBox.Password);

                if (result == false)
                {
                    MessageBox.Show("Такой пользователь отсутствует!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                }
                else

                {

                    switch (obj.GetActiveUser(LogInTextBox.Text, AuthPasswordBox.Password).IdRole)
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
