using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Aspose.Pdf.Text;
using iTextSharp.text.pdf;

using iTextSharp.text;


namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public string _doctorsName;
        private string _patientsName;
        private string _details;
        private string _date;
        private Form1 form1;
        
        public Form3(Form1 form1Instance)
        {
            InitializeComponent();
            this.form1 = form1Instance;
        }


        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _doctorsName = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            _patientsName = textBox2.Text;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            _details = textBox3.Text;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            create_report();
        }

        public void create_report()
        {
            _date = DateTime.Now.ToString("yyyy/MM/dd"); 

            try{
                Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document();

                Aspose.Pdf.Page pdfPage = pdfDocument.Pages.Add();

                TextFragment textFragmentDate = new TextFragment("Date: " + _date);
                TextFragment textFragmentDoctorsName = new TextFragment("Doctor's Name: " + _doctorsName);
                TextFragment textFragmentPatientsName = new TextFragment("Patient's Name: " + _patientsName);
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
                string[] detailsLines = _details.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
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
            
                saveFileDialog.Filter = @"PDF Files (*.pdf)|*.pdf";
            
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    pdfDocument.Save(filePath);
                    form1.PdfPath = filePath;
                    DialogResult result = MessageBox.Show("Do you want to compress the saved pdf?", "Compress PDF",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        CompressPdf(filePath, System.IO.Path.GetDirectoryName(filePath), System.IO.Path.GetFileNameWithoutExtension(filePath) + "_compressed.pdf");
                    }
                    
                    Process.Start(filePath);
                }
            }catch (Exception ex) {
                MessageBox.Show($@"An error occurred: {ex.Message}");
            }
        }
        
        private void CompressPdf(string inputFilePath, string outputDirectory, string outputFileName)
        {
            try
            {
                // Open the existing PDF document
                PdfReader reader = new PdfReader(inputFilePath);
                reader.RemoveUnusedObjects(); // Remove unused objects

                // Create an output stream for the compressed PDF
                using (FileStream outputStream = new FileStream(System.IO.Path.Combine(outputDirectory, outputFileName), FileMode.Create))
                {
                    // Create a new document and PdfSmartCopy instance
                   Document document = new Document(reader.GetPageSizeWithRotation(1));
                    PdfSmartCopy smartCopy = new PdfSmartCopy(document, outputStream);

                    document.Open();

                    // Copy each page from the original PDF to the new document
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        PdfImportedPage page = smartCopy.GetImportedPage(reader, i);
                        smartCopy.AddPage(page);
                    }

                    // Close the document and PdfSmartCopy
                    document.Close();
                }

                reader.Close();

                // Notify user that the compression was successful
                MessageBox.Show("PDF compressed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Notify user if an error occurs
                MessageBox.Show($"Error compressing PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        
    }
        
}

