using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kalkulator2
{
    public partial class Form1: Form
    {
        int a = 0;
        int b = 0;
        int result=0;
        int it = 0;
        int typ = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            {
                {
                    if (it == 0)
                    {
                        Int32.TryParse(textBox1.Text, out a);
                        it++;
                    }
                    else
                    {
                        Int32.TryParse(textBox1.Text, out b);
                        it++;
                    }
                    button15_Click(sender, e);
                    if (it == 2)
                    {
                        typ = 3;
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            {
                {
                    if (it == 0)
                    {
                        Int32.TryParse(textBox1.Text, out a);
                        it++;
                    }
                    else
                    {
                        Int32.TryParse(textBox1.Text, out b);
                        it++;
                    }
                    button15_Click(sender, e);
                    if (it == 2)
                    {
                        typ = 1;
                    }
                }
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            if (typ == 1)
            {
                result= a + b;
            }
            else if (typ == 2)
            {
                result = a - b;
            }
            else if (typ == 3)
            {
                result = a * b;
            }
            else if (typ == 4)
            {
                result = a / b;
            }
            textBox1.Text = result.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            {
                {
                    if (it == 0)
                    {
                        Int32.TryParse(textBox1.Text, out a);
                        it++;
                    }
                    else
                    {
                        Int32.TryParse(textBox1.Text, out b);
                        it++;
                    }
                    button15_Click(sender, e);
                    if (it == 2)
                    {
                        typ = 2;
                    }
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            {
                {
                    if (it == 0)
                    {
                        Int32.TryParse(textBox1.Text, out a);
                        it++;
                    }
                    else
                    {
                        Int32.TryParse(textBox1.Text, out b);
                        it++;
                    }
                    button15_Click(sender, e);
                    if (it == 2)
                    {
                        result = a * b;
                        it = 0;
                    }
                }
            }
        }
    }
}
