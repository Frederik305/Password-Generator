namespace Generateur_de_mots_de_passe
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 59);
            label1.Name = "label1";
            label1.Size = new Size(173, 15);
            label1.TabIndex = 0;
            label1.Text = "Nom du ficher de mot de passe";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(279, 56);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(298, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(279, 114);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(298, 23);
            textBox2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 117);
            label2.Name = "label2";
            label2.Size = new Size(222, 15);
            label2.TabIndex = 3;
            label2.Text = "Emplacement du fichier de mot de passe";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(105, 171);
            label3.Name = "label3";
            label3.Size = new Size(168, 15);
            label3.TabIndex = 4;
            label3.Text = "Caractères spéciaux par défaut";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(279, 168);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(298, 23);
            textBox3.TabIndex = 5;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // button1
            // 
            button1.Location = new Point(593, 102);
            button1.Name = "button1";
            button1.Size = new Size(98, 44);
            button1.TabIndex = 6;
            button1.Text = "Navigateur de fichier";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(309, 215);
            button2.Name = "button2";
            button2.Size = new Size(220, 45);
            button2.TabIndex = 7;
            button2.Text = "Sauvegarder";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(718, 297);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            MinimumSize = new Size(734, 336);
            Name = "SettingsForm";
            Text = "Settings";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private TextBox textBox3;
        private Button button1;
        private Button button2;
    }
}