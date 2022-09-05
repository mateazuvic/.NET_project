namespace WindowsFormsApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.cbChampionship = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.lblChampionship = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackColor = System.Drawing.Color.MintCream;
            this.btnSave.BackgroundImage = global::WindowsFormsApp.Properties.Resources.football3;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbLanguage
            // 
            resources.ApplyResources(this.cbLanguage, "cbLanguage");
            this.cbLanguage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbLanguage.DropDownHeight = 100;
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.ForeColor = System.Drawing.Color.Wheat;
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Name = "cbLanguage";
            // 
            // cbChampionship
            // 
            resources.ApplyResources(this.cbChampionship, "cbChampionship");
            this.cbChampionship.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbChampionship.DropDownHeight = 100;
            this.cbChampionship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChampionship.ForeColor = System.Drawing.Color.Wheat;
            this.cbChampionship.FormattingEnabled = true;
            this.cbChampionship.Name = "cbChampionship";
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.BackColor = System.Drawing.Color.Transparent;
            this.lblLanguage.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblLanguage.Name = "lblLanguage";
            // 
            // lblChampionship
            // 
            resources.ApplyResources(this.lblChampionship, "lblChampionship");
            this.lblChampionship.BackColor = System.Drawing.Color.Transparent;
            this.lblChampionship.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblChampionship.Name = "lblChampionship";
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbLanguage);
            this.Controls.Add(this.cbChampionship);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.lblChampionship);
            this.Name = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.ComboBox cbChampionship;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label lblChampionship;
    }
}