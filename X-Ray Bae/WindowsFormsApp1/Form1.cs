using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.ComplexFilters;
using Microsoft.SqlServer.Server;
using System.Drawing.Imaging;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private bool isPainting = false;
        private Color paintColor = Color.Black; 
        private int paintBrushSize = 5;
        private ColorDialog colorDialog;
        private bool isSelect = true;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void spareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sepia sepia = new Sepia();
            pictureBox2.Image = sepia.Apply((Bitmap)pictureBox1.Image);
        }

        private void eraseEditingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
        }

        private void hueModifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HueModifier hueModifier = new HueModifier(200);
            pictureBox2.Image = hueModifier.Apply((Bitmap)pictureBox1.Image);
        }

        private void rotateChannelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateChannels rotateChannels = new RotateChannels();
            pictureBox2.Image = rotateChannels.Apply((Bitmap)pictureBox1.Image);

        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invert invert = new Invert();
            pictureBox2.Image = invert.Apply((Bitmap)pictureBox1.Image);

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter =
                "Bitmap Image (*.bmp)|*.bmp|JPEG Image (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Image (*.png)|*.png|GIF Image (*.gif)|*.gif";
            saveFileDialog.Title = "Save Image As...";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(saveFileDialog.FileName).ToLowerInvariant();
                ImageFormat format;
                switch (extension)
                {
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                    case ".jpg":
                    case ".jpeg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".png":
                        format = ImageFormat.Png;
                        break;
                    case ".gif":
                        format = ImageFormat.Gif;
                        break;
                    default:
                        throw new NotSupportedException($"Unsupported file extension: {extension}");
                }

                pictureBox2.Image.Save(saveFileDialog.FileName, format);
            }
        }
        private System.Drawing.Point RectStartPoint;
        private Rectangle Rect = new Rectangle();
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(150, 132, 207, 66));
        


        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (isSelect)
            {
                RectStartPoint = e.Location;
                Invalidate();
            }
            else
            {
                // Start painting
                isPainting = true;
                PaintOnPictureBox(e.Location);
            }
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (isSelect)
            {
                if (e.Button == MouseButtons.Left)
                {
                    System.Drawing.Point tempEndPoint = e.Location;
                    Rect.Location = new System.Drawing
                        .Point(
                            Math.Min(RectStartPoint.X, tempEndPoint.X),
                            Math.Min(RectStartPoint.Y, tempEndPoint.Y));
                    Rect.Size = new Size(
                        Math.Abs(RectStartPoint.X - tempEndPoint.X),
                        Math.Abs(RectStartPoint.Y - tempEndPoint.Y));

                    pictureBox1.Invalidate(Rect);
                }
            }else if (isPainting)
            {
                // Paint as the mouse moves
                PaintOnPictureBox(e.Location);
            }
        }

        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            if (isSelect)
            {
                if (pictureBox1.Image != null && Rect != Rectangle.Empty)
                {
                    // Create a pen to draw the rectangle
                    using (Pen selectPen = new Pen(colorDialog.Color, 4)) // Red color, 2 pixels width
                    {
                        e.Graphics.DrawRectangle(selectPen, Rect);
                    }
                }
            }
        }


        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (isSelect)
            {
                Rect = new Rectangle();
                pictureBox1.Invalidate();
            }
        }



        private void brushSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        
      

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog()==DialogResult.OK)
            {
                paintColor = colorDialog.Color;
            }        
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isSelect = true;
        }

        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isSelect = false;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isPainting = false;
        }
        private void PaintOnPictureBox(System.Drawing.Point location)
        {
            if (pictureBox1.Image == null)
            {
                // Initialize the Bitmap if it doesn't exist
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                // Use a brush of the selected color and size to paint
                using (Brush brush = new SolidBrush(paintColor))
                {
                    g.FillEllipse(brush, location.X - paintBrushSize / 2, location.Y - paintBrushSize / 2, paintBrushSize, paintBrushSize);
                }
            }
            pictureBox1.Invalidate();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}