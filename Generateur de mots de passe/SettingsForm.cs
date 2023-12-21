namespace Generateur_de_mots_de_passe
{
    public partial class SettingsForm : Form
    {
        /// <summary>
        /// nom du fichier
        /// </summary>
        private string fileName;
        /// <summary>
        /// Répertoire du fichier
        /// </summary>
        private string fileDirectory;
        /// <summary>
        /// Caractere par default
        /// </summary>
        private string defaultCarSpeciaux;

        /// <summary>
        /// initialise le form de settings
        /// </summary>
        /// <param name="fileName">nom du fichier</param>
        /// <param name="fileDirectory">Répertoire du fichier</param>
        /// <param name="defaultCarSpeciaux">Caractere par default</param>
        public SettingsForm(string fileName, string fileDirectory, string defaultCarSpeciaux)
        {
            InitializeComponent();
            this.fileName = fileName;
            this.fileDirectory = fileDirectory;
            this.defaultCarSpeciaux = defaultCarSpeciaux;
        }

        /// <summary>
        /// sauvegarde les valeurs dans le fichier settings lorsque le button2 est clicker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                MessageBox.Show("Settings sauvegarder!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du save des settings: {ex.Message}");
            }
        }

        /// <summary>
        /// button pour ouvrir l'explorateur de fichier et permetre a l'utilisateur de choisire le path du fichier settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ChoosePath();
        }

        /// <summary>
        /// verification des charactere speciaux entrer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar);
        }

        /// <summary>
        /// Methode pour ouvrir l'explorateur de fichier
        /// </summary>
        private void ChoosePath()
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    textBox2.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        /// <summary>
        /// met les valeurs dans leurs text box lors de l'ouverture du form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = fileName;
            textBox2.Text = fileDirectory;
            textBox3.Text = defaultCarSpeciaux;
        }
    }
}
