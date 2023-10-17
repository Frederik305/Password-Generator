namespace Generateur_de_mots_de_passe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxMotDePasse.Enabled = true;
            checkBoxAfficher.Enabled = true;
            buttonCopier.Enabled = true;
            textBoxMotDePasse.UseSystemPasswordChar = true;
        }

        private void buttonNouveauPassword_Click(object sender, EventArgs e)
        {
            textBoxTitre.Enabled = true;
            textBoxCodeUtilisateur.Enabled = true;
            buttonGenerer.Enabled = true;
        }

        private void checkBoxAfficher_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAfficher.Checked == true) { textBoxMotDePasse.UseSystemPasswordChar = false; }
            else { textBoxMotDePasse.UseSystemPasswordChar = true; }
        }

        private void buttonCopier_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxMotDePasse.Text);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            PasswordLenghtDisplay.Text = trackBar1.Value.ToString();
        }

        private void textBoxCaractSpeciaux_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar);
        }

        private void checkBoxCaractSpeciaux_CheckedChanged(object sender, EventArgs e)
        {
            string SpecialCharacters = textBoxCaractSpeciaux.Text;

        }
    }
}