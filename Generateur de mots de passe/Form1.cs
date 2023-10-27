using System.Collections;

namespace Generateur_de_mots_de_passe
{
    public partial class Form1 : Form
    {
        // Attributs de la classe Form1
        private ArrayList passwordsList = new ArrayList();// Liste pour stocker les mots de passe

        private Password pw;// Instance de la classe Password

        private bool isNewPasswordClicked = false;// Drapeau pour suivre la cr�ation d'un nouveau mot de passe

        // Constructeur de la classe Form1
        public Form1()
        {
            InitializeComponent();
            textBoxMotDePasse.UseSystemPasswordChar = true;

            textBoxCaractSpeciaux.Enabled = false;
            buttonSauvgarderPassword.Enabled = true;

            textBoxMotDePasse.ReadOnly = true;
            textBoxMotDePasse.Enabled = true;

            buttonSauvgarderPassword.Enabled = false;
        }

        // M�thode pour cr�er une nouvelle instance Password
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
            buttonEffacerPassword.Enabled = false;
            buttonSauvgarderPassword.Enabled = false;
        }

        // M�thode pour activer ou d�sactiver checkBoxAfficher
        private void checkBoxAfficher_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAfficher.Checked == true) { textBoxMotDePasse.UseSystemPasswordChar = false; }
            else { textBoxMotDePasse.UseSystemPasswordChar = true; }
        }

        // M�thode pour copier le mot de passe dans le presse-papiers
        private void buttonCopier_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxMotDePasse.Text);
        }

        // M�thode pour afficher la longueur mot de passe
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            PasswordLenghtDisplay.Text = trackBar1.Value.ToString();
        }

        // M�thode pour limiter les caract�res sp�ciaux saisis dans le champ textBoxCaractSpeciaux
        private void textBoxCaractSpeciaux_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar);
        }

        // M�thode pour activer ou d�sactiver la saisie de caract�res sp�ciaux
        private void checkBoxCaractSpeciaux_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCaractSpeciaux.Checked) { textBoxCaractSpeciaux.Enabled = true; }
            else { textBoxCaractSpeciaux.Enabled = false; textBoxCaractSpeciaux.Text = string.Empty; }
        }

        // M�thode pour g�n�rer un mot de passe al�atoire
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

        // M�thode pour g�rer la sauvegarde d'un mot de passe
        private void buttonSauvgarderPassword_Click(object sender, EventArgs e)
        {
            // V�rification de la validit� des donn�es saisies
            if (string.IsNullOrWhiteSpace(textBoxCodeUtilisateur.Text) || string.IsNullOrWhiteSpace(textBoxTitre.Text) || string.IsNullOrWhiteSpace(textBoxMotDePasse.Text))
            {
                MessageBox.Show("svp renplire tout les cases.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // R�cup�ration de la description du nouveau mot de passe
            string newDescription = textBoxTitre.Text;

            // Mise � jour des propri�t�s du mot de passe
            pw.Description = newDescription;
            pw.UserAccount = textBoxCodeUtilisateur.Text;
            textBoxTitre.Enabled = false;
            textBoxCodeUtilisateur.Enabled = false;

            // R�cup�ration de l'indice s�lectionn� dans la liste
            int selectedIndex = listBox1.SelectedIndex;

            if (selectedIndex >= 0 && isNewPasswordClicked == false)
            {
                // Mettre � jour un mot de passe existant
                Password selectedPassword = (Password)passwordsList[selectedIndex];
                selectedPassword.Description = pw.Description;
                selectedPassword.UserAccount = pw.UserAccount;
                selectedPassword.GenerateRandomPassword(selectedPassword.SpecialCharacters, selectedPassword.Length, selectedPassword.HasUppercaseCharacters, selectedPassword.HasDigitCharacters);
                listBox1.Items[selectedIndex] = selectedPassword;
            }
            else
            {
                // V�rification si un mot de passe avec la m�me description existe d�j�
                bool descriptionExists = passwordsList.Cast<Password>().Any(password => password.Description == newDescription);

                if (descriptionExists)
                {
                    MessageBox.Show("Un password a deja la meme description. svp entrer un code unique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ajouter un nouveau mot de passe
                passwordsList.Add(pw);
                listBox1.Items.Clear();

                // Remplir la ListBox avec les mots de passe
                foreach (Password password in passwordsList)
                {
                    listBox1.Items.Add(password);
                }

                // S�lectionner le nouveau mot de passe ajout� dans la liste
                int newIndex = listBox1.Items.IndexOf(pw);
                listBox1.SelectedIndex = newIndex;
            }
        }

        // M�thode pour activer la modification d'un mot de passe
        private void buttonModifierPassword_Click(object sender, EventArgs e)
        {
            isNewPasswordClicked = false;

            textBoxTitre.Enabled = true;
            textBoxCodeUtilisateur.Enabled = true;

            int selectedIndex = listBox1.SelectedIndex;

            if (selectedIndex >= 0)
            {
                // R�cup�rer le mot de passe s�lectionn�
                Password selectedPassword = (Password)passwordsList[selectedIndex];

                // Pr�-remplir les champs avec les donn�es du mot de passe s�lectionn�
                textBoxTitre.Text = selectedPassword.Description;
                textBoxCodeUtilisateur.Text = selectedPassword.UserAccount;
                textBoxMotDePasse.Text = selectedPassword.PasswordValue;
                buttonGenerer.Enabled = true;
            }
        }

        // M�thode pour g�rer la s�lection d'un �l�ment dans la ListBox
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;

            if (selectedIndex >= 0)
            {
                // R�cup�rer le mot de passe s�lectionn�
                Password selectedPassword = (Password)passwordsList[selectedIndex];

                // Pr�-remplir les champs avec les donn�es du mot de passe s�lectionn�
                textBoxTitre.Text = selectedPassword.Description;
                textBoxCodeUtilisateur.Text = selectedPassword.UserAccount;
                textBoxMotDePasse.Text = selectedPassword.PasswordValue;

                textBoxTitre.Enabled = false;
                textBoxCodeUtilisateur.Enabled = false;
                buttonGenerer.Enabled = false;
                buttonModifierPassword.Enabled = true;
                buttonEffacerPassword.Enabled = true;
            }
        }

        // M�thode pour supprimer un mot de passe s�lectionn�
        private void buttonEffacerPassword_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex >= 0)
            {
                passwordsList.RemoveAt(selectedIndex);
                listBox1.Items.RemoveAt(selectedIndex); 

                textBoxTitre.Text = "";
                textBoxCodeUtilisateur.Text = "";
                textBoxMotDePasse.Text = "";
            }
        }
    }
}