using System.Collections;

namespace Generateur_de_mots_de_passe
{
    public partial class Form1 : Form
    {
        // Attributs de la classe Form1
        private ArrayList passwordsList = new ArrayList();// Liste pour stocker les mots de passe

        private Password pw;// Instance de la classe Password

        private bool isNewPasswordClicked = false;// Drapeau pour suivre la création d'un nouveau mot de passe

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

        // Méthode pour créer une nouvelle instance Password
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

        // Méthode pour activer ou désactiver checkBoxAfficher
        private void checkBoxAfficher_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAfficher.Checked == true) { textBoxMotDePasse.UseSystemPasswordChar = false; }
            else { textBoxMotDePasse.UseSystemPasswordChar = true; }
        }

        // Méthode pour copier le mot de passe dans le presse-papiers
        private void buttonCopier_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxMotDePasse.Text);
        }

        // Méthode pour afficher la longueur mot de passe
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            PasswordLenghtDisplay.Text = trackBar1.Value.ToString();
        }

        // Méthode pour limiter les caractères spéciaux saisis dans le champ textBoxCaractSpeciaux
        private void textBoxCaractSpeciaux_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar);
        }

        // Méthode pour activer ou désactiver la saisie de caractères spéciaux
        private void checkBoxCaractSpeciaux_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCaractSpeciaux.Checked) { textBoxCaractSpeciaux.Enabled = true; }
            else { textBoxCaractSpeciaux.Enabled = false; textBoxCaractSpeciaux.Text = string.Empty; }
        }

        // Méthode pour générer un mot de passe aléatoire
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

        // Méthode pour gérer la sauvegarde d'un mot de passe
        private void buttonSauvgarderPassword_Click(object sender, EventArgs e)
        {
            // Vérification de la validité des données saisies
            if (string.IsNullOrWhiteSpace(textBoxCodeUtilisateur.Text) || string.IsNullOrWhiteSpace(textBoxTitre.Text) || string.IsNullOrWhiteSpace(textBoxMotDePasse.Text))
            {
                MessageBox.Show("svp renplire tout les cases.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Récupération de la description du nouveau mot de passe
            string newDescription = textBoxTitre.Text;

            // Mise à jour des propriétés du mot de passe
            pw.Description = newDescription;
            pw.UserAccount = textBoxCodeUtilisateur.Text;
            textBoxTitre.Enabled = false;
            textBoxCodeUtilisateur.Enabled = false;

            // Récupération de l'indice sélectionné dans la liste
            int selectedIndex = listBox1.SelectedIndex;

            if (selectedIndex >= 0 && isNewPasswordClicked == false)
            {
                // Mettre à jour un mot de passe existant
                Password selectedPassword = (Password)passwordsList[selectedIndex];
                selectedPassword.Description = pw.Description;
                selectedPassword.UserAccount = pw.UserAccount;
                selectedPassword.GenerateRandomPassword(selectedPassword.SpecialCharacters, selectedPassword.Length, selectedPassword.HasUppercaseCharacters, selectedPassword.HasDigitCharacters);
                listBox1.Items[selectedIndex] = selectedPassword;
            }
            else
            {
                // Vérification si un mot de passe avec la même description existe déjà
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

                // Sélectionner le nouveau mot de passe ajouté dans la liste
                int newIndex = listBox1.Items.IndexOf(pw);
                listBox1.SelectedIndex = newIndex;
            }
        }

        // Méthode pour activer la modification d'un mot de passe
        private void buttonModifierPassword_Click(object sender, EventArgs e)
        {
            isNewPasswordClicked = false;

            textBoxTitre.Enabled = true;
            textBoxCodeUtilisateur.Enabled = true;

            int selectedIndex = listBox1.SelectedIndex;

            if (selectedIndex >= 0)
            {
                // Récupérer le mot de passe sélectionné
                Password selectedPassword = (Password)passwordsList[selectedIndex];

                // Pré-remplir les champs avec les données du mot de passe sélectionné
                textBoxTitre.Text = selectedPassword.Description;
                textBoxCodeUtilisateur.Text = selectedPassword.UserAccount;
                textBoxMotDePasse.Text = selectedPassword.PasswordValue;
                buttonGenerer.Enabled = true;
            }
        }

        // Méthode pour gérer la sélection d'un élément dans la ListBox
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;

            if (selectedIndex >= 0)
            {
                // Récupérer le mot de passe sélectionné
                Password selectedPassword = (Password)passwordsList[selectedIndex];

                // Pré-remplir les champs avec les données du mot de passe sélectionné
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

        // Méthode pour supprimer un mot de passe sélectionné
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