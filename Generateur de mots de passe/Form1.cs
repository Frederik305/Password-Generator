using PwdGen;
using System.Drawing.Text;

namespace Generateur_de_mots_de_passe
{
    public partial class Form1 : Form
    {
        // Attributs de la classe Form1
        private PasswordDataFile pwdFile = new PasswordDataFile("pwd");// Ficher de sauvegarde des mots de passe

        private List<Password> passwordsList = new List<Password>();// Liste pour stocker les mots de passe

        private Password pw;// Instance de la classe Password

        private bool isNewPasswordClicked = false;// Drapeau pour suivre la création d'un nouveau mot de passe

        private string oldDescription;

        private bool IsGen = false;

        // Constructeur de la classe Form1
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var newList = pwdFile.Load();

                // Remplir la ListBox avec les mots de passe
                foreach (Password password in newList)
                {
                    passwordsList.Add(password);
                    listBox1.Items.Add(password);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            baseValues();
        }

        // Méthode pour créer une nouvelle instance Password
        private void buttonNouveauPassword_Click(object sender, EventArgs e)
        {
            isNewPasswordClicked = true;

            pw = new Password();

            trackBar1.Value = pw.Length;
            PasswordLenghtDisplay.Text = pw.Length.ToString();
            checkBoxMaj.Checked = pw.HasUppercaseCharacters;
            checkBoxChiffres.Checked = pw.HasDigitCharacters;
            checkBoxCaractSpeciaux.Checked = pw.HasSpecialCharacters;
            textBoxCaractSpeciaux.Text = pw.SpecialCharacters;

            enableAll();
            clearAll();
            readOnlyAllTextBox(false);
            textBoxMotDePasse.ReadOnly = true;
            textBoxCaractSpeciaux.ReadOnly = true;
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
            if (checkBoxCaractSpeciaux.Checked) { textBoxCaractSpeciaux.ReadOnly = false; }
            else { textBoxCaractSpeciaux.ReadOnly = true; textBoxCaractSpeciaux.Text = string.Empty; }
        }

        // Méthode pour générer un mot de passe aléatoire
        private void buttonGenerer_Click(object sender, EventArgs e)
        {
            pw.SpecialCharacters = textBoxCaractSpeciaux.Text;
            pw.Length = trackBar1.Value;
            pw.HasUppercaseCharacters = checkBoxMaj.Checked;
            pw.HasDigitCharacters = checkBoxChiffres.Checked;
            pw.HasSpecialCharacters = checkBoxCaractSpeciaux.Checked;
            pw.GenerateRandomPassword(pw.SpecialCharacters, pw.Length, pw.HasUppercaseCharacters, pw.HasDigitCharacters, pw.HasSpecialCharacters);
            textBoxMotDePasse.Text = pw.PasswordValue;

            buttonCopier.Enabled = true;
            checkBoxAfficher.Enabled = true;
            buttonSauvgarderPassword.Enabled = true;
        }

        // Méthode pour gérer la sauvegarde d'un mot de passe
        private void buttonSauvgarderPassword_Click(object sender, EventArgs e)
        {
            // Vérification de la validité des données saisies
            if (string.IsNullOrWhiteSpace(textBoxTitre.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxTitre, "svp remplire la description");
                textBoxTitre.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(textBoxCodeUtilisateur.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxCodeUtilisateur, "svp remplire le code utilisateur");
                textBoxCodeUtilisateur.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(textBoxMotDePasse.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxMotDePasse, "svp generer le mot de passe");
                buttonGenerer.Focus();
                return;
            }
            else if (textBoxCaractSpeciaux.Text == string.Empty && checkBoxCaractSpeciaux.Checked == true)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxCaractSpeciaux, "Aucun charactere speciaux on ete selectionner");
                textBoxCaractSpeciaux.Focus();
                return;
            }


            // Récupération de la description du nouveau mot de passe
            string newDescription = textBoxTitre.Text;

            // Récupération de l'indice sélectionné dans la liste
            int selectedIndex = listBox1.SelectedIndex;

            if (DialogResult.Yes == MessageBox.Show("Est-tu sur de vouloir sauvegarder le mot de passe?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (isNewPasswordClicked)
                {
                    // Mise à jour des propriétés du mot de passe
                    pw.Description = textBoxTitre.Text;
                    pw.UserAccount = textBoxCodeUtilisateur.Text;
                    pw.URL = textBoxURL.Text;
                    pw.Note = textBoxNote.Text;
                    pw.PasswordValue = textBoxMotDePasse.Text;

                    // Ajouter un nouveau mot de passe
                    passwordsList.Add(pw);
                    listBox1.Items.Clear();

                    // Remplir la ListBox avec les mots de passe
                    foreach (Password password in passwordsList)
                    {
                        listBox1.Items.Add(password);
                    }

                    // Sélectionne le nouveau mot de passe ajouté dans la liste
                    int newIndex = listBox1.Items.IndexOf(pw);
                    listBox1.SelectedIndex = newIndex;

                    try { pwdFile.Save(passwordsList); } catch (Exception ex) { MessageBox.Show(ex.Message); }
                    errorProvider1.Clear();
                    IsGen = true;
                }
                else if (selectedIndex >= 0 && oldDescription == textBoxTitre.Text || verification(newDescription) == false)
                {
                    pw.Description = textBoxTitre.Text;
                    pw.UserAccount = textBoxCodeUtilisateur.Text;
                    pw.URL = textBoxURL.Text;
                    pw.Note = textBoxNote.Text;
                    pw.PasswordValue = textBoxMotDePasse.Text;
                    passwordsList[selectedIndex] = pw;
                    listBox1.Items[selectedIndex] = pw;

                    try { pwdFile.Save(passwordsList); } catch (Exception ex) { MessageBox.Show(ex.Message); }
                    errorProvider1.Clear();
                    IsGen = true;
                }
            }
            readOnlyAllTextBox(true);
            trackBar1.Enabled = false;
            checkBoxMaj.Enabled = false;
            checkBoxChiffres.Enabled = false;
            checkBoxCaractSpeciaux.Enabled = false;

            label6.Text = $"Il y a: {passwordsList.Count} items dans la list des passwords";
            pw = new Password();
        }
     

        // Méthode pour activer la modification d'un mot de passe
        private void buttonModifierPassword_Click(object sender, EventArgs e)
        {
            isNewPasswordClicked = false;
            selectedIndex();
            {
                oldDescription = textBoxTitre.Text;
                buttonModifierPassword.Enabled = false;
                enableAll();
                readOnlyAllTextBox(false);
                textBoxMotDePasse.ReadOnly = true;
            }
        }

