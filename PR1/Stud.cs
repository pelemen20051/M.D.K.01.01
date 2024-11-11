using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PR1.Form2;

namespace PR1
{
    public partial class Form3 : System.Windows.Forms.Form
    {
        private void Form3_Load(object sender, EventArgs e)
        {
            // Получаем данные из глобального класса
            var studentsList = GlobalData.StudentsList;

            // Проверяем, есть ли данные
            if (studentsList != null)
            {
                // Отображаем данные в DataGridView
                dataGridView1.DataSource = studentsList;
            }
            else
            {
                MessageBox.Show("Нет данных для отображения.");
            }
        }

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Обновляем данные в DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GlobalData.StudentsList;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
    
}
