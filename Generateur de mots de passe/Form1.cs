using System.Collections;

namespace Generateur_de_mots_de_passe
{
    public partial class Form1 : Form
    {
        private ArrayList passwordsList = new ArrayList();

        private Password pw;

        private bool isNewPasswordClicked = false;

        public Form1()
        {
            InitializeComponent();
            textBoxMotDePasse.UseSystemPasswordChar = true;
            //buttonModifierPassword.Enabled = true;

            textBoxCaractSpeciaux.Enabled = false;
            buttonSauvgarderPassword.Enabled = true;

            textBoxMotDePasse.ReadOnly = true;
            textBoxMotDePasse.Enabled = true;

            buttonSauvgarderPassword.Enabled = false;

            //checkBoxAfficher.Enabled = true;

            //buttonCopier.Enabled = true;
        }

        private void buttonNouveauPassword_Click(object sender, EventArgs e)
        {
            isNewPasswordClicked = true;

            pw = new Password();
            textBoxTitre.Enabled = true;
            textBoxCodeUtilisateur.Enabled = true;
            buttonGenerer.Enabled = true;
            textBoxTitre.Text = "";
            textBoxCodeUtilisateur.Text = "";
            textBoxMotDePasse.Text = "";

            buttonModifierPassword.Enabled = false;
            buttonCopier.Enabled = false;
            checkBoxAfficher.Enabled = false;
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
            else { textBoxCaractSpeciaux.Enabled = false; textBoxCaractSpeciaux.Text = string.Empty; }
        }

        private void buttonGenerer_Click(object sender, EventArgs e)
        {
            pw.SpecialCharacters = textBoxCaractSpeciaux.Text;
            pw.Length = trackBar1.Value;
            pw.HasUppercaseCharacters = checkBoxMaj.Checked;
            pw.HasDigitCharacters = checkBoxChiffres.Checked;
            pw.GenerateRandomPassword(pw.SpecialCharacters, pw.Length, pw.HasUppercaseCharacters, pw.HasDigitCharacters);
            textBoxMotDePasse.Text = pw.PasswordValue;

            buttonCopier.Enabled = true;
            checkBoxAfficher.Enabled = true;
            buttonSauvgarderPassword.Enabled = true;
        }

        private void checkBoxMaj_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxChiffres_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonSauvgarderPassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCodeUtilisateur.Text) || string.IsNullOrWhiteSpace(textBoxTitre.Text) || string.IsNullOrWhiteSpace(textBoxMotDePasse.Text))
            {
                MessageBox.Show("svp renplire tout les cases.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newDescription = textBoxTitre.Text;

            bool descriptionExists = passwordsList.Cast<Password>().Any(password => password.Description == newDescription);

            if (descriptionExists)
            {
                MessageBox.Show("Un password a deja la meme description. svp entrer un code unique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pw.Description = newDescription;
            pw.UserAccount = textBoxCodeUtilisateur.Text;

            textBoxTitre.Enabled = false;
            textBoxCodeUtilisateur.Enabled = false;

            int selectedIndex = listBox1.SelectedIndex;

            if (selectedIndex >= 0 && isNewPasswordClicked == false)
            {
                Password selectedPassword = (Password)passwordsList[selectedIndex];
                selectedPassword.Description = pw.Description;
                selectedPassword.UserAccount = pw.UserAccount;

                selectedPassword.GenerateRandomPassword(selectedPassword.SpecialCharacters, selectedPassword.Length, selectedPassword.HasUppercaseCharacters, selectedPassword.HasDigitCharacters);

                listBox1.Items[selectedIndex] = selectedPassword;
            }
            else
            {
                passwordsList.Add(pw);
                listBox1.Items.Clear();

                foreach (Password password in passwordsList)
                {
                    listBox1.Items.Add(password);
                }

                int newIndex = listBox1.Items.IndexOf(pw);
                listBox1.SelectedIndex = newIndex;
            }

        }


        private void textBoxMotDePasse_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTitre_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCodeUtilisateur_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonModifierPassword_Click(object sender, EventArgs e)
        {
            isNewPasswordClicked = false;

            textBoxTitre.Enabled = true;
            textBoxCodeUtilisateur.Enabled = true;

            int selectedIndex = listBox1.SelectedIndex;

            if (selectedIndex >= 0)
            {
                Password selectedPassword = (Password)passwordsList[selectedIndex];

                textBoxTitre.Text = selectedPassword.Description;
                textBoxCodeUtilisateur.Text = selectedPassword.UserAccount;
                textBoxMotDePasse.Text = selectedPassword.PasswordValue;


                buttonGenerer.Enabled = true;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;

            if (selectedIndex >= 0)
            {
                Password selectedPassword = (Password)passwordsList[selectedIndex];

                textBoxTitre.Text = selectedPassword.Description;
                textBoxCodeUtilisateur.Text = selectedPassword.UserAccount;
                textBoxMotDePasse.Text = selectedPassword.PasswordValue;

                textBoxTitre.Enabled = false;
                textBoxCodeUtilisateur.Enabled = false;
                buttonGenerer.Enabled = false;

                buttonModifierPassword.Enabled = true;
            }
        }
    }
}