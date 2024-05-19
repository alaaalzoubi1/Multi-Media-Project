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
    }
}