using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

        public static Bitmap Rotate180FlipVertical(Bitmap oryginalnyObraz)
        {
            Bitmap obroconyIOdbityObraz = new Bitmap(oryginalnyObraz.Width, oryginalnyObraz.Height, oryginalnyObraz.PixelFormat);

            using (Graphics g = Graphics.FromImage(obroconyIOdbityObraz))
            {
                g.TranslateTransform(oryginalnyObraz.Width / 2, oryginalnyObraz.Height / 2);
                g.RotateTransform(180);
                g.ScaleTransform(1, -1);

                g.TranslateTransform(-oryginalnyObraz.Width / 2, -oryginalnyObraz.Height / 2);
                g.DrawImage(oryginalnyObraz, new Point(0, 0));
            }

            return obroconyIOdbityObraz;
                }
        private Bitmap ConvertToNegative(Bitmap oryginal)
        {
            Bitmap negatyw = new Bitmap(oryginal.Width, oryginal.Height, PixelFormat.Format32bppArgb);

            for (int x = 0; x < oryginal.Width; x++)
            {
                for (int y = 0; y < oryginal.Height; y++)
                {
                    Color kolor = oryginal.GetPixel(x, y);
                    Color negatywnyKolor = Color.FromArgb(255 - kolor.R, 255 - kolor.G, 255 - kolor.B);
                    negatyw.SetPixel(x, y, negatywnyKolor);
                }
            }
            return negatyw;
        }
        private Bitmap RotateImage(Bitmap oryginalnyObraz, float kąt)
        {
            Bitmap obroconyObraz = new Bitmap(oryginalnyObraz.Width, oryginalnyObraz.Height);

            using (Graphics g = Graphics.FromImage(obroconyObraz))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.TranslateTransform(oryginalnyObraz.Width / 2, oryginalnyObraz.Height / 2);
                g.RotateTransform(kąt);
                g.DrawImage(oryginalnyObraz, -oryginalnyObraz.Width / 2, -oryginalnyObraz.Height / 2);
            }

            return obroconyObraz;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("C:\\Users\\Fryderyk\\Documents\\GitHub\\ProgramowanieWizualne\\Lab4\\image1.jpg");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                    float kąt = 0;
                    if (radioButton1.Checked)
                    {
                        kąt = 90;
                }
                    else if (radioButton2.Checked)
                    {
                        kąt = 180;
                    }
                    else if (radioButton3.Checked)
                    {
                        kąt = 270;
                }
                    Bitmap oryginalnyObraz = new Bitmap(pictureBox1.Image); 
                    Bitmap obroconyObraz = RotateImage(oryginalnyObraz, kąt);
                    pictureBox1.Image = obroconyObraz;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image != null)
            {
                Bitmap oryginalnyObraz = new Bitmap(pictureBox1.Image);
                Bitmap negatyw = ConvertToNegative(oryginalnyObraz);
                pictureBox1.Image = negatyw;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap oryginalnyObraz = new Bitmap(pictureBox1.Image);
            Bitmap obroconyIOdbityObraz = RotateImage(Rotate180FlipVertical(oryginalnyObraz),180);
            pictureBox1.Image = obroconyIOdbityObraz;
            pictureBox1.Refresh();
        }

        private void buttonE_Click(object sender, EventArgs e)
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
