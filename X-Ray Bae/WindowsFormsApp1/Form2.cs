using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        
        private string _selectedPart = "skull";
        public Form2()
        {
            
            InitializeComponent();
        }
 
        // private void pictureBox1_Click(object sender, EventArgs e)
        // {
        //     Console.WriteLine("epeppepepepepeppe");
        //     if (openFileDialog1.ShowDialog() == DialogResult.OK && !crop)
        //     {
        //         pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        //         Image originalImage = Image.FromFile(openFileDialog1.FileName);
        //         pictureBox1.Image = originalImage;
        //     }
        // }
        

   

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                Image originalImage = Image.FromFile(openFileDialog1.FileName);
                pictureBox2.Image = originalImage;
            }        }

       

        public int CountBrightPixels(Bitmap bitmap, float brightnessThreshold)
        {
            int brightPixelCount = 0;

            // Iterate over each pixel in the bitmap
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    // Get the color of the current pixel
                    Color pixelColor = bitmap.GetPixel(x, y);

                    // Calculate the average brightness of the pixel
                    float brightness = (float)(pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    // Check if the pixel is bright enough
                    if (brightness >= brightnessThreshold)
                    {
                        brightPixelCount++;
                    }
                }
            }

            return brightPixelCount;
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            Bitmap img1 = new Bitmap(pictureBox1.Image);
            Bitmap img2 = new Bitmap(pictureBox2.Image);

            int blackPixelsImg1 = CountBrightPixels(img1,128);
            int blackPixelsImg2 = CountBrightPixels(img2,128);
            int result = Math.Abs(blackPixelsImg1 - blackPixelsImg2);
            Console.WriteLine(blackPixelsImg1);
            Console.WriteLine(blackPixelsImg2);
            if (result  <=  50) // tolerance value
            {
                MessageBox.Show(@"There is no advance in treatment");
            }
            else if (blackPixelsImg1 < blackPixelsImg2)
            {
                MessageBox.Show(@"There is advancement in sickness (more sick)");
            }
            else
            {
                MessageBox.Show(@"There is advancement in treatment");
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            EvaluateBodyPart(_selectedPart);
            
        }

        
     

        public void EvaluateBodyPart(String part)
        {
            switch (part)
            {
                case "skull":
                    EvaluateSkull();
                    break;
                case "lungs":
                    EvaluateLungs((Bitmap)pictureBox1.Image);
                    break;
                case "teeth":
                    EvaluateTeeth();
                    break;
                case "limps":
                    EvaluateLimbs();
                    break;
                default:
                    Console.WriteLine(@"Invalid body part selection.");
                    break;
            }
        }
        
        private void EvaluateSkull()
        {
            Bitmap skull = (Bitmap)pictureBox1.Image;
            int a = CountBrightPixels(skull,128);
            
            Console.WriteLine(a);
        }
        


        public void EvaluateLungs(Bitmap image)
        {
            Rectangle rect1 = new Rectangle(0, 0, image.Width / 2, image.Height);
            Rectangle rect2 = new Rectangle(image.Width / 2, 0, image.Width - image.Width / 2, image.Height);

            Bitmap leftHalf = image.Clone(rect1, image.PixelFormat);
            Bitmap rightHalf = image.Clone(rect2, image.PixelFormat);

            // Function to count dark pixels
             int CountDarkPixels(Bitmap bmp, Color darknessThreshold)
            {
                int darkPixelCount = 0;

                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        Color pixelColor = bmp.GetPixel(x, y);
                        // Check if the pixel is darker than the threshold
                        if (IsDarkerThan(pixelColor, darknessThreshold))
                        {
                            darkPixelCount++;
                        }
                    }
                }

                return darkPixelCount;
            }

            bool IsDarkerThan(Color pixelColor, Color darknessThreshold)
            {
                int pixelBrightness = (pixelColor.R * 299 + pixelColor.G * 587 + pixelColor.B * 114) / 1000;
                int thresholdBrightness = (darknessThreshold.R * 299 + darknessThreshold.G * 587 + darknessThreshold.B * 114) / 1000;

                return pixelBrightness < thresholdBrightness;
            }

            int leftDarkPixelCount = CountDarkPixels(leftHalf,Color.FromArgb(128,128,128));
            int rightDarkPixelCount = CountDarkPixels(rightHalf,Color.FromArgb(128,128,128));
            // Determine the difference
            int difference = Math.Abs(leftDarkPixelCount - rightDarkPixelCount);

            // Determine severity based on the difference
            string severity;
            if (difference > 1300)
            {
                severity = "Severe Sickness";
            }
            else if (difference > 700)
            {
                severity = "Moderate Sickness";
            }
            else if(difference > 500)
            {
                severity = "Mild Sickness";
            }
            else
            {
                severity = "Healthy";
            }

            MessageBox.Show($@"Evaluating lungs... Severity: {severity}");
        }


        private void EvaluateTeeth()
        {
            // Logic for evaluating teeth goes here
            Console.WriteLine(@"Evaluating teeth...");
        }

        private void EvaluateLimbs()
        {
            // Logic for evaluating limbs goes here
            Console.WriteLine(@"Evaluating limbs...");
        }

        

        private void skullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _selectedPart = "skull";
            toolStripComboBox1.Text = _selectedPart;

        }

        private void lungsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _selectedPart = "lungs";
            toolStripComboBox1.Text = _selectedPart;


        }

        private void teethToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _selectedPart = "teeth";
            toolStripComboBox1.Text = _selectedPart;


        }

        private void limpsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _selectedPart = "limps";
            toolStripComboBox1.Text = _selectedPart;


        }

        private Point _startPoint;
        private Rectangle _cropRect;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _startPoint = e.Location;
            pictureBox1.Invalidate();        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button!= MouseButtons.Left) return;

            // Calculate the width and height of the rectangle
            int width = e.X - _startPoint.X;
            int height = e.Y - _startPoint.Y;

            // Update the rectangle to cover the area from the start point to the current mouse position
            _cropRect = new Rectangle(_startPoint, new Size(width, height));

            // Redraw the PictureBox to update the cropping rectangle
            pictureBox1.Invalidate();        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
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
        

        private void button3_Click(object sender, EventArgs e)
        {
            CropImage(_cropRect);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            using (Pen selectPen = new Pen(Color.Aqua, 4))
            {
                e.Graphics.DrawRectangle(selectPen, _cropRect);
            
            }        
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                Image originalImage = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = originalImage;
            }
        }
    }
}