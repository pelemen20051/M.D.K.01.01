using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml; // Для работы с Excel
using System.IO; // Для работы с файлами

namespace PR1
{
    public partial class Form2 : System.Windows.Forms.Form
    {
        private List<students> students1 = new List<students>();
        public class students
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Subject { get; set; }
            public int Evaluations { get; set; }
            public DateTime EvaluationDate { get; set; }  // Новое свойство для даты
            
        }
        public static class GlobalData
        {
            // Это свойство будет хранить список студентов
            public static List<Form2.students> StudentsList { get; set; }
        }
        public Form2()
        {
            InitializeComponent();
            dataGridView1.DataSource = students1;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


       

        private void btnAdd_Click(object sender, EventArgs e)
        {

            int id = int.Parse(textID.Text);  // Поле для ввода ID
            string name = textName.Text;  // Поле для ввода ФИО
            string subject = textSubject.Text;    // Поле для ввода Предмета
            int evaluations = int.Parse(textEvaluations.Text);    // Поле для ввода Оценки
            students1.Add(new students
            {
                ID = id,
                Name = name,
                Subject = subject,
                Evaluations = evaluations,
                EvaluationDate = DateTime.Now  // Присваиваем текущую дату
            });
            // Обновляем глобальные данные
            GlobalData.StudentsList = students1;


            dataGridView1.DataSource = null; // Обновляется привязку данных
            dataGridView1.DataSource = students1;


        }

        private void butt_Update_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textID.Text);
            students studToUpdate = students1.Find(c => c.ID == id);

            if (studToUpdate != null)
            {
                studToUpdate.Name = textName.Text;  // Изменяем ФИО
                studToUpdate.Subject = textSubject.Text;  // Изменяем предмет
                studToUpdate.Evaluations = int.Parse(textEvaluations.Text);
                dataGridView1.DataSource = null; // Обновляется привязку данных
                dataGridView1.DataSource = students1;

                // Обновляем глобальные данные
                GlobalData.StudentsList = students1;

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = students1;
            }
            else
            {
                MessageBox.Show("Студент с таким ID не найдена.");
            }

        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Устанавливаем лицензию EPPlus для некоммерческого использования
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (ExcelPackage excel = new ExcelPackage())
                {
                    // Создаём лист в Excel
                    var ws = excel.Workbook.Worksheets.Add("Автомобили");

                    // Добавляем заголовки колонок
                    ws.Cells[1, 1].Value = "ID";
                    ws.Cells[1, 2].Value = "ФИО";
                    ws.Cells[1, 3].Value = "Предмет";
                    ws.Cells[1, 4].Value = "Оценка";
                    ws.Cells[1, 5].Value = "Дата выставления";  // Заголовок для даты



                    // Добавляем данные из списка автомобилей
                    for (int i = 0; i < students1.Count; i++)
                    {
                        ws.Cells[i + 2, 1].Value = students1[i].ID;
                        ws.Cells[i + 2, 2].Value = students1[i].Name;
                        ws.Cells[i + 2, 3].Value = students1[i].Subject;
                        ws.Cells[i + 2, 4].Value = students1[i].Evaluations;
                        ws.Cells[i + 2, 5].Value = students1[i].EvaluationDate.ToString("dd.MM.yyyy HH:mm"); // Форматируем дату

                    }

                    // Сохраняем файл Excel через диалог сохранения
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel файлы (*.xlsx)|*.xlsx";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Сохраняем Excel-файл на диск
                        FileInfo fi = new FileInfo(saveFileDialog.FileName);
                        excel.SaveAs(fi);

                        // Уведомление об успешном сохранении
                        MessageBox.Show("Данные успешно экспортированы в Excel!");
                    }
                }
            }
            catch (Exception ex)
            {
                // Обрабатываем возможные ошибки
                MessageBox.Show("Ошибка при экспорте данных в Excel: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textID.Text);
            students carToDelete = students1.Find(c => c.ID == id);

            if (carToDelete != null)
            {
                students1.Remove(carToDelete);
                dataGridView1.DataSource = null; // Обновляем привязку данных
                dataGridView1.DataSource = students1;
            }
            else
            {
                MessageBox.Show("Студент с таким ID не найдена.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
