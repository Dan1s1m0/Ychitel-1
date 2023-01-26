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
    /// Логика взаимодействия для GradePage.xaml
    /// </summary>
    public partial class GradePage : Page
    {
        Core db = new Core();
        List<Students> arrayStudents;
        int idGroup;
        int idStudent;
        int idProfession;
        public GradePage()
        {
            InitializeComponent();
            GroupComboBox.ItemsSource = db.context.Groups.ToList();
            GroupComboBox.DisplayMemberPath = "NameGroup";
            GroupComboBox.SelectedValuePath = "IdGroup";
           
            StudentCombBox.DisplayMemberPath = "FIO";
            StudentCombBox.SelectedValuePath = "IdStudent";

            ParaComboBox.ItemsSource = db.context.Professions.ToList();
            ParaComboBox.DisplayMemberPath = "NameProfession";
            ParaComboBox.SelectedValuePath = "IdProfession";
        }

        private void GroupComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StudentCombBox.IsEnabled = true;
            idGroup = Convert.ToInt32(GroupComboBox.SelectedValue);
            StudentCombBox.ItemsSource = db.context.Students.Where(x => x.IdGroup == idGroup).ToList();
        }
        private void StudentCombBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            idStudent = Convert.ToInt32(StudentCombBox.SelectedValue);
        }
        private void ParaComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            idProfession = Convert.ToInt32(ParaComboBox.SelectedValue);
        }
        private void PostavitOcenkuButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {

                Journals newJournals = new Journals()
                {
                    Evaluation = Convert.ToInt32(OcenkaTextBlock.Text),
                  
                    IdStudent= Convert.ToInt32(idStudent),
                    IdSubject = Convert.ToInt32(idProfession),
                    DateEvalution=DateTime.Now,
                };

                db.context.Journals.Add(newJournals);
                db.context.SaveChanges();


                MessageBox.Show("Добавление выполнено успешно !",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Критический сбой в работе приложения:", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }       
    }
}
