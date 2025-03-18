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
    public partial class Form3 : Form
    {
       public int price = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                int selectedIndex = listView1.SelectedIndices.Cast<int>().First();
                switch (selectedIndex)
                {
                    case 0:
                        price = 500;
                        textBox1.Text = price.ToString();
                        break;
                    case 1:
                        price = 800;
                        textBox1.Text = price.ToString();
                        break;
                    case 2:
                        price = 1000;
                        textBox1.Text = price.ToString();
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
