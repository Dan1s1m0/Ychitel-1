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
    /// Логика взаимодействия для DeletePage.xaml
    /// </summary>
    public partial class DeletePage : Page
    {
        Core db = new Core();
        public DeletePage()
        {
            InitializeComponent();
            ProductDataGrid.ItemsSource = db.context.Students.ToList();
        }

        private void ButtonTextBoxClick(object sender, RoutedEventArgs e)
        {
            try
            {

                var item = ProductDataGrid.SelectedItem as Students;

                //проверка того, что пользователь выбрал строки для удаления

                if (item == null)

                {

                    MessageBox.Show("Вы не выбрали ни одной строки");

                    return;

                }

                else
                {

                    //выполним удаление только в том случае, если пользователь даст согласие на удаление

                    MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {

                        //удаляем выбранную строку

                        db.context.Students.Remove(item);

                        db.context.SaveChanges();

                        MessageBox.Show("Информация удалена");

                        //обновление DataGrid

                        ProductDataGrid.ItemsSource = db.context.Students.ToList();

                    }

                }
            }

            catch (Exception)

            {
                MessageBox.Show("Данные не удалены. ");
            }
        }
    }
}
