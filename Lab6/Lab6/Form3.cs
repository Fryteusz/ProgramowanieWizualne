using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab6
{
    public partial class Form3 : Form
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int time { get; private set; }

        public int dydlefy { get; private set; }

        public int krokodyle { get; private set; }
        public int szopy { get; private set; }
        public Form3()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            X = int.Parse(textBox1.Text);
            Y = int.Parse(textBox2.Text);
            dydlefy = int.Parse(textBox4.Text);
            krokodyle = int.Parse(textBox3.Text);
            time = int.Parse(textBox5.Text);
            szopy = int.Parse(textBox6.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}