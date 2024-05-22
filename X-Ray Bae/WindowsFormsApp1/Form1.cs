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
using AForge.Imaging;
using AForge.Imaging.Filters;
using Image = System.Drawing.Image;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private bool _isPainting;
        private Color _paintColor = Color.Black;
        private int _paintBrushSize = 5;
        private ColorDialog _colorDialog;
        private bool _isSelect = true;
        private string _brushType = "Triangle";
        private string[] _files;

        public Form1()
        {

            InitializeComponent();
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
            else if (_isPainting)
            {
                PaintOnPictureBox(e.Location);
            }
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
            if (_colorDialog.ShowDialog() == DialogResult.OK)
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

        private void PaintOnPictureBox(Point location)
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }

            if (_isPainting)
            {


                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
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

            pictureBox1.Invalidate();
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

    }
}