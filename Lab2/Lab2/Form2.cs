using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Lab2

{
    public partial class Form2 : Form
    {

        int CPUprice = 0;
        int DiscPrice = 0;
        public int Price { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Price = CPUprice + DiscPrice + 1000;
            this.DialogResult = DialogResult.OK;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    CPUprice = 700;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    CPUprice = 800;
                }
            }
            textBox1.Text = CPUprice.ToString();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            DiscPrice = 100;
            textBox2.Text = DiscPrice.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DiscPrice = 300;
            textBox2.Text = DiscPrice.ToString();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            DiscPrice = 350;
            textBox2.Text = DiscPrice.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Price = 0;
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
