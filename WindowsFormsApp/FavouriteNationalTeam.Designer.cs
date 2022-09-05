namespace WindowsFormsApp
{
    partial class FavouriteNationalTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavouriteNationalTeam));
            this.lbChooseTeam = new System.Windows.Forms.Label();
            this.cbChooseTeam = new System.Windows.Forms.ComboBox();
            this.btnSaveFavTeam = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lbChooseTeam
            // 
            this.lbChooseTeam.BackColor = System.Drawing.Color.Goldenrod;
            this.lbChooseTeam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lbChooseTeam, "lbChooseTeam");
            this.lbChooseTeam.ForeColor = System.Drawing.Color.Moccasin;
            this.lbChooseTeam.Name = "lbChooseTeam";
            // 
            // cbChooseTeam
            // 
            this.cbChooseTeam.BackColor = System.Drawing.Color.Gold;
            this.cbChooseTeam.DropDownHeight = 170;
            this.cbChooseTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbChooseTeam, "cbChooseTeam");
            this.cbChooseTeam.ForeColor = System.Drawing.Color.White;
            this.cbChooseTeam.FormattingEnabled = true;
            this.cbChooseTeam.Name = "cbChooseTeam";
            // 
            // btnSaveFavTeam
            // 
            this.btnSaveFavTeam.BackgroundImage = global::WindowsFormsApp.Properties.Resources.football3;
            resources.ApplyResources(this.btnSaveFavTeam, "btnSaveFavTeam");
            this.btnSaveFavTeam.Name = "btnSaveFavTeam";
            this.btnSaveFavTeam.UseVisualStyleBackColor = true;
            this.btnSaveFavTeam.Click += new System.EventHandler(this.btnSaveFavTeam_Click);
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // FavouriteNationalTeam
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp.Properties.Resources.nationalTeam2;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnSaveFavTeam);
            this.Controls.Add(this.cbChooseTeam);
            this.Controls.Add(this.lbChooseTeam);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FavouriteNationalTeam";
            this.Load += new System.EventHandler(this.FavouriteNationalTeam_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbChooseTeam;
        private System.Windows.Forms.ComboBox cbChooseTeam;
        private System.Windows.Forms.Button btnSaveFavTeam;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}