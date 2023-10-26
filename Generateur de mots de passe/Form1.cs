using System.Collections;

namespace Generateur_de_mots_de_passe
{
    public partial class Form1 : Form
    {
        private ArrayList passwordsList = new ArrayList();

        private Password pw;

        public Form1()
        {
            InitializeComponent();
            textBoxCaractSpeciaux.Enabled = false;
            buttonSauvgarderPassword.Enabled = true;
            textBoxMotDePasse.ReadOnly = true;
            textBoxMotDePasse.Enabled = true;
            checkBoxAfficher.Enabled = true;
            buttonCopier.Enabled = true;
            textBoxMotDePasse.UseSystemPasswordChar = true;
            buttonModifierPassword.Enabled = true;

            listView1.MultiSelect = false;

            listView1.Columns.Add("Description", 250);
        }

        private void buttonNouveauPassword_Click(object sender, EventArgs e)
        {
            this.pw = new Password();
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
            else { textBoxCaractSpeciaux.Enabled = false; textBoxCaractSpeciaux.Text = string.Empty; }
        }

        private void buttonGenerer_Click(object sender, EventArgs e)
        {
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

            if (textBoxCodeUtilisateur.Text != string.Empty && textBoxTitre.Text != string.Empty && textBoxMotDePasse.Text != string.Empty)
            {
                pw.Description = textBoxTitre.Text;
                pw.UserAccount = textBoxCodeUtilisateur.Text;
                passwordsList.Add(pw);

                ListViewItem item = new ListViewItem(pw.ToString());
                item.Tag = item.Tag = pw;
                listView1.Items.Add(item);
                
                if (listView1.Items.Count > 0)
                {
                    listView1.Items[listView1.Items.Count - 1].Selected = true;
                    listView1.Select();
                }
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
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedListItem = listView1.SelectedItems[0];

                
                if (selectedListItem.Tag is Password selectedPassword)
                {
                    
                }
            }
        }
    }
}