﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using AForge.Imaging.Filters;
using System.Drawing.Imaging;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private bool _isPainting = false;
        private Color _paintColor = Color.Black; 
        private int _paintBrushSize = 5;
        private ColorDialog _colorDialog;
        private bool _isSelect = true;
        private string _brushType = "Triangle";
       
        public Form1()
        {
       
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _colorDialog = new ColorDialog();
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
                System.Drawing.Image originalImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = ResizeImage(originalImage, pictureBox1.Size);
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
            if (_isSelect)
            {
                RectStartPoint = e.Location;
                Invalidate();
            }
            else
            {
                _isPainting = true;
                PaintOnPictureBox(e.Location);
            }
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (_isSelect)
            {
                if (e.Button == MouseButtons.Left)
                {
                    float scaleX = (float)pictureBox1.Image.Width / pictureBox1.Width;
                    float scaleY = (float)pictureBox1.Image.Height / pictureBox1.Height;
                    int originalX = (int)(e.X * scaleX);
                    int originalY = (int)(e.Y * scaleY);

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
            }else if (_isPainting)
            {
                PaintOnPictureBox(e.Location);
            }
        }

        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            if (_isSelect)
            {
                if (pictureBox1.Image != null && Rect != Rectangle.Empty)
                {
                    using (Pen selectPen = new Pen(_colorDialog.Color, 4))
                    {
                        e.Graphics.DrawRectangle(selectPen, Rect);
            
                    }
                }
            }
        }


        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (_isSelect)
            {
                Rect = new Rectangle();
                pictureBox1.Invalidate();
            }
        }


        
      

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (_colorDialog.ShowDialog()==DialogResult.OK)
            {
                _paintColor = _colorDialog.Color;
            }        
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _isSelect = true;
        }

        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _isSelect = false;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _isPainting = false;
        }
        private void PaintOnPictureBox(System.Drawing.Point location)
{
    if (pictureBox1.Image == null)
    {
        pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
    }

    using (Graphics g = Graphics.FromImage(pictureBox1.Image))
    {
        switch (_brushType)
        {
            case "Round":
                using (Brush brush = new SolidBrush(_paintColor))
                {
                    g.FillEllipse(brush, location.X - _paintBrushSize / 2, location.Y - _paintBrushSize / 2, _paintBrushSize, _paintBrushSize);
                }
                break;
            case "Square":
                using (Brush brush = new SolidBrush(_paintColor))
                {
                    g.FillRectangle(brush, location.X - _paintBrushSize / 2, location.Y - _paintBrushSize / 2, _paintBrushSize, _paintBrushSize);
                }
                break;
            case "Triangle":
                using (Brush brush = new SolidBrush(_paintColor))
                {
                    System.Drawing.Point[] points = {
                        new System.Drawing.Point(location.X, location.Y - _paintBrushSize / 2),
                        new System.Drawing.Point(location.X - _paintBrushSize / 2, location.Y + _paintBrushSize / 2),
                        new System.Drawing.Point(location.X + _paintBrushSize / 2, location.Y + _paintBrushSize / 2)
                    };
                    g.FillPolygon(brush, points);
                }
                break;
            case "Star":
                using (Brush brush = new SolidBrush(_paintColor))
                {
                    PointF[] starPoints = CreateStarPoints(5, new PointF(location.X, location.Y), _paintBrushSize / 2, _paintBrushSize / 4);
                    g.FillPolygon(brush, starPoints);
                }
                break;
        }
    }
    pictureBox1.Invalidate();
}

private PointF[] CreateStarPoints(int numPoints, PointF center, float outerRadius, float innerRadius)
{
    List<PointF> points = new List<PointF>();
    double angle = Math.PI / numPoints;
    for (int i = 0; i < 2 * numPoints; i++)
    {
        double r = (i % 2 == 0) ? outerRadius : innerRadius;
        PointF pt = new PointF(
            center.X + (float)(r * Math.Sin(i * angle)),
            center.Y - (float)(r * Math.Cos(i * angle)));
        points.Add(pt);
    }
    return points.ToArray();
}

        
        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _paintBrushSize = int.Parse(toolStripComboBox2.SelectedItem.ToString());

        }

        private void toolStripComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            _brushType = toolStripComboBox3.SelectedItem.ToString();
        }
        private void ColorizeSelectedArea1(Bitmap originalImage, Rectangle selectionArea, Color color)
        {
            selectionArea.Intersect(new Rectangle(0, 0, originalImage.Width, originalImage.Height));

            BitmapData bitmapData = originalImage.LockBits(
                new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                ImageLockMode.ReadWrite, originalImage.PixelFormat);

            int bytesPerPixel = Bitmap.GetPixelFormatSize(originalImage.PixelFormat) / 8;
            int byteCount = bitmapData.Stride * originalImage.Height;
            byte[] pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bitmapData.Scan0;

            System.Runtime.InteropServices.Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);

            int heightInPixels = bitmapData.Height;
            int widthInBytes = bitmapData.Width * bytesPerPixel;

            for (int y = selectionArea.Top; y < selectionArea.Bottom; y++)
            {
                int currentLine = y * bitmapData.Stride;
                for (int x = selectionArea.Left; x < selectionArea.Right; x++)
                {
                    int xIndex = currentLine + x * bytesPerPixel;

                    byte originalBrightness = pixels[xIndex]; 
                    ApplyHeatMapColorTransformation(originalBrightness, out byte r, out byte g, out byte b);

                    pixels[xIndex] = b;
                    pixels[xIndex + 1] = g;
                    pixels[xIndex + 2] = r;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);

            originalImage.UnlockBits(bitmapData);
        }

        private void ColorizeSelectedArea_Click(object sender, EventArgs e)
        {

            Bitmap xrayImage = (Bitmap)pictureBox1.Image;

            ColorizeSelectedArea1(xrayImage, Rect, _colorDialog.Color);

            pictureBox2.Image = xrayImage;
        }
        public static System.Drawing.Image ResizeImage(System.Drawing.Image image, Size size, bool preserveAspectRatio = true)
        {
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / originalWidth;
                float percentHeight = (float)size.Height / originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }

            System.Drawing.Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }
        private void ApplyHeatMapColorTransformation(byte brightness, out byte r, out byte g, out byte b)
        { 
            if (brightness < 85) 
            {
                r = (byte)(255 - (brightness * 3));
                g = (byte)(brightness * 3);
                b = 0;
            }
            else if (brightness < 170) {
                r = 0;
                g = (byte)(255 - ((brightness - 85) * 3));
                b = (byte)((brightness - 85) * 3);
            }
            else 
            {
                r = 0;
                g = (byte)((brightness - 170) * 3);
                b = 255;
            }
        }


        private void OpenImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Image originalImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = ResizeImage(originalImage, pictureBox1.Size);
            }
            
        }
    }
}