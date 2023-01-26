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
    /// Логика взаимодействия для NewStudent.xaml
    /// </summary>
    public partial class NewStudent : Page
    {
        Core db = new Core();
        List<Students> arrayStudents;
        public NewStudent()
        {
            InitializeComponent();
            SpecComboBox.ItemsSource = db.context.Professions.ToList();
            SpecComboBox.DisplayMemberPath = "NameProfession";
            SpecComboBox.SelectedValuePath = "IdProfession";
            GodComboBox.ItemsSource = db.context.YearAdd.ToList();
            GodComboBox.DisplayMemberPath = "Year";
            GodComboBox.SelectedValuePath = "idYear";
            FormComboBox.ItemsSource = db.context.FormTime.ToList();
            FormComboBox.DisplayMemberPath = "Name";
            FormComboBox.SelectedValuePath = "Id";
            NameComboBox.ItemsSource = db.context.Groups.ToList();
            NameComboBox.DisplayMemberPath = "NameGroup";
            NameComboBox.SelectedValuePath = "IdGroup";
        }


        private void SignButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int idProf = Convert.ToInt32(SpecComboBox.SelectedValue);
                int idYears = Convert.ToInt32(GodComboBox.SelectedValue);
                int idName = Convert.ToInt32(FormComboBox.SelectedValue);
                int idGr = Convert.ToInt32(NameComboBox.SelectedValue);
                Students newStudents = new Students()
                {
                    FiestName = RegFameliaTextBlock.Text,
                    LastName = RegNameTxtBlock.Text,
                    PatronomicName = RegOtchestvoTeBlock.Text,
                    IdProfession= idProf,
                    IdYearAdd = idYears,
                    IdFormTime = idName,
                    IdGroup = idGr,
                };

                db.context.Students.Add(newStudents);
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
