using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using System.Drawing;
using System.Drawing.Imaging;
using iTextSharp.text.pdf;
using Image = System.Drawing.Image;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private string doctorsName;
        private string patientsName;
        private string details;
        private string date;
        public Aspose.Pdf.Image ImageFromForm1 { get;  }
        
        public Form3()
        {
            InitializeComponent();
        }
        

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            doctorsName = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            patientsName = textBox2.Text;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            details = textBox3.Text;
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            
           try{
            Document pdfDocument = new Document();

            Page pdfPage = pdfDocument.Pages.Add();

            TextFragment textFragmentDate = new TextFragment("Date: " + date);
            TextFragment textFragmentDoctorsName = new TextFragment("Doctor's Name: " + doctorsName);
            TextFragment textFragmentPatientsName = new TextFragment("Patient's Name: " + patientsName);
            TextFragment textFragmentDetailsLabel = new TextFragment("Details:");
            
            textFragmentDate.Position = new Position(100, 700);
            textFragmentDoctorsName.Position = new Position(100, 650);
            textFragmentPatientsName.Position = new Position(100, 600);
            textFragmentDetailsLabel.Position = new Position(100, 550);

            textFragmentDate.TextState.FontSize = 12;
            textFragmentDate.TextState.Font = FontRepository.FindFont("Arial");
            textFragmentDoctorsName.TextState.FontSize = 12;
            textFragmentDoctorsName.TextState.Font = FontRepository.FindFont("Arial");
            textFragmentPatientsName.TextState.FontSize = 12;
            textFragmentPatientsName.TextState.Font = FontRepository.FindFont("Arial");
            textFragmentDetailsLabel.TextState.FontSize = 12;
            textFragmentDetailsLabel.TextState.Font = FontRepository.FindFont("Arial");

            TextBuilder textBuilder = new TextBuilder(pdfPage);
            textBuilder.AppendText(textFragmentDate);
            textBuilder.AppendText(textFragmentDoctorsName);
            textBuilder.AppendText(textFragmentPatientsName);
            textBuilder.AppendText(textFragmentDetailsLabel);
            string[] detailsLines = details.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            int startY = 525; 
            int lineHeight = 15; 

            for (int i = 0; i < detailsLines.Length; i++)
            {
                TextFragment textFragmentLine = new TextFragment(detailsLines[i]);
                textFragmentLine.Position = new Position(100, startY - i * lineHeight);
                textFragmentLine.TextState.FontSize = 12;
                textFragmentLine.TextState.Font = FontRepository.FindFont("Arial");
                textBuilder.AppendText(textFragmentLine);
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                pdfDocument.Save(filePath);
                Process.Start(filePath);
            }
        }catch (Exception ex) {
            MessageBox.Show($"An error occurred: {ex.Message}");
        }
    }
            
        }
    }
