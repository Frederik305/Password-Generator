﻿namespace Generateur_de_mots_de_passe
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            label6 = new Label();
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
            bindingSource1 = new BindingSource(components);
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
            listBox1 = new ListBox();
            panel3 = new Panel();
            labelNote = new Label();
            textBoxNote = new TextBox();
            labelURL = new Label();
            textBoxURL = new TextBox();
            splitContainer1 = new SplitContainer();
            labelMessage = new Label();
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(buttonEffacerPassword);
            panel1.Controls.Add(buttonSauvgarderPassword);
            panel1.Controls.Add(buttonModifierPassword);
            panel1.Controls.Add(buttonNouveauPassword);
            panel1.Location = new Point(53, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(554, 80);
            panel1.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 56);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 4;
            label6.Text = "label6";
            // 
            // buttonEffacerPassword
            // 
            buttonEffacerPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonEffacerPassword.Enabled = false;
            buttonEffacerPassword.Location = new Point(417, 21);
            buttonEffacerPassword.Name = "buttonEffacerPassword";
            buttonEffacerPassword.Size = new Size(75, 23);
            buttonEffacerPassword.TabIndex = 3;
            buttonEffacerPassword.Text = "Effacer";
            buttonEffacerPassword.UseVisualStyleBackColor = true;
            buttonEffacerPassword.Click += buttonEffacerPassword_Click;
            // 
            // buttonSauvgarderPassword
            // 
            buttonSauvgarderPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSauvgarderPassword.Enabled = false;
            buttonSauvgarderPassword.Location = new Point(277, 21);
            buttonSauvgarderPassword.Name = "buttonSauvgarderPassword";
            buttonSauvgarderPassword.Size = new Size(83, 23);
            buttonSauvgarderPassword.TabIndex = 2;
            buttonSauvgarderPassword.Text = "Sauvegarder";
            buttonSauvgarderPassword.UseVisualStyleBackColor = true;
            buttonSauvgarderPassword.Click += buttonSauvgarderPassword_Click;
            // 
            // buttonModifierPassword
            // 
            buttonModifierPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonModifierPassword.Enabled = false;
            buttonModifierPassword.Location = new Point(150, 21);
            buttonModifierPassword.Name = "buttonModifierPassword";
            buttonModifierPassword.Size = new Size(75, 23);
            buttonModifierPassword.TabIndex = 1;
            buttonModifierPassword.Text = "Modifier";
            buttonModifierPassword.UseVisualStyleBackColor = true;
            buttonModifierPassword.Click += buttonModifierPassword_Click;
            // 
            // buttonNouveauPassword
            // 
            buttonNouveauPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonNouveauPassword.Location = new Point(30, 21);
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
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "Titre *";
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
            label3.Location = new Point(20, 203);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 4;
            label3.Text = "Mot de passe *";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 11);
            label4.Name = "label4";
            label4.Size = new Size(126, 15);
            label4.TabIndex = 5;
            label4.Text = "Options du générateur";
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
            checkBoxMaj.DataBindings.Add(new Binding("CheckState", bindingSource1, "HasUppercaseCharacters", true));
            checkBoxMaj.Location = new Point(28, 73);
            checkBoxMaj.Name = "checkBoxMaj";
            checkBoxMaj.Size = new Size(85, 19);
            checkBoxMaj.TabIndex = 7;
            checkBoxMaj.Text = "Majuscules";
            checkBoxMaj.UseVisualStyleBackColor = true;
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(Password);
            // 
            // checkBoxChiffres
            // 
            checkBoxChiffres.AutoSize = true;
            checkBoxChiffres.DataBindings.Add(new Binding("CheckState", bindingSource1, "HasDigitCharacters", true));
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
            checkBoxCaractSpeciaux.DataBindings.Add(new Binding("CheckState", bindingSource1, "HasSpecialCharacters", true));
            checkBoxCaractSpeciaux.Location = new Point(28, 145);
            checkBoxCaractSpeciaux.Name = "checkBoxCaractSpeciaux";
            checkBoxCaractSpeciaux.Size = new Size(130, 19);
            checkBoxCaractSpeciaux.TabIndex = 9;
            checkBoxCaractSpeciaux.Text = "Caractères spéciaux";
            checkBoxCaractSpeciaux.UseVisualStyleBackColor = true;
            checkBoxCaractSpeciaux.CheckedChanged += checkBoxCaractSpeciaux_CheckedChanged;
            // 
            // checkBoxAfficher
            // 
            checkBoxAfficher.AutoSize = true;
            checkBoxAfficher.Enabled = false;
            checkBoxAfficher.Location = new Point(400, 199);
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
            buttonCopier.Location = new Point(400, 226);
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
            buttonGenerer.Location = new Point(114, 226);
            buttonGenerer.Name = "buttonGenerer";
            buttonGenerer.Size = new Size(75, 23);
            buttonGenerer.TabIndex = 12;
            buttonGenerer.Text = "Generer";
            buttonGenerer.UseVisualStyleBackColor = true;
            buttonGenerer.Click += buttonGenerer_Click;
            // 
            // textBoxTitre
            // 
            textBoxTitre.DataBindings.Add(new Binding("Text", bindingSource1, "Description", true));
            textBoxTitre.Enabled = false;
            textBoxTitre.Location = new Point(114, 23);
            textBoxTitre.Name = "textBoxTitre";
            textBoxTitre.Size = new Size(268, 23);
            textBoxTitre.TabIndex = 13;
            // 
            // textBoxMotDePasse
            // 
            textBoxMotDePasse.DataBindings.Add(new Binding("Text", bindingSource1, "PasswordValue", true));
            textBoxMotDePasse.Enabled = false;
            textBoxMotDePasse.Location = new Point(114, 197);
            textBoxMotDePasse.Name = "textBoxMotDePasse";
            textBoxMotDePasse.Size = new Size(268, 23);
            textBoxMotDePasse.TabIndex = 14;
            // 
            // textBoxCodeUtilisateur
            // 
            textBoxCodeUtilisateur.DataBindings.Add(new Binding("Text", bindingSource1, "UserAccount", true));
            textBoxCodeUtilisateur.Enabled = false;
            textBoxCodeUtilisateur.Location = new Point(114, 64);
            textBoxCodeUtilisateur.Name = "textBoxCodeUtilisateur";
            textBoxCodeUtilisateur.Size = new Size(268, 23);
            textBoxCodeUtilisateur.TabIndex = 15;
            // 
            // textBoxCaractSpeciaux
            // 
            textBoxCaractSpeciaux.DataBindings.Add(new Binding("Text", bindingSource1, "SpecialCharacters", true));
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
            panel2.Location = new Point(131, 372);
            panel2.Name = "panel2";
            panel2.Size = new Size(379, 177);
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
            trackBar1.DataBindings.Add(new Binding("Value", bindingSource1, "Length", true));
            trackBar1.Location = new Point(108, 36);
            trackBar1.Maximum = 50;
            trackBar1.Minimum = 6;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(218, 45);
            trackBar1.TabIndex = 17;
            trackBar1.Value = 12;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.DataSource = bindingSource1;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(-1, -1);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(305, 634);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.Controls.Add(labelNote);
            panel3.Controls.Add(textBoxNote);
            panel3.Controls.Add(labelURL);
            panel3.Controls.Add(textBoxURL);
            panel3.Controls.Add(textBoxTitre);
            panel3.Controls.Add(textBoxCodeUtilisateur);
            panel3.Controls.Add(buttonCopier);
            panel3.Controls.Add(textBoxMotDePasse);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(buttonGenerer);
            panel3.Controls.Add(checkBoxAfficher);
            panel3.Location = new Point(86, 86);
            panel3.Name = "panel3";
            panel3.Size = new Size(492, 280);
            panel3.TabIndex = 18;
            // 
            // labelNote
            // 
            labelNote.AutoSize = true;
            labelNote.Location = new Point(65, 162);
            labelNote.Name = "labelNote";
            labelNote.Size = new Size(33, 15);
            labelNote.TabIndex = 19;
            labelNote.Text = "Note";
            // 
            // textBoxNote
            // 
            textBoxNote.AcceptsReturn = true;
            textBoxNote.AcceptsTab = true;
            textBoxNote.DataBindings.Add(new Binding("Text", bindingSource1, "Note", true));
            textBoxNote.Enabled = false;
            textBoxNote.Location = new Point(114, 140);
            textBoxNote.Multiline = true;
            textBoxNote.Name = "textBoxNote";
            textBoxNote.ScrollBars = ScrollBars.Vertical;
            textBoxNote.Size = new Size(268, 51);
            textBoxNote.TabIndex = 18;
            // 
            // labelURL
            // 
            labelURL.AutoSize = true;
            labelURL.Location = new Point(65, 119);
            labelURL.Name = "labelURL";
            labelURL.Size = new Size(28, 15);
            labelURL.TabIndex = 17;
            labelURL.Text = "URL";
            // 
            // textBoxURL
            // 
            textBoxURL.DataBindings.Add(new Binding("Text", bindingSource1, "URL", true));
            textBoxURL.Enabled = false;
            textBoxURL.Location = new Point(114, 111);
            textBoxURL.Name = "textBoxURL";
            textBoxURL.Size = new Size(268, 23);
            textBoxURL.TabIndex = 16;
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
            splitContainer1.Panel1.Controls.Add(listBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(labelMessage);
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(panel3);
            splitContainer1.Size = new Size(947, 638);
            splitContainer1.SplitterDistance = 298;
            splitContainer1.TabIndex = 19;
            // 
            // labelMessage
            // 
            labelMessage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelMessage.AutoSize = true;
            labelMessage.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            labelMessage.ForeColor = SystemColors.ControlText;
            labelMessage.Location = new Point(64, 589);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(0, 25);
            labelMessage.TabIndex = 19;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 635);
            Controls.Add(splitContainer1);
            MinimumSize = new Size(950, 524);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
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
        private ListBox listBox1;
        private Label label6;
        private TextBox textBoxURL;
        private Label labelURL;
        private Label labelNote;
        private TextBox textBoxNote;
        private ErrorProvider errorProvider1;
        private Label labelMessage;
        private BindingSource bindingSource1;
    }
}