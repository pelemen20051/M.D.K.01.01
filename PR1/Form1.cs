using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR1
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        bool vis = true;
       

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (vis)
            {
                textBox2.UseSystemPasswordChar = false;
                vis = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                vis = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //логин и пароль для учителя
            if (textBox1.Text == "Admin"   & textBox2.Text == "12345")
            {
                System.Windows.Forms.Form Form2 = new Form2();
                Form2.Show();
            }
            //логин и пароль для ученика
            if (textBox1.Text == "Stud" & textBox2.Text == "12345")
            {
                System.Windows.Forms.Form Form3 = new Form3();
                Form3.Show();
            }
            else
            {
                MessageBox.Show("ДОСТУП ЗАПРЕШЕН");
            }
            
           
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
