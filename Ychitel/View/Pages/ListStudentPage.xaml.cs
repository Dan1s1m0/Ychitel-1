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
using Word = Microsoft.Office.Interop.Word;

namespace Ychitel.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListStudentPage.xaml
    /// </summary>
    public partial class ListStudentPage : Page
    {
        Core db = new Core();
        
        public ListStudentPage()
        {
            InitializeComponent();
            ProductDataGrid.ItemsSource = db.context.Students.ToList();
        }

        private void ButtonWordTextBoxClick(object sender, RoutedEventArgs e)
        {
            Word.Application application = new Word.Application();
            Word.Document document = application.Documents.Add();
            
            Word.Paragraph titleparagraph = document.Paragraphs.Add();
            Word.Range titleRange = titleparagraph.Range;
            titleRange.Text = " МИНИСТЕРСТВО ОБРАЗОВАНИЯ И МОЛОДЕЖНОЙ ПОЛИТИКИ СВЕРДЛОВСКОЙ ОБЛАСТИ ";
            titleRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            titleRange.InsertParagraphAfter();
            titleparagraph = document.Paragraphs.Add();
            titleRange = titleparagraph.Range;
            titleRange.Text = " ГОСУДАРСТВЕННОЕ АВТОНОМНОЕ ПРОФЕССИОНАЛЬНОЕ ОБРАЗОВАТЕЛЬНОЕ УЧРЕЖДЕНИЕ  СВЕРДЛОВСКОЙ ОБЛАСТИ ";
            titleRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            titleRange.InsertParagraphAfter();
            
            titleparagraph = document.Paragraphs.Add();
            titleRange = titleparagraph.Range;
            titleRange.Text = " «ЕКАТЕРИНБУРГСКИЙ МОНТАЖНЫЙ КОЛЛЕДЖ» ";
            titleRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            titleRange.Bold = 1;
            titleRange.InsertParagraphAfter();
            
            titleparagraph = document.Paragraphs.Add();
            titleRange = titleparagraph.Range;
            titleRange.Text = " ВЕДОМОСТЬ";
            titleRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            titleRange.Bold = 1;
            titleRange.InsertParagraphAfter();
            
            titleparagraph = document.Paragraphs.Add();
            titleRange = titleparagraph.Range;
            titleRange.Text = "итоговой аттестации";
            titleRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            titleRange.Bold = 1;
            titleRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table titleTable = document.Tables.Add(tableRange,1,3);
            Word.Range cellRange;
            cellRange = titleTable.Cell(1, 1).Range;
            cellRange.Text = "«_____» _________ 20_____ Г.";
            cellRange = titleTable.Cell(1, 3).Range;
            cellRange.Text = "№_______________________";
            titleRange.InsertParagraphAfter();


            titleparagraph = document.Paragraphs.Add();
            titleRange = titleparagraph.Range;
            titleRange.Text = "Группа №: ";
            titleRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            titleRange.InsertParagraphAfter();
            
            titleparagraph = document.Paragraphs.Add();
            titleRange = titleparagraph.Range;
            titleRange.Text = "Преподаватель:";
            titleRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            titleRange.InsertParagraphAfter();



            application.Visible = true;
        }
    }
}
