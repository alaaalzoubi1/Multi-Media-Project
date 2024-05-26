using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using AForge.Imaging;
using AForge.Imaging.Filters;
using Bitmap = System.Drawing.Bitmap;
using Image = System.Drawing.Image;
using NAudio.Wave;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private WaveInEvent waveIn;
        private WaveFileWriter waveWriter;
        private bool isRecording = false;
        private bool _isPainting;
        private Color _paintColor = Color.Black;
        private  int _paintBrushSize = 1;
        private ColorDialog _colorDialog;
        private bool _isSelect = true;
        private string _brushType = "Triangle";
        private string[] _files;

        private Bitmap bm ;
        private Bitmap originalimage;
        private Bitmap copyimage;
        private Graphics g ;
        private Point px, py;
        private Pen p = new Pen(Color.Black,1  );
        private Pen eraser = new Pen(Color.Transparent, 10);
        private int index;
        private int x, y, sX, sY, cX, cY;
        private Point textLocation;
        
        public Form1()
        {

            InitializeComponent();
            InitializeVoiceRecorder();
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.AllowDrop = true;
            _colorDialog = new ColorDialog();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                Image originalImage = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = resizeImage(originalImage, pictureBox1.Size);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void spareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
            Sepia sepia = new Sepia();
            Bitmap image1 = sepia.Apply((Bitmap)pictureBox1.Image);
            colorizeSelectedArea1(image1, _rect);
            pictureBox2.Image = image1;
        }

        private void eraseEditingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_files != null && _files.Length > 0)
            {
                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                string filePath = _files[0];
                Image image = Image.FromFile(filePath);
                pictureBox2.Image = resizeImage(image, pictureBox2.Size);
            }
            else
            {
                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
                

            }
        }

        private void hueModifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
            HueModifier hueModifier = new HueModifier(200);
            Bitmap image1 = hueModifier.Apply((Bitmap)pictureBox1.Image);
            colorizeSelectedArea1(image1, _rect);
            pictureBox2.Image = image1;
        }

        private void rotateChannelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
            RotateChannels rotateChannels = new RotateChannels();
            Bitmap image1 = rotateChannels.Apply((Bitmap)pictureBox1.Image);
            colorizeSelectedArea1(image1, _rect);
            pictureBox2.Image = image1;
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
            Invert invert = new Invert();
            Bitmap image1 = invert.Apply((Bitmap)pictureBox1.Image);
            colorizeSelectedArea1(image1, _rect);
            pictureBox2.Image = image1;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter =
                @"Bitmap Image (*.bmp)|*.bmp|JPEG Image (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Image (*.png)|*.png|GIF Image (*.gif)|*.gif";
            saveFileDialog.Title = @"Save Image As...";

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

                if (saveFileDialog.FileName != null) pictureBox2.Image.Save(saveFileDialog.FileName, format);
            }
        }

        private Point _rectStartPoint;
        private Rectangle _rect;



        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (_isSelect)
            {
                _rectStartPoint = e.Location;
                Invalidate();
            }
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (_isSelect)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point tempEndPoint = e.Location;
                    _rect.Location = new Point(
                        Math.Min(_rectStartPoint.X, tempEndPoint.X),
                        Math.Min(_rectStartPoint.Y, tempEndPoint.Y));
                    _rect.Size = new Size(
                        Math.Abs(_rectStartPoint.X - tempEndPoint.X),
                        Math.Abs(_rectStartPoint.Y - tempEndPoint.Y));

                    pictureBox1.Invalidate(_rect);
                }
            }
            pictureBox1.Invalidate();
            
        }

      





        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            if (_isSelect)
            {
                if (pictureBox1.Image != null && _rect != Rectangle.Empty)
                {
                    using (Pen selectPen = new Pen(_colorDialog.Color, 4))
                    {
                        e.Graphics.DrawRectangle(selectPen, _rect);

                    }
                }
            }
        }






        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _isSelect = true;
        }

        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _isSelect = false;
            index = 1;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void PaintOnPictureBox(Point location)
        {
            if (pictureBox2.Image == null)
            {
                pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            }

            if (_isPainting)
            {


                using (Graphics g = Graphics.FromImage(pictureBox2.Image))
                {
                    switch (_brushType)
                    {
                        case "Round":
                            using (Brush brush = new SolidBrush(_paintColor))
                            {
                                g.FillEllipse(brush, location.X - _paintBrushSize / 2, location.Y - _paintBrushSize / 2,
                                    _paintBrushSize, _paintBrushSize);
                            }

                            break;
                        case "Square":
                            using (Brush brush = new SolidBrush(_paintColor))
                            {
                                g.FillRectangle(brush, location.X - _paintBrushSize / 2,
                                    location.Y - _paintBrushSize / 2,
                                    _paintBrushSize, _paintBrushSize);
                            }

                            break;
                        case "Triangle":
                            using (Brush brush = new SolidBrush(_paintColor))
                            {
                                Point[] points =
                                {
                                    new Point(location.X, location.Y - _paintBrushSize / 2),
                                    new Point(location.X - _paintBrushSize / 2,
                                        location.Y + _paintBrushSize / 2),
                                    new Point(location.X + _paintBrushSize / 2,
                                        location.Y + _paintBrushSize / 2)
                                };
                                g.FillPolygon(brush, points);
                            }

                            break;
                        case "Star":
                            using (Brush brush = new SolidBrush(_paintColor))
                            {
                                PointF[] starPoints = createStarPoints(5, new PointF(location.X, location.Y),
                                    _paintBrushSize * 2, _paintBrushSize);
                                g.FillPolygon(brush, starPoints);
                            }

                            break;
                    }
                }
            }

            pictureBox2.Invalidate();
        }

        private PointF[] createStarPoints(int numPoints, PointF center, float outerRadius, float innerRadius)
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

        private void colorizeSelectedArea1(Bitmap originalImage, Rectangle selectionArea)
        {
            selectionArea.Intersect(new Rectangle(0, 0, originalImage.Width, originalImage.Height));

            BitmapData bitmapData = originalImage.LockBits(
                new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                ImageLockMode.ReadWrite, originalImage.PixelFormat);

            int bytesPerPixel = Image.GetPixelFormatSize(originalImage.PixelFormat) / 8;
            int byteCount = bitmapData.Stride * originalImage.Height;
            byte[] pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bitmapData.Scan0;

            Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);

            for (int y = selectionArea.Top; y < selectionArea.Bottom; y++)
            {
                int currentLine = y * bitmapData.Stride;
                for (int x = selectionArea.Left; x < selectionArea.Right; x++)
                {
                    int xIndex = currentLine + x * bytesPerPixel;

                    byte originalBrightness = pixels[xIndex];
                    applyHeatMapColorTransformation(originalBrightness, out byte r, out byte g, out byte b);

                    pixels[xIndex] = b;
                    pixels[xIndex + 1] = g;
                    pixels[xIndex + 2] = r;
                }
            }

            Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);

            originalImage.UnlockBits(bitmapData);
        }

        private void ColorizeSelectedArea_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.Normal;

            Bitmap xrayImage = (Bitmap)pictureBox1.Image;

            colorizeSelectedArea1(xrayImage, _rect);

            pictureBox2.Image = xrayImage;
        }

        private static Image resizeImage(Image image, Size size,
            bool preserveAspectRatio = true)
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

            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        private void applyHeatMapColorTransformation(byte brightness, out byte r, out byte g, out byte b)
        {
            if (brightness < 85)
            {
                r = (byte)(255 - (brightness * 3));
                g = (byte)(brightness * 3);
                b = 0;
            }
            else if (brightness < 170)
            {
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
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                Image originalImage = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = resizeImage(originalImage, pictureBox1.Size);
            }

        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            _files = (string[])e.Data.GetData((DataFormats.FileDrop));
            if (_files != null && _files.Length > 0)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                string filePath = _files[0];
                Image image = Image.FromFile(filePath);
                pictureBox1.Image = resizeImage(image, pictureBox1.Size);
            }
        }

        private void pictureBox1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void heatMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Bitmap image1 = ApplyHeatMapColorTransformation()
            // ColorizeSelectedArea1(image1,Rect,_colorDialog.Color);
            // pictureBox2.Image = image1;
        }

        private bool isImage(FileInfo file)
        {
            string[] extensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".ico" };
            return extensions.Contains(file.Extension.ToLower());
        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderDialog.SelectedPath;



                    DateTime date = dateTimePicker1.Value.Date;


                    var files = new DirectoryInfo(folderPath).GetFiles("*.*", SearchOption.AllDirectories)
                        .Where(file => isImage(file) && file.LastWriteTime.Date == date)
                        .ToArray();


                    StringBuilder sb = new StringBuilder();
                    foreach (FileInfo file in files)
                    {
                        sb.AppendLine(
                            $"File: {file.FullName}, Last Modified: {file.LastWriteTime.ToShortDateString()}");
                    }

                    if (files.Length == 0)
                    {
                        MessageBox.Show("No matches found.", "Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(sb.ToString(), "Filtered Files", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        string folderPath = folderDialog.SelectedPath;
                        double sizeB = double.Parse(toolStripTextBox1.Text);

                        var files = new DirectoryInfo(folderPath).GetFiles("*.*", SearchOption.AllDirectories)
                            .Where(file => isImage(file) && file.Length == sizeB)
                            .ToArray();
                        StringBuilder sb = new StringBuilder();
                        foreach (FileInfo file in files)
                        {
                            sb.AppendLine($"File: {file.FullName}, Size: {file.Length / 1024} KB");
                        }

                        if (files.Length == 0)
                        {
                            MessageBox.Show("No matches found.", "Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(sb.ToString(), "Filtered Files", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }

                e.SuppressKeyPress = true;
            }
        }

        private void compareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }




        public void applyLowPassFilter(Bitmap inputImage)
        {
            // Convert the input image to grayscale
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayscaleImage = filter.Apply(inputImage);

            // Resize the image to dimensions that are powers of 2
            int width = nextPowerOfTwo(grayscaleImage.Width);
            int height = nextPowerOfTwo(grayscaleImage.Height);
            ResizeBilinear resizeFilter = new ResizeBilinear(width, height);
            Bitmap resizedImage = resizeFilter.Apply(grayscaleImage);

            // Apply FFT to the resized grayscale image
            ComplexImage complexImage = ComplexImage.FromBitmap(resizedImage);
            complexImage.ForwardFourierTransform();

            // Create a low-pass filter mask
            int radius = 10; // Set the radius for your low-pass filter
            int cx = width / 2;
            int cy = height / 2;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if ((x - cx) * (x - cx) + (y - cy) * (y - cy) > radius * radius)
                    {
                        complexImage.Data[y, x].Re = 0;
                        complexImage.Data[y, x].Im = 0;
                    }
                }
            }
            
            // Apply the inverse FFT to convert back to the spatial domain
            complexImage.BackwardFourierTransform();

            // Get the filtered image
            Bitmap lowPassImage = complexImage.ToBitmap();

            // Resize the image back to the original dimensions
            ResizeBilinear resizeFilterOriginal = new ResizeBilinear(inputImage.Width, inputImage.Height);
            Bitmap finalImage = resizeFilterOriginal.Apply(lowPassImage);

            // Display the low-pass filtered image in a picture box
            pictureBox2.Image = finalImage;
        }



        public void applyHighPassFilter(Bitmap inputImage)
        {
            // Convert the input image to grayscale
            Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayscaleImage = grayscaleFilter.Apply(inputImage);

            // Resize the image to dimensions that are powers of 2
            int width = nextPowerOfTwo(grayscaleImage.Width);
            int height = nextPowerOfTwo(grayscaleImage.Height);
            ResizeBilinear resizeFilter = new ResizeBilinear(width, height);
            Bitmap resizedImage = resizeFilter.Apply(grayscaleImage);

            // Apply FFT to the resized grayscale image
            ComplexImage complexImage = ComplexImage.FromBitmap(resizedImage);
            complexImage.ForwardFourierTransform();

            // Create a high-pass filter mask
            // Assuming the center of the image is the origin for the frequency domain
            int radius = 10; // Set the radius for your high-pass filter
            int cx = width / 2;
            int cy = height / 2;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if ((x - cx) * (x - cx) + (y - cy) * (y - cy) <= radius * radius)
                    {
                        complexImage.Data[y , x].Re = 0;
                        complexImage.Data[y , x].Im = 0;
                    }
                }
            }

            // Apply the inverse FFT to convert back to the spatial domain
            complexImage.BackwardFourierTransform();

            // Get the filtered image
            Bitmap highPassImage = complexImage.ToBitmap();

            // Resize the image back to the original dimensions
            ResizeBilinear resizeFilterOriginal = new ResizeBilinear(inputImage.Width, inputImage.Height);
            Bitmap finalImage = resizeFilterOriginal.Apply(highPassImage);

            // Display the high-pass filtered image in a picture box
            pictureBox2.Image = finalImage;
        }





        private void lBFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyLowPassFilter((Bitmap)pictureBox1.Image);
        }

        private void hBFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyHighPassFilter((Bitmap)pictureBox1.Image);
        }

        private Bitmap resizeImageToPowerOfTwo(Bitmap inputImage)
        {
            int nextWidth = nextPowerOfTwo(inputImage.Width);
            int nextHeight = nextPowerOfTwo(inputImage.Height);

            ResizeBilinear resizer = new ResizeBilinear(nextWidth, nextHeight);
            return resizer.Apply(inputImage);
        }

