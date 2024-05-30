using System;
using System.Diagnostics;
using System.Windows.Forms;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private string _doctorsName;
        private string _patientsName;
        private string _details;
        private string _date;

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
                Document pdfDocument = new Document();

                Page pdfPage = pdfDocument.Pages.Add();

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
                    Process.Start(filePath);
                }
            }catch (Exception ex) {
                MessageBox.Show($@"An error occurred: {ex.Message}");
            }
        }
    }
        
}

