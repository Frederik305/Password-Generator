namespace Generateur_de_mots_de_passe
{
    public partial class SettingsForm : Form
    {
        private string fileName;
        private string fileDirectory;
        private string defaultCarSpeciaux;
        public SettingsForm(string fileName, string fileDirectory, string defaultCarSpeciaux)
        {
            InitializeComponent();
            this.fileName = fileName;
            this.fileDirectory = fileDirectory;
            this.defaultCarSpeciaux = defaultCarSpeciaux;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fileName = textBox1.Text; 
            fileDirectory = textBox2.Text;
            defaultCarSpeciaux = textBox3.Text;


            try
            {
                string filePath = "settings";

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine($"File Name: {fileName}");
                    writer.WriteLine($"File Directory: {fileDirectory}");
                    writer.WriteLine($"Default Caractere Speciaux: {defaultCarSpeciaux}");
                }

                MessageBox.Show("Settings saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred while saving settings: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
