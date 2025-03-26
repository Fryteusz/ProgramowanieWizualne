using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form2 : Form
    {
        private Form1 _form1;
        public string imie, nazwisko, stanowisko, wiek;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imie=textBox4.Text;
            nazwisko=textBox3.Text;
            wiek=textBox2.Text;
            stanowisko=comboBox1.Text;
           _form1.dataGridView1.Rows.Add(_form1.i, imie, nazwisko, wiek, stanowisko);
            _form1.i++;
        }

        public Form2(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
