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
            double radians = Math.Abs(kąt * Math.PI / 180.0);
            int szerokosc = (int)(Math.Abs(oryginalnyObraz.Width * Math.Cos(radians)) + Math.Abs(oryginalnyObraz.Height * Math.Sin(radians)));
            int wysokosc = (int)(Math.Abs(oryginalnyObraz.Height * Math.Cos(radians)) + Math.Abs(oryginalnyObraz.Width * Math.Sin(radians)));

            Bitmap obroconyObraz = new Bitmap(szerokosc, wysokosc);

            using (Graphics g = Graphics.FromImage(obroconyObraz))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.TranslateTransform(szerokosc / 2, wysokosc / 2);
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
    }
}
