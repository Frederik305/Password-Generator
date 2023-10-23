using System.Collections;

namespace Generateur_de_mots_de_passe
{
    public partial class Form1 : Form
    {
        private ArrayList passwordsList = new ArrayList();

        private Password passwordGenerator = new Password();

        public Form1()
        {
            InitializeComponent();
            textBoxCaractSpeciaux.Enabled = false;

            textBoxMotDePasse.ReadOnly = true;
            textBoxMotDePasse.Enabled = true;
            checkBoxAfficher.Enabled = true;
            buttonCopier.Enabled = true;
            textBoxMotDePasse.UseSystemPasswordChar = true;
        }

        private void buttonNouveauPassword_Click(object sender, EventArgs e)
        {
            Password passwordGenerator = new Password();
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
            e.Handled = char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar);
        }

        private void checkBoxCaractSpeciaux_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCaractSpeciaux.Checked) { textBoxCaractSpeciaux.Enabled = true; }
            else { textBoxCaractSpeciaux.Enabled = false; }

        }

        private void buttonGenerer_Click(object sender, EventArgs e)
        {
            var pw = new Password();
            pw.SpecialCharacters = textBoxCaractSpeciaux.Text;
            pw.Length = trackBar1.Value;
            pw.HasUppercaseCharacters = checkBoxMaj.Checked;
            pw.HasDigitCharacters = checkBoxChiffres.Checked;
            textBoxMotDePasse.Text = pw.GenerateRandomPassword(pw.SpecialCharacters, pw.Length, pw.HasUppercaseCharacters, pw.HasDigitCharacters);
        }

        private void checkBoxMaj_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxChiffres_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonSauvgarderPassword_Click(object sender, EventArgs e)
        {

        }

        private void textBoxMotDePasse_TextChanged(object sender, EventArgs e)
        {

        }
    }
}