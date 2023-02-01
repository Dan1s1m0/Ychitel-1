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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        Core db = new Core();
        public EditPage()
        {
            InitializeComponent();
            
            ProductDataGrid.ItemsSource = db.context.Journals.ToList();
            var arrayGroups = new List<Groups>
                    {
                    new Groups()
                    {
                    IdGroup = 0,
                    NameGroup = "Все"
                    }
                    };
            arrayGroups.AddRange(db.context.Groups.ToList());

                    
            
            SortTextBox.ItemsSource = arrayGroups;
            SortTextBox.DisplayMemberPath = "NameGroup";
            SortTextBox.SelectedValuePath = "IdGroup";
            SortTextBox.SelectedIndex= 0;
           

        }
        private void SortTextBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

            int arrayGroups = Convert.ToInt32(SortTextBox.SelectedValue);
            if (SortTextBox.SelectedIndex == 0)
            {
                ProductDataGrid.ItemsSource = db.context.Journals.ToList();
            }
            else
            {
                ProductDataGrid.ItemsSource = db.context.Journals.Where(x => x.Students.IdGroup == arrayGroups).ToList();
            }
           
        }

        private void JournalStedentsClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new JournalsStudentsPage());
        }
    }
}
