using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Bitmap TylkoZielony(Bitmap oryginal)
        {
            Bitmap tylkoZielony = new Bitmap(oryginal.Width, oryginal.Height, oryginal.PixelFormat);

            for (int x = 0; x < oryginal.Width; x++)
            {
                for (int y = 0; y < oryginal.Height; y++)
                {
                    Color kolor = oryginal.GetPixel(x, y);
                    int prógZieleni = 100;
                    int prógCzerwieniINiebieskiego = 100;
                    if (kolor.G >= prógZieleni && kolor.R <= prógCzerwieniINiebieskiego && kolor.B <= prógCzerwieniINiebieskiego)
                    {
                        tylkoZielony.SetPixel(x, y, kolor);
                    }
                    else
                    {
                        tylkoZielony.SetPixel(x, y, Color.Black);
                    }
                }
            }
            return tylkoZielony;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("C:\\Users\\Fryderyk\\Documents\\GitHub\\ProgramowanieWizualne\\Lab4\\image1.jpg");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                {
                    Bitmap oryginalnyObraz = new Bitmap(pictureBox1.Image);
                    Bitmap tylkoZielonyObraz = TylkoZielony(oryginalnyObraz);
                    pictureBox1.Image = tylkoZielonyObraz;
                }
            }
            else
            {
                MessageBox.Show("Najpierw wczytaj obrazek.");
            }
        }
    }
}
