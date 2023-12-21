using PwdGen;
using Zxcvbn;
using System.ComponentModel;
using System.Data;

namespace Generateur_de_mots_de_passe
{
    /// <summary>
    /// Classe principale de l'application qui g�re la g�n�ration et la sauvegarde de mots de passe.
    /// </summary>
    public partial class Form1 : Form
    {
        // Attributs de la classe Form1

        SettingsForm? settingsForm;

        private string fileName;
        private string fileDirectory;
        private string defaultCarSpeciaux;

        /// <summary>
        /// Fichier de sauvegarde des mots de passe.
        /// </summary>
        private PasswordDataFile pwdFile;

        /// <summary>
        /// Liste pour stocker les mots de passe.
        /// </summary>
        private List<Password> passwordsList = new List<Password>();

        private BindingList<Password> demosBindingList;

        /// <summary>
        /// Instance de la classe Password.
        /// </summary>
        private Password pw;

        /// <summary>
        /// Indique si le bouton Nouveau Password a �t� cliqu�.
        /// </summary>
        private bool isNewPasswordClicked = false;

        /// <summary>
        /// Description pr�c�dente pour de la description du mot de passe.
        /// </summary>
        private string oldDescription;

        /// <summary>
        /// Indique si un mot de passe a �t� g�n�r�.
        /// </summary>
        private bool IsGen = false;

        private TrackBar[] trackBars;

        /// <summary>
        /// Constructeur de la classe Form1.
        /// Initialise les composants graphiques de la fen�tre.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            InitializeTrackBars();
        }

        /// <summary>
        /// M�thode appel�e lors du chargement de la fen�tre.
        /// Charge la liste de mots de passe depuis le fichier et initialise l'interface.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettingsFromFile();
            pwdFile = new PasswordDataFile(fileName, fileDirectory);
            try
            {
                passwordsList = pwdFile.Load();
                demosBindingList = new BindingList<Password>(passwordsList);
                listBox1.DataSource = demosBindingList;
                listBox1.DisplayMember = "Description";
            }
            catch (Exception) { demosBindingList = new BindingList<Password>(passwordsList); }

            baseValues();
        }

        /// <summary>
        /// M�thode appel�e lors du click du boutton nouveau.
        /// cree une nouvelle instance de Password et link les donnees de Password avec les inputs de l'app graphique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNouveauPassword_Click(object sender, EventArgs e)
        {
            isNewPasswordClicked = true;

            pw = new Password();

            bindingSource1.DataSource = pw;

            enableAll();
            clearAll();
            readOnlyAllTextBox(false);
            VerifyPassword();
            if (defaultCarSpeciaux != string.Empty)
            {
                pw.HasSpecialCharacters = true;
                pw.SpecialCharacters = defaultCarSpeciaux;
                bindingSource1.ResetBindings(false);
            }
            textBoxCaractSpeciaux.ReadOnly = true;
        }

        /// <summary>
        /// M�thode pour afficher le mot de passe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxAfficher_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAfficher.Checked == true) { textBoxMotDePasse.UseSystemPasswordChar = false; }
            else { textBoxMotDePasse.UseSystemPasswordChar = true; }
        }

        /// <summary>
        /// M�thode pour copier le mot de passe dans le presse-papiers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCopier_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxMotDePasse.Text);
        }

        /// <summary>
        /// M�thode pour afficher la longueur mot de passe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            PasswordLenghtDisplay.Text = trackBar1.Value.ToString();
            InitializeTrackBars();
        }

        /// <summary>
        /// M�thode pour limiter les caract�res sp�ciaux saisis dans le champ textBoxCaractSpeciaux
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxCaractSpeciaux_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar);
        }

        /// <summary>
        /// M�thode pour activer ou d�sactiver la saisie de caract�res sp�ciaux
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxCaractSpeciaux_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCaractSpeciaux.Checked)
            {
                trackBar5.Enabled = true;
                textBoxCaractSpeciaux.ReadOnly = false;
                if (defaultCarSpeciaux != string.Empty)
                {
                    pw.HasSpecialCharacters = true;
                    pw.SpecialCharacters = defaultCarSpeciaux;
                    bindingSource1.ResetBindings(false);
                }
            }
            else { textBoxCaractSpeciaux.ReadOnly = true; textBoxCaractSpeciaux.Text = string.Empty; trackBar5.Enabled = false; trackBar5.Value = 0; label10.Text = trackBar5.Value.ToString(); InitializeTrackBars(); }
        }

        /// <summary>
        /// M�thode pour g�n�rer un mot de passe al�atoire.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGenerer_Click(object sender, EventArgs e)
        {
            pw.GenerateRandomPassword(pw.SpecialCharacters, pw.Length, pw.HasUppercaseCharacters, pw.HasDigitCharacters, pw.HasSpecialCharacters, trackBar2.Value, trackBar3.Value, trackBar4.Value, trackBar5.Value);

            bindingSource1.ResetBindings(false);

            VerifyPassword();

            buttonCopier.Enabled = true;
            checkBoxAfficher.Enabled = true;
            buttonSauvgarderPassword.Enabled = true;
        }

        /// <summary>
        /// M�thode pour g�rer la sauvegarde d'un mot de passe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSauvgarderPassword_Click(object sender, EventArgs e)
        {
            // V�rification de la validit� des donn�es saisies
            if (string.IsNullOrWhiteSpace(textBoxTitre.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxTitre, "svp, remplissez la description.");
                labelMessage.Text = "La description est incompl�te.";
                labelMessage.ForeColor = Color.Red;
                textBoxTitre.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(textBoxCodeUtilisateur.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxCodeUtilisateur, "svp, remplissez le code utilisateur.");
                labelMessage.Text = "le code utilisateur est incomplet";
                labelMessage.ForeColor = Color.Red;
                textBoxCodeUtilisateur.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(textBoxMotDePasse.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxMotDePasse, "svp, g�n�re le mot de passe.");
                labelMessage.Text = "Le mot de passe est incomplet.";
                labelMessage.ForeColor = Color.Red;
                buttonGenerer.Focus();
                return;
            }
            else if (textBoxCaractSpeciaux.Text == string.Empty && checkBoxCaractSpeciaux.Checked == true)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBoxCaractSpeciaux, "Aucun caract�re sp�cial n'a �t� s�lectionn�.");
                labelMessage.Text = "Aucun caract�re sp�cial n'a �t� s�lectionn�.";
                labelMessage.ForeColor = Color.Red;
                textBoxCaractSpeciaux.Focus();
                return;
            }


            // R�cup�ration de la description du nouveau mot de passe
            string newDescription = textBoxTitre.Text;

            // R�cup�ration de l'indice s�lectionn� dans la liste
            int selectedIndex = listBox1.SelectedIndex;

            if (DialogResult.Yes == MessageBox.Show("�tes-vous s�r de vouloir sauvegarder le mot de passe?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (isNewPasswordClicked && verification(newDescription) == false)
                {
                    demosBindingList.Add(pw);

                    int newIndex = listBox1.Items.IndexOf(pw);

                    listBox1.DataSource = null;
                    listBox1.DataSource = demosBindingList;

                    listBox1.SelectedIndex = newIndex;

                    DateTime currentDate = DateTime.Now;
                    pw.DateCreation = ("Date de Creation: " + currentDate.ToString("yyyy-MM-dd HH:mm:ss"));

                    //label17.Text = pw.DateCreation;

                    try { pwdFile.Save(passwordsList); } catch (Exception ex) { MessageBox.Show(ex.Message); }
                    errorProvider1.Clear();

                    IsGen = true;
                    labelMessage.Text = "La cr�ation du mot de passe a �t� r�alis�e avec succ�s.";
                    labelMessage.ForeColor = Color.Green;
                }
                else if (selectedIndex >= 0 && oldDescription == textBoxTitre.Text || verification(newDescription) == false)
                {
                    passwordsList[selectedIndex] = pw;

                    listBox1.DataSource = null;
                    listBox1.DataSource = demosBindingList;

                    DateTime currentDate = DateTime.Now;
                    pw.DateDernieremodif = ("Date de derni�re modification: " + currentDate.ToString("yyyy-MM-dd HH:mm:ss"));

                    try { pwdFile.Save(passwordsList); } catch (Exception ex) { MessageBox.Show(ex.Message); }
                    errorProvider1.Clear();
                    IsGen = true;
                    labelMessage.Text = "La modification du mot de passe a �t� effectu�e avec succ�s.";
                    labelMessage.ForeColor = Color.Green;
                }
            }
            readOnlyAllTextBox(true);
            trackBar1.Enabled = false;
            checkBoxMaj.Enabled = false;
            checkBoxChiffres.Enabled = false;
            checkBoxCaractSpeciaux.Enabled = false;
            bindingSource1.ResetBindings(false);
            label6.Text = $"Il y a: {passwordsList.Count} �l�ments dans la liste des mots de passe.";
        }


        /// <summary>
        /// M�thode pour activer la modification d'un mot de passe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// M�thode pour g�rer la s�lection d'un �l�ment dans la ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex();
            {
                enableAll();
                buttonGenerer.Enabled = false;
                buttonModifierPassword.Enabled = true;
                buttonEffacerPassword.Enabled = true;
                textBoxCaractSpeciaux.Enabled = false;
                buttonSauvgarderPassword.Enabled = false;
                checkBoxCaractSpeciaux.Enabled = false;
                checkBoxChiffres.Enabled = false;
                checkBoxMaj.Enabled = false;
                trackBar1.Enabled = false;
                trackBar2.Enabled = false;
                trackBar3.Enabled = false;
                trackBar4.Enabled = false;
                trackBar5.Enabled = false;

                PasswordLenghtDisplay.Text = pw.Length.ToString();
                trackBar2.Maximum = pw.Length; trackBar3.Maximum = pw.Length; trackBar4.Maximum = pw.Length; trackBar5.Maximum = pw.Length;

                readOnlyAllTextBox(true);
            }
            if (IsGen == true) { IsGen = false; }
            else if (IsGen == false) { errorProvider1.Clear(); labelMessage.Text = string.Empty; }
        }

        /// <summary>
        /// M�thode pour afficher et modifer l'instance password
        /// </summary>
        private void selectedIndex()
        {
            int selectedIndex = listBox1.SelectedIndex;

            if (selectedIndex >= 0)
            {
                // R�cup�re le mot de passe s�lectionn�
                pw = (Password)listBox1.SelectedItem;
                bindingSource1.DataSource = pw;
                trackBar1.Value = pw.Length;
                VerifyPassword();
            }
        }

        /// <summary>
        /// M�thode pour supprimer un mot de passe s�lectionn�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEffacerPassword_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("�tes-vous s�r de vouloir supprimer le mot de passe?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            int selectedIndex = listBox1.SelectedIndex;
            if (result == DialogResult.Yes && selectedIndex >= 0)
            {
                Password selectedPassword = listBox1.SelectedItem as Password;

                demosBindingList.Remove(selectedPassword);

                try { pwdFile.Save(passwordsList); } catch (Exception ex) { MessageBox.Show(ex.Message); }

                baseValues();

                labelMessage.Text = "La suppression du mot de passe a �t� effectu�e avec succ�s.";
                labelMessage.ForeColor = Color.Green;
            }
        }
        /// <summary>
        /// Methode de verification
        /// </summary>
        /// <param name="newDescription"></param>
        /// <returns>true si la description existe deja</returns>
        private bool verification(string newDescription)
        {
            bool descriptionExists = passwordsList.Cast<Password>().Any(password => password.Description == newDescription && password != pw);

            if (descriptionExists)
            {
                errorProvider1.SetError(textBoxTitre, "Un mot de passe poss�de d�j� la m�me description. Veuillez entrer un code unique.");
                labelMessage.Text = "Un mot de passe poss�de d�j� la m�me description.";
                labelMessage.ForeColor = Color.Red;
                return true;
            }
            return false;
        }

        /// <summary>
        /// M�thode pour d�sactiver tous les champs de l'interface.
        /// </summary>
        private void baseValues()
        {
            disableAll();
            textBoxMotDePasse.UseSystemPasswordChar = true;
            label6.Text = $"Il y a: {passwordsList.Count} �l�ments dans la liste des mots de passe.";
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
            buttonGenerer.Enabled = false;
        }

        /// <summary>
        /// M�thode pour desactiver les valeurs.
        /// </summary>
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
            trackBar2.Enabled = false;
            trackBar3.Enabled = false;
            trackBar4.Enabled = false;
            trackBar5.Enabled = false;
        }

        /// <summary>
        /// M�thode pour activer les valeurs.
        /// </summary>
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
            trackBar2.Enabled = true;
        }

        /// <summary>
        /// M�thode pour clear les champs des textbox
        /// </summary>
        private void clearAll()
        {
            textBoxTitre.Text = string.Empty;
            textBoxCodeUtilisateur.Text = string.Empty;
            textBoxURL.Text = string.Empty;
            textBoxNote.Text = string.Empty;
            textBoxMotDePasse.Text = string.Empty;
            textBoxCaractSpeciaux.Text = string.Empty;
            textBoxNote.Text = string.Empty;
        }

        /// <summary>
        /// M�thode pour mettre les champs des textbox en readonly
        /// </summary>
        /// <param name="readOnly">Bool</param>
        private void readOnlyAllTextBox(bool readOnly)
        {
            textBoxTitre.ReadOnly = readOnly;
            textBoxCodeUtilisateur.ReadOnly = readOnly;
            textBoxURL.ReadOnly = readOnly;
            textBoxNote.ReadOnly = readOnly;
            textBoxMotDePasse.ReadOnly = readOnly;
        }

        /// <summary>
        /// M�thode pour syncroniser les trackBars de min
        /// </summary>
        private void InitializeTrackBars()
        {
            trackBars = new TrackBar[] { trackBar2, trackBar3, trackBar4, trackBar5 };

            foreach (var trackBar in trackBars)
            {
                trackBar.Maximum = trackBar1.Value;
                trackBar.Scroll += TrackBar_Scroll;
            }
            label7.Text = trackBar2.Value.ToString();
            label8.Text = trackBar3.Value.ToString();
            label9.Text = trackBar4.Value.ToString();
            label10.Text = trackBar5.Value.ToString();
        }

        /// <summary>
        /// M�thode pour syncroniser les trackBars de min lors d'un scroll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            int totalSum = 0;
            foreach (var trackBar in trackBars)
            {
                totalSum += trackBar.Value;
            }

            int newMaxValue = trackBar1.Value - totalSum;
            foreach (var trackBar in trackBars)
            {
                trackBar.Maximum = newMaxValue + trackBar.Value;
            }
            label7.Text = trackBar2.Value.ToString();
            label8.Text = trackBar3.Value.ToString();
            label9.Text = trackBar4.Value.ToString();
            label10.Text = trackBar5.Value.ToString();
        }

        /// <summary>
        /// M�thode pour ouvrir le form de settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void param�treToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (settingsForm == null)
            {
                // Si elle n'existe pas, cr�e une nouvelle instance en passant les informations de connexion
                settingsForm = new SettingsForm(fileName, fileDirectory, defaultCarSpeciaux);
            }

            // Affiche la fen�tre de liste des tables en mode dialogue
            settingsForm.ShowDialog();
        }
        /// <summary>
        /// M�thode pour charger les valeurs du ficher settings
        /// </summary>
        private void LoadSettingsFromFile()
        {
            try
            {
                string filePath = "settings";

                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(':');
                            if (parts.Length == 2)
                            {
                                string key = parts[0].Trim();
                                string value = parts[1].Trim();

                                switch (key)
                                {
                                    case "File Name":
                                        fileName = value;
                                        break;
                                    case "File Directory":
                                        // Je ne comprend pas pourquoi. Je n'arrive pas a prendre la valeur dans mon ficher settings
                                        fileDirectory = value;
                                        break;
                                    case "Default Caractere Speciaux":
                                        defaultCarSpeciaux = value;
                                        break;
                                }
                            }
                        }
                    }
                    // MessageBox.Show("Settings loader avec succes!");
                }
                else { MessageBox.Show("Fichier settings non trouver."); }
            }
            catch (Exception ex) { MessageBox.Show($"Erreur lors du load des settings: {ex.Message}"); }
        }

        /// <summary>
        /// Methode pour verifier la securiter du mot de passe
        /// </summary>
        private void VerifyPassword()
        {
            if (textBoxMotDePasse.Text != string.Empty)
            {
                Result result = Zxcvbn.Core.EvaluatePassword(textBoxMotDePasse.Text);
                switch (result.Score)
                {
                    case 0:
                        label16.Text = $"Le mot de passe est tr�s faible";
                        label16.ForeColor = Color.Red;
                        break;
                    case 1:
                        label16.Text = $"Le mot de passe est faible";
                        label16.ForeColor = Color.Orange;
                        break;
                    case 2:
                        label16.Text = $"Le mot de passe est moyen";
                        label16.ForeColor = Color.Black;
                        break;
                    case 3:
                        label16.Text = $"Le mot de passe est fort";
                        label16.ForeColor = Color.YellowGreen;
                        break;
                    case 4:
                        label16.Text = $"Le mot de passe est tr�s fort";
                        label16.ForeColor = Color.Green;
                        break;
                }
            }
            else { label16.Text = "Le mot de passe est tr�s faible ou n'existe pas"; label16.ForeColor = Color.Red; }
        }

        private void textBoxMotDePasse_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerifyPassword();
        }

        private void checkBoxMaj_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMaj.Checked)
            {
                trackBar3.Enabled = true;
            }
            else { trackBar3.Enabled = false; trackBar3.Value = 0; label8.Text = trackBar3.Value.ToString(); InitializeTrackBars(); }
        }

        private void checkBoxChiffres_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxChiffres.Checked)
            {
                trackBar4.Enabled = true;
            }
            else { trackBar4.Enabled = false; trackBar4.Value = 0; label9.Text = trackBar4.Value.ToString(); InitializeTrackBars(); }
        }
    }
}