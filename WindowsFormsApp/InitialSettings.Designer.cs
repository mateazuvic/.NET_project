namespace WindowsFormsApp
{
    partial class InitialSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialSettings));
            this.lblChooseChampionship = new System.Windows.Forms.Label();
            this.lblChooseLanguage = new System.Windows.Forms.Label();
            this.cbChooseChampionship = new System.Windows.Forms.ComboBox();
            this.cbChooseLanguage = new System.Windows.Forms.ComboBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblChooseChampionship
            // 
            resources.ApplyResources(this.lblChooseChampionship, "lblChooseChampionship");
            this.lblChooseChampionship.BackColor = System.Drawing.Color.DarkGreen;
            this.lblChooseChampionship.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblChooseChampionship.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblChooseChampionship.Name = "lblChooseChampionship";
            // 
            // lblChooseLanguage
            // 
            resources.ApplyResources(this.lblChooseLanguage, "lblChooseLanguage");
            this.lblChooseLanguage.BackColor = System.Drawing.Color.DarkGreen;
            this.lblChooseLanguage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblChooseLanguage.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblChooseLanguage.Name = "lblChooseLanguage";
            // 
            // cbChooseChampionship
            // 
            resources.ApplyResources(this.cbChooseChampionship, "cbChooseChampionship");
            this.cbChooseChampionship.BackColor = System.Drawing.Color.YellowGreen;
            this.cbChooseChampionship.DropDownHeight = 100;
            this.cbChooseChampionship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChooseChampionship.ForeColor = System.Drawing.Color.DarkGreen;
            this.cbChooseChampionship.FormattingEnabled = true;
            this.cbChooseChampionship.Name = "cbChooseChampionship";
            // 
            // cbChooseLanguage
            // 
            resources.ApplyResources(this.cbChooseLanguage, "cbChooseLanguage");
            this.cbChooseLanguage.BackColor = System.Drawing.Color.YellowGreen;
            this.cbChooseLanguage.DropDownHeight = 100;
            this.cbChooseLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChooseLanguage.ForeColor = System.Drawing.Color.DarkGreen;
            this.cbChooseLanguage.FormattingEnabled = true;
            this.cbChooseLanguage.Name = "cbChooseLanguage";
            // 
            // btnSaveSettings
            // 
            resources.ApplyResources(this.btnSaveSettings, "btnSaveSettings");
            this.btnSaveSettings.BackColor = System.Drawing.Color.MintCream;
            this.btnSaveSettings.BackgroundImage = global::WindowsFormsApp.Properties.Resources.football3;
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // InitialSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp.Properties.Resources.football2;
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.cbChooseLanguage);
            this.Controls.Add(this.cbChooseChampionship);
            this.Controls.Add(this.lblChooseLanguage);
            this.Controls.Add(this.lblChooseChampionship);
            this.Name = "InitialSettings";
            this.Load += new System.EventHandler(this.InitialSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChooseChampionship;
        private System.Windows.Forms.Label lblChooseLanguage;
        private System.Windows.Forms.ComboBox cbChooseChampionship;
        private System.Windows.Forms.ComboBox cbChooseLanguage;
        private System.Windows.Forms.Button btnSaveSettings;
    }
}