        // Méthode pour gérer la sélection d'un élément dans la ListBox
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex();
            {
                buttonGenerer.Enabled = false;
                buttonModifierPassword.Enabled = true;
                buttonEffacerPassword.Enabled = true;
                textBoxCaractSpeciaux.Enabled = false;
                buttonSauvgarderPassword.Enabled = false;
                readOnlyAllTextBox(true);
            }
            if(IsGen == true) { IsGen = false; }
            else { errorProvider1.Clear(); }
        }
        private void selectedIndex()
        {
            int selectedIndex = listBox1.SelectedIndex;

            if (selectedIndex >= 0)
            {
                // Récupére le mot de passe sélectionné
                pw = passwordsList[selectedIndex];

                // Pré-remplir les champs avec les données du mot de passe sélectionné
                textBoxTitre.Text = pw.Description;
                textBoxCodeUtilisateur.Text = pw.UserAccount;
                textBoxURL.Text = pw.URL;
                textBoxNote.Text = pw.Note;
                trackBar1.Value = pw.Length;
                PasswordLenghtDisplay.Text = pw.Length.ToString();
                textBoxMotDePasse.Text = pw.PasswordValue;
                checkBoxMaj.Checked = pw.HasUppercaseCharacters;
                checkBoxChiffres.Checked = pw.HasDigitCharacters;
                checkBoxCaractSpeciaux.Checked = pw.HasSpecialCharacters;
                textBoxCaractSpeciaux.Text = pw.SpecialCharacters;
            }
        }

        // Méthode pour supprimer un mot de passe sélectionné
        private void buttonEffacerPassword_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Est-tu sur de vouloir supprimer le mot de passe?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            int selectedIndex = listBox1.SelectedIndex;
            if (result == DialogResult.Yes && selectedIndex >= 0)
            {

                passwordsList.RemoveAt(selectedIndex);
                listBox1.Items.RemoveAt(selectedIndex);

                try{ pwdFile.Save(passwordsList); } catch (Exception ex){ MessageBox.Show(ex.Message); }

                baseValues();
            }
        }
        private bool verification(string newDescription)
        {
            bool descriptionExists = passwordsList.Cast<Password>().Any(password => password.Description == newDescription && password != pw);

            if (descriptionExists)
            {
                errorProvider1.SetError(textBoxTitre, "Un password a deja la meme description. svp entrer un code unique");
                return true;
            }
            return false;
        }

        private void baseValues()
        {
            disableAll();
            textBoxMotDePasse.UseSystemPasswordChar = true;
            label6.Text = $"Il y a: {passwordsList.Count} items dans la list des passwords";
            textBoxTitre.Text = "";
            textBoxCodeUtilisateur.Text = "";
            textBoxURL.Text = "";
            textBoxMotDePasse.Text = "";
            trackBar1.Value = 12;
            checkBoxMaj.Checked = false;
            checkBoxChiffres.Checked = false;
            checkBoxCaractSpeciaux.Checked = false;
            checkBoxAfficher.Checked = false;
            PasswordLenghtDisplay.Text = trackBar1.Value.ToString();
            buttonSauvgarderPassword.Enabled = false;
            buttonEffacerPassword.Enabled = false;
            buttonModifierPassword.Enabled = false;
            buttonNouveauPassword.Enabled = true;
        }
        private void disableAll()
        {
            textBoxTitre.Enabled = false;
            textBoxCodeUtilisateur.Enabled = false;
            textBoxURL.Enabled = false;
            textBoxNote.Enabled = false;
            textBoxMotDePasse.Enabled = false;
            textBoxCaractSpeciaux.Enabled = false;
            buttonSauvgarderPassword.Enabled = false;
            trackBar1.Enabled = false;
            checkBoxMaj.Enabled = false;
            checkBoxChiffres.Enabled = false;
            checkBoxCaractSpeciaux.Enabled = false;
            label4.Enabled = false;
            label5.Enabled = false;
            PasswordLenghtDisplay.Enabled = false;
            buttonCopier.Enabled = false;
            checkBoxAfficher.Enabled = false;
        }
        private void enableAll()
        {
            textBoxTitre.Enabled = true;
            textBoxCodeUtilisateur.Enabled = true;
            textBoxURL.Enabled = true;
            textBoxNote.Enabled = true;
            textBoxMotDePasse.Enabled = true;
            textBoxCaractSpeciaux.Enabled = true;
            buttonGenerer.Enabled = true;
            buttonSauvgarderPassword.Enabled = true;
            trackBar1.Enabled = true;
            checkBoxMaj.Enabled = true;
            checkBoxChiffres.Enabled = true;
            checkBoxCaractSpeciaux.Enabled = true;
            label4.Enabled = true;
            label5.Enabled = true;
            PasswordLenghtDisplay.Enabled = true;
            buttonCopier.Enabled = true;
            checkBoxAfficher.Enabled = true;
        }
        private void clearAll()
        {
            textBoxTitre.Text = string.Empty;
            textBoxCodeUtilisateur.Text = string.Empty;
            textBoxURL.Text = string.Empty;
            textBoxNote.Text = string.Empty;
            textBoxMotDePasse.Text = string.Empty;
            textBoxCaractSpeciaux.Text = string.Empty;
        }
        private void readOnlyAllTextBox(bool readOnly)
        {
            textBoxTitre.ReadOnly = readOnly;
            textBoxCodeUtilisateur.ReadOnly = readOnly;
            textBoxURL.ReadOnly = readOnly;
            textBoxNote.ReadOnly = readOnly;
        }
    }
}