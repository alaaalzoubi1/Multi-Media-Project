using System;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("epeppepepepepeppe");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                Image originalImage = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = originalImage;
            }
        }

   

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                Image originalImage = Image.FromFile(openFileDialog1.FileName);
                pictureBox2.Image = originalImage;
            }        }

        private int CountBlackPixels(Bitmap bmp)
        {
            int count = 0;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color pixelColor = bmp.GetPixel(i, j);
                    if (pixelColor.R == 0 && pixelColor.G == 0 && pixelColor.B == 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Bitmap img1 = new Bitmap(pictureBox1.Image);
            Bitmap img2 = new Bitmap(pictureBox2.Image);

            int blackPixelsImg1 = CountBlackPixels(img1);
            int blackPixelsImg2 = CountBlackPixels(img2);

            if (Math.Abs(blackPixelsImg1 - blackPixelsImg2) <= 50) // tolerance value
            {
                MessageBox.Show("There is no advance in treatment");
            }
            else if (blackPixelsImg1 > blackPixelsImg2)
            {
                MessageBox.Show("There is advancement in sickness (more sick)");
            }
            else
            {
                MessageBox.Show("There is advancement in treatment");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                
        }
    }
}