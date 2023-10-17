namespace Generateur_de_mots_de_passe
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewItem listViewItem1 = new ListViewItem("");
            panel1 = new Panel();
            buttonEffacerPassword = new Button();
            buttonSauvgarderPassword = new Button();
            buttonModifierPassword = new Button();
            buttonNouveauPassword = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            checkBoxMaj = new CheckBox();
            checkBoxChiffres = new CheckBox();
            checkBoxCaractSpeciaux = new CheckBox();
            checkBoxAfficher = new CheckBox();
            buttonCopier = new Button();
            buttonGenerer = new Button();
            textBoxTitre = new TextBox();
            textBoxMotDePasse = new TextBox();
            textBoxCodeUtilisateur = new TextBox();
            textBoxCaractSpeciaux = new TextBox();
            panel2 = new Panel();
            PasswordLenghtDisplay = new Label();
            trackBar1 = new TrackBar();
            panel3 = new Panel();
            splitContainer1 = new SplitContainer();
            listView1 = new ListView();
            ColumnTitre = new ColumnHeader();
            columnHeaderCodeUser = new ColumnHeader();
            columnHeaderPassword = new ColumnHeader();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(buttonEffacerPassword);
            panel1.Controls.Add(buttonSauvgarderPassword);
            panel1.Controls.Add(buttonModifierPassword);
            panel1.Controls.Add(buttonNouveauPassword);
            panel1.Location = new Point(-61, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(630, 49);
            panel1.TabIndex = 1;
            // 
            // buttonEffacerPassword
            // 
            buttonEffacerPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonEffacerPassword.Enabled = false;
            buttonEffacerPassword.Location = new Point(545, 12);
            buttonEffacerPassword.Name = "buttonEffacerPassword";
            buttonEffacerPassword.Size = new Size(75, 23);
            buttonEffacerPassword.TabIndex = 3;
            buttonEffacerPassword.Text = "Effacer";
            buttonEffacerPassword.UseVisualStyleBackColor = true;
            // 
            // buttonSauvgarderPassword
            // 
            buttonSauvgarderPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSauvgarderPassword.Enabled = false;
            buttonSauvgarderPassword.Location = new Point(464, 12);
            buttonSauvgarderPassword.Name = "buttonSauvgarderPassword";
            buttonSauvgarderPassword.Size = new Size(75, 23);
            buttonSauvgarderPassword.TabIndex = 2;
            buttonSauvgarderPassword.Text = "Sauvgarder";
            buttonSauvgarderPassword.UseVisualStyleBackColor = true;
            // 
            // buttonModifierPassword
            // 
            buttonModifierPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonModifierPassword.Enabled = false;
            buttonModifierPassword.Location = new Point(383, 12);
            buttonModifierPassword.Name = "buttonModifierPassword";
            buttonModifierPassword.Size = new Size(75, 23);
            buttonModifierPassword.TabIndex = 1;
            buttonModifierPassword.Text = "Modifier";
            buttonModifierPassword.UseVisualStyleBackColor = true;
            // 
            // buttonNouveauPassword
            // 
            buttonNouveauPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonNouveauPassword.Location = new Point(302, 12);
            buttonNouveauPassword.Name = "buttonNouveauPassword";
            buttonNouveauPassword.Size = new Size(75, 23);
            buttonNouveauPassword.TabIndex = 0;
            buttonNouveauPassword.Text = "Nouveau";
            buttonNouveauPassword.UseVisualStyleBackColor = true;
            buttonNouveauPassword.Click += buttonNouveauPassword_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 31);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 2;
            label1.Text = "Titre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 72);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 3;
            label2.Text = "code utilisateur";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 112);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 4;
            label3.Text = "Mot de passe";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 11);
            label4.Name = "label4";
            label4.Size = new Size(126, 15);
            label4.TabIndex = 5;
            label4.Text = "Options du generateur";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 36);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 6;
            label5.Text = "Longueur";
            // 
            // checkBoxMaj
            // 
            checkBoxMaj.AutoSize = true;
            checkBoxMaj.Location = new Point(28, 73);
            checkBoxMaj.Name = "checkBoxMaj";
            checkBoxMaj.Size = new Size(85, 19);
            checkBoxMaj.TabIndex = 7;
            checkBoxMaj.Text = "Majuscules";
            checkBoxMaj.UseVisualStyleBackColor = true;
            // 
            // checkBoxChiffres
            // 
            checkBoxChiffres.AutoSize = true;
            checkBoxChiffres.Location = new Point(28, 108);
            checkBoxChiffres.Name = "checkBoxChiffres";
            checkBoxChiffres.Size = new Size(67, 19);
            checkBoxChiffres.TabIndex = 8;
            checkBoxChiffres.Text = "Chiffres";
            checkBoxChiffres.UseVisualStyleBackColor = true;
            // 
            // checkBoxCaractSpeciaux
            // 
            checkBoxCaractSpeciaux.AutoSize = true;
            checkBoxCaractSpeciaux.Location = new Point(28, 145);
            checkBoxCaractSpeciaux.Name = "checkBoxCaractSpeciaux";
            checkBoxCaractSpeciaux.Size = new Size(130, 19);
            checkBoxCaractSpeciaux.TabIndex = 9;
            checkBoxCaractSpeciaux.Text = "Caracteres speciaux";
            checkBoxCaractSpeciaux.UseVisualStyleBackColor = true;
            checkBoxCaractSpeciaux.CheckedChanged += checkBoxCaractSpeciaux_CheckedChanged;
            // 
            // checkBoxAfficher
            // 
            checkBoxAfficher.AutoSize = true;
            checkBoxAfficher.Enabled = false;
            checkBoxAfficher.Location = new Point(400, 108);
            checkBoxAfficher.Name = "checkBoxAfficher";
            checkBoxAfficher.Size = new Size(68, 19);
            checkBoxAfficher.TabIndex = 10;
            checkBoxAfficher.Text = "Afficher";
            checkBoxAfficher.UseVisualStyleBackColor = true;
            checkBoxAfficher.CheckedChanged += checkBoxAfficher_CheckedChanged;
            // 
            // buttonCopier
            // 
            buttonCopier.Enabled = false;
            buttonCopier.Location = new Point(400, 135);
            buttonCopier.Name = "buttonCopier";
            buttonCopier.Size = new Size(75, 23);
            buttonCopier.TabIndex = 11;
            buttonCopier.Text = "Copier";
            buttonCopier.UseVisualStyleBackColor = true;
            buttonCopier.Click += buttonCopier_Click;
            // 
            // buttonGenerer
            // 
            buttonGenerer.Enabled = false;
            buttonGenerer.Location = new Point(114, 135);
            buttonGenerer.Name = "buttonGenerer";
            buttonGenerer.Size = new Size(75, 23);
            buttonGenerer.TabIndex = 12;
            buttonGenerer.Text = "Generer";
            buttonGenerer.UseVisualStyleBackColor = true;
            // 
            // textBoxTitre
            // 
            textBoxTitre.Enabled = false;
            textBoxTitre.Location = new Point(114, 23);
            textBoxTitre.Name = "textBoxTitre";
            textBoxTitre.Size = new Size(268, 23);
            textBoxTitre.TabIndex = 13;
            // 
            // textBoxMotDePasse
            // 
            textBoxMotDePasse.Enabled = false;
            textBoxMotDePasse.Location = new Point(114, 106);
            textBoxMotDePasse.Name = "textBoxMotDePasse";
            textBoxMotDePasse.Size = new Size(268, 23);
            textBoxMotDePasse.TabIndex = 14;
            // 
            // textBoxCodeUtilisateur
            // 
            textBoxCodeUtilisateur.Enabled = false;
            textBoxCodeUtilisateur.Location = new Point(114, 64);
            textBoxCodeUtilisateur.Name = "textBoxCodeUtilisateur";
            textBoxCodeUtilisateur.Size = new Size(268, 23);
            textBoxCodeUtilisateur.TabIndex = 15;
            // 
            // textBoxCaractSpeciaux
            // 
            textBoxCaractSpeciaux.Location = new Point(164, 143);
            textBoxCaractSpeciaux.Name = "textBoxCaractSpeciaux";
            textBoxCaractSpeciaux.Size = new Size(187, 23);
            textBoxCaractSpeciaux.TabIndex = 16;
            textBoxCaractSpeciaux.KeyPress += textBoxCaractSpeciaux_KeyPress;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.Controls.Add(PasswordLenghtDisplay);
            panel2.Controls.Add(trackBar1);
            panel2.Controls.Add(textBoxCaractSpeciaux);
            panel2.Controls.Add(checkBoxCaractSpeciaux);
            panel2.Controls.Add(checkBoxChiffres);
            panel2.Controls.Add(checkBoxMaj);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(69, 247);
            panel2.Name = "panel2";
            panel2.Size = new Size(359, 177);
            panel2.TabIndex = 17;
            // 
            // PasswordLenghtDisplay
            // 
            PasswordLenghtDisplay.AutoSize = true;
            PasswordLenghtDisplay.Location = new Point(332, 36);
            PasswordLenghtDisplay.Name = "PasswordLenghtDisplay";
            PasswordLenghtDisplay.Size = new Size(19, 15);
            PasswordLenghtDisplay.TabIndex = 18;
            PasswordLenghtDisplay.Text = "12";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(108, 36);
            trackBar1.Maximum = 50;
            trackBar1.Minimum = 6;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(218, 45);
            trackBar1.TabIndex = 17;
            trackBar1.Value = 12;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.Controls.Add(textBoxTitre);
            panel3.Controls.Add(textBoxCodeUtilisateur);
            panel3.Controls.Add(buttonCopier);
            panel3.Controls.Add(textBoxMotDePasse);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(buttonGenerer);
            panel3.Controls.Add(checkBoxAfficher);
            panel3.Location = new Point(15, 61);
            panel3.Name = "panel3";
            panel3.Size = new Size(492, 180);
            panel3.TabIndex = 18;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(panel3);
            splitContainer1.Size = new Size(845, 488);
            splitContainer1.SplitterDistance = 267;
            splitContainer1.TabIndex = 19;
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.Columns.AddRange(new ColumnHeader[] { ColumnTitre, columnHeaderCodeUser, columnHeaderPassword });
            listView1.Items.AddRange(new ListViewItem[] { listViewItem1 });
            listView1.Location = new Point(-1, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(269, 487);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // ColumnTitre
            // 
            ColumnTitre.Text = "Titre";
            // 
            // columnHeaderCodeUser
            // 
            columnHeaderCodeUser.Text = "Code Utilisateur";
            columnHeaderCodeUser.TextAlign = HorizontalAlignment.Center;
            columnHeaderCodeUser.Width = 100;
            // 
            // columnHeaderPassword
            // 
            columnHeaderPassword.Text = "Mot de passe";
            columnHeaderPassword.TextAlign = HorizontalAlignment.Center;
            columnHeaderPassword.Width = 100;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(844, 485);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button buttonEffacerPassword;
        private Button buttonSauvgarderPassword;
        private Button buttonModifierPassword;
        private Button buttonNouveauPassword;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private CheckBox checkBoxMaj;
        private CheckBox checkBoxChiffres;
        private CheckBox checkBoxCaractSpeciaux;
        private CheckBox checkBoxAfficher;
        private Button buttonCopier;
        private Button buttonGenerer;
        private TextBox textBoxTitre;
        private TextBox textBoxMotDePasse;
        private TextBox textBoxCodeUtilisateur;
        private TextBox textBoxCaractSpeciaux;
        private Panel panel2;
        private Panel panel3;
        private Label PasswordLenghtDisplay;
        private TrackBar trackBar1;
        private SplitContainer splitContainer1;
        private ListView listView1;
        private ColumnHeader ColumnTitre;
        private ColumnHeader columnHeaderCodeUser;
        private ColumnHeader columnHeaderPassword;
    }
}