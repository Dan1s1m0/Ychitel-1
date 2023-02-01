using System;
using System.Collections.Generic;
using System.IO;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace Ychitel.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListStudentPage.xaml
    /// </summary>
    public partial class ListStudentPage : Page
    {
        Core db = new Core();
        Word.Application application;
        List<Students> arrayStudents;
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

        private void ButtonDiplomClick(object sender, RoutedEventArgs e)
        {
            Button activeButton=sender as Button;

            Students activeStudent = activeButton.DataContext as Students;
            application = new Word.Application();
            String file = $"{Directory.GetCurrentDirectory()}\\Docs\\Диплом.doc";
            if (File.Exists(file))
            {
                Word.Document doc = application.Documents.Open(file);
                doc.Activate();
                doc.Bookmarks["FIO"].Range.Text = activeStudent.FIO;
                application.Visible = true;
                doc.SaveAs($"{Directory.GetCurrentDirectory()}\\Docs\\{activeStudent.LastName}_Диплом.doc");
            }
            application.Visible = true;
        }

        private void ButtonExelTextBoxClick(object sender, RoutedEventArgs e)
        {
            Excel.Application aplication = new Excel.Application();
            aplication.Visible = true;


            /*количество листов*/

            aplication.SheetsInNewWorkbook = 1;

            /*добавляем рабочую книгу*/
            Excel.Workbook workbook = aplication.Workbooks.Add(Type.Missing);

            /*создаем лист*/
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            //worksheet.StandardWidth = 30;
            //worksheet.Columns.ColumnWidth = 30;

            worksheet.Name = "Отчет студентов";

            int rowIndex = 2;

            worksheet.Cells[1][1] = "ФИО";
            worksheet.Cells[2][1] = "Группа";
            worksheet.Cells[3][1] = "Специальность";
            worksheet.Cells[4][1] = "Форма обучения";
            worksheet.Cells[5][1] = "Год поступления";

            int i = Convert.ToInt32(ComboBoxSort.SelectedValue);
            if (i != 0)
            {
                arrayStudents = db.context.Students.Where(x => x.IdGroup == i).ToList();
                foreach (var item in arrayStudents)
                {
                    worksheet.Cells[1][rowIndex] = item.FIO;
                    worksheet.Cells[2][rowIndex] = item.Groups.NameGroup;
                    worksheet.Cells[3][rowIndex] = item.Professions.NameProfession;
                    worksheet.Cells[4][rowIndex] = item.FormTime.Name;
                    worksheet.Cells[5][rowIndex] = item.YearAdd.Year;

                    rowIndex++;

                }
                Excel.Range rangeBorders = worksheet.Range[worksheet.Cells[1][1], worksheet.Cells[5][rowIndex - 1]];
                rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle =
                     rangeBorders.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = rangeBorders.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                worksheet.Columns.AutoFit();
            }
        }
    }
}