// Helper function to find the next power of 2
        private int nextPowerOfTwo(int n)
        {
            int p = 1;
            while (p < n) p <<= 1;
            return p;
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            if (_colorDialog.ShowDialog() == DialogResult.OK)
            {
                _paintColor = _colorDialog.Color;
                color_pic.BackColor = _colorDialog.Color;
                p.Color = _paintColor;
            }
        }

        private void btn_fill_Click(object sender, EventArgs e)
        {
            index = 7;
            
        }

       

        private void btn_eraser_Click(object sender, EventArgs e)
        {
            g = Graphics.FromImage(pictureBox2.Image);
            index = 3;
            _isSelect = false;
            if (pictureBox2.Image != null)
            {
                originalimage = (Bitmap)pictureBox2.Image;
                copyimage = (Bitmap)pictureBox1.Image;
            }
        }

        private void btn_pencil_Click(object sender, EventArgs e)
        {
            g = Graphics.FromImage(pictureBox2.Image);
            index = 2;
            _isSelect = false;
        }

        private void btn_rect_Click(object sender, EventArgs e)
        {
            g = Graphics.FromImage(pictureBox2.Image);
            index = 5;
            _isSelect = false;
            
        }

        private void btn_line_Click(object sender, EventArgs e)
        { 
            g = Graphics.FromImage(pictureBox2.Image);

            index = 6;
            _isSelect = false;
            Console.WriteLine(bm);
        }
        private void btn_tri_Click(object sender, EventArgs e)
        {
            g = Graphics.FromImage(pictureBox2.Image);
            index = 8;
            _isSelect = false;        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            p.Width = _paintBrushSize;
            eraser.Width = _paintBrushSize;
            _isPainting = true;
            if (index == 1)
            {
                PaintOnPictureBox(e.Location);
            }
            else if (index == 2)
            {
                py = e.Location;
            }
            else if (index == 3)
            {
                py = e.Location;
            }
          
            
                cX = e.X;
                cY = e.Y;
            
            pictureBox2.Invalidate();
        }


        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isPainting)
            {
                if (index == 1)
                {
                    PaintOnPictureBox(e.Location);
                }
                else if (index == 2)
                {
              
                    
                        px = e.Location;
                        g.DrawLine(p, px, py);
                        py = px;
                        
                        
                }
                else if (index == 3)
                {
                    px = e.Location;
                    // g.DrawLine(eraser,px,py);
                    // originalimage = (Bitmap)pictureBox2.Image;
                    // copyimage = (Bitmap)pictureBox1.Image;
                    // originalimage.SetPixel(px.X,px.Y,copyimage.GetPixel(px.X,px.Y));
                    // py = px;
                    // pictureBox2.Image = originalimage; 
                    g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                    g.DrawLine(eraser, px, py);
                    py = px;




                }
               

                x = e.X;
                y = e.Y;
                sX = e.X - cX;
                sY = e.Y - cY;
            }
            pictureBox2.Invalidate();
        }


        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            _isPainting = false;
            sX = x - cX;
            sY = y - cY;
            if (index == 4)     
            {
                g.DrawEllipse(p,cX,cY,sX,sY);
            }

            if (index == 5)
            { 
                g.DrawRectangle(p,cX,cY,sX,sY);
            }

            if (index == 6 )
            {
                g.DrawLine(p,cX,cY,x,y);
            }

            if (index == 8)
            {
                // Define the three points of the triangle
                Point point1 = new Point(cX, cY); // This will be the first vertex
                Point point2 = new Point(cX + sX, cY); // Second vertex
                Point point3 = new Point(cX, cY + sY); // Third vertex

                // Create an array of points
                Point[] trianglePoints = { point1, point2, point3 };

                // Draw the triangle
                g.DrawPolygon(p, trianglePoints);
            }

            if (index == 9)
            {
                // Define points that the curve will pass through
                Point[] curvePoints = {
                    new Point(cX, cY),
                    new Point(cX + sX / 2, cY - sY), // Control point for the curve
                    new Point(cX + sX, cY)
                };

                // Draw the curve
                g.DrawCurve(p, curvePoints);
            }
            if (index == 10)
            {
       
                textLocation = new Point(e.X, e.Y);
                textBox1.Visible = true;
                textBox1.Focus();
            }


            

           
            pictureBox2.Invalidate();
        }

        private void btn_ellipse_Click_1(object sender, EventArgs e)
        {
            g = Graphics.FromImage(pictureBox2.Image);
            index = 4;
            _isSelect = false;
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (_isPainting)
            {


                Graphics g = e.Graphics;
                if (index == 4)
                {
                    g.DrawEllipse(p, cX, cY, sX, sY);
                }

                if (index == 5)
                {
                    g.DrawRectangle(p, cX, cY, sX, sY);
                }

                if (index == 6)
                {
                    g.DrawLine(p, cX, cY, x, y);
                }
                if (index == 8)
                {
                    // Define the three points of the triangle
                    Point point1 = new Point(cX, cY); // This will be the first vertex
                    Point point2 = new Point(cX + sX, cY); // Second vertex
                    Point point3 = new Point(cX, cY + sY); // Third vertex
                    
                    // Create an array of points
                    Point[] trianglePoints = { point1, point2, point3 };
                    
                    // Draw the triangle
                    g.DrawPolygon(p, trianglePoints);

                }

                if (index == 9)
                {
                    // Define points that the curve will pass through
                    Point[] curvePoints = {
                        new Point(cX, cY),
                        new Point(cX + sX / 2, cY - sY), // Control point for the curve
                        new Point(cX + sX, cY)
                    };

                    // Draw the curve
                    g.DrawCurve(p, curvePoints);
                }

            }
        }

        private void validate(Bitmap bm, Stack<Point> sp, int x, int y, Color oldColor, Color newColor)
        {
            Color cx = bm.GetPixel(x, y);
            if (cx == oldColor)
            {
                sp.Push(new Point(x,y));
                bm.SetPixel(x,y,newColor);
            }
        }
        public void fill(Bitmap bm, int x, int y, Color color)
        {
            Color old_color = bm.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x,y));
            bm.SetPixel(x,y,color);
            if (old_color == color) 
            {
              
                return;
            }

            while (pixel.Count > 0)
            {
                Console.WriteLine(pixel.Count);
                Point pt = (Point)pixel.Pop();
                if (pt.X > 0 && pt.Y > 0 && pt.X < bm.Width - 1 && pt.Y < bm.Height - 1)
                {
                    validate(bm,pixel,pt.X-1,pt.Y,old_color,color);
                    validate(bm,pixel,pt.X,pt.Y,old_color,color);
                    validate(bm,pixel,pt.X+1,pt.Y,old_color,color);
                    validate(bm,pixel,pt.X,pt.Y+1,old_color,color);


                }
            }
        }

        static Point set_point(PictureBox pb, Point pt)
        {
            float pX = 1f * pb.Image.Width / pb.Width;
            float pY = 1f * pb.Image.Height / pb.Height;
            return new Point((int)(pt.X * pX), (int)(pt.Y* pY));
        }

       

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (index == 7)
            {
                bm =(Bitmap) pictureBox2.Image;
                Point point = set_point(pictureBox2, e.Location);
                fill(bm,point.X,point.Y,_paintColor);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g = Graphics.FromImage(pictureBox2.Image);
            index = 9;
            _isSelect = false;
        }

        private void text_btn_Click(object sender, EventArgs e)
        {
            g = Graphics.FromImage(pictureBox2.Image);
            index = 10;
            _isSelect = false;        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 15)
            {
                Console.WriteLine(textLocation);
                textBox1.Visible = false;

                // Draw the text at the recorded location
                using (Graphics g = Graphics.FromImage(pictureBox2.Image))
                {
                    using (Font font = new Font("Arial", 16))
                    {
                        using (Brush brush = new SolidBrush(Color.Black))
                        {
                            g.DrawString(textBox1.Text, font, brush, textLocation);
                        }
                    }
                }

                // Refresh the PictureBox to show the updated image
                pictureBox2.Refresh();

                // Clear the TextBox for the next input
                textBox1.Text = string.Empty;
            }
        }


       

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Console.WriteLine(textLocation);
                textBox1.Visible = false;

                // Draw the text at the recorded location
                using (Graphics g = Graphics.FromImage(pictureBox2.Image))
                {
                    using (Font font = new Font("Arial", _paintBrushSize))
                    {
                        using (Brush brush = new SolidBrush(_paintColor))
                        {
                            g.DrawString(textBox1.Text, font, brush, textLocation);
                        }
                    }
                }

                // Refresh the PictureBox to show the updated image
                pictureBox2.Refresh();

                // Clear the TextBox for the next input
                textBox1.Text = string.Empty;
            }
        }

        private void record_btn_Click(object sender, EventArgs e)
        {
            if (!isRecording)
            {
                // Check if the user has selected a file path with the.wav extension
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    // Ensure the file path ends with ".wav"
                    if (!filePath.EndsWith(".wav"))
                    {
                        filePath += ".wav";
                    }

                    // Configure the WaveFileWriter with the chosen file path and the current WaveFormat
                    waveWriter = new WaveFileWriter(filePath, waveIn.WaveFormat);
                    waveIn.DataAvailable += (sender2, e2) =>
                    {
                        waveWriter.Write(e2.Buffer, 0, e2.BytesRecorded);
                        waveWriter.Flush();
                    };

                    // Start recording audio
                    waveIn.StartRecording();
                    isRecording = true;
                    // record_btn.Text = "Stop Recording";
                }
            }
            else
            {
                // Stop recording audio
                waveIn.StopRecording();
                waveIn.Dispose();
                waveWriter.Dispose();
                isRecording = false;
                // record_btn.Text = "Start Recording";
            }
            
        }
        private void InitializeVoiceRecorder()
        {
            waveIn = new WaveInEvent();
            waveIn.WaveFormat = new WaveFormat(44100, 1); // Sample rate and channels
        }

        private void share_btn_Click(object sender, EventArgs e)
        {
            // Save the image to a temporary file
            string tempFilePath = Path.GetTempFileName();
            pictureBox2.Image.Save(tempFilePath, ImageFormat.Jpeg); // Use the appropriate format

            // Create the Telegram URI
            string message = "Check this out!"; // Your message here
            string phoneNumber = "+963 962 190 786"; // Recipient's phone number here
            string telegramUri = $"tg://msg?text={phoneNumber}";

            // Start the process to open the Telegram app
            Process.Start(telegramUri);
        }
        private byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CropImage(_rect);
        }
        private void CropImage(Rectangle cropRect)
        {
            // Create a new Bitmap for the cropped image
            Bitmap croppedImage = new Bitmap(cropRect.Width, cropRect.Height);

            // Draw the cropped area onto the new Bitmap
            using (Graphics g = Graphics.FromImage(croppedImage))
            {
                g.DrawImage(pictureBox1.Image, new Rectangle(0, 0, croppedImage.Width, croppedImage.Height), cropRect, GraphicsUnit.Pixel);
            }

            // Display the cropped image in another PictureBox
            pictureBox2.Image = croppedImage;
        }
    }
}