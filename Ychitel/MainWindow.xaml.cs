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
using Ychitel.View.Pages;
using Word = Microsoft.Office.Interop.Word;

namespace Ychitel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Word.Application application;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AuthPages());
            application = new Word.Application();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            App.Current.Shutdown();
            application.Quit();
        }
    }
}
