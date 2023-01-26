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

namespace Ychitel.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListTeacherPage.xaml
    /// </summary>
    public partial class ListTeacherPage : Page
    {
        public ListTeacherPage()
        {
            InitializeComponent();
        }

        private void NewStudentButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NewStudent());
        }

        private void NewGradeButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GradePage());
        }

        private void StudentButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ListStudentPage());
        }

        private void SelectedGradeClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EditPage());
        }

        private void DeleteGradeClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DeletePage());
        }
    }
}
