namespace WindowsFormsApp
{
    partial class FavouritePlayers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavouritePlayers));
            this.lblFavPlayers = new System.Windows.Forms.Label();
            this.lblAllPlayers = new System.Windows.Forms.Label();
            this.btnSavePlayers = new System.Windows.Forms.Button();
            this.flpFavPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAllPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblFavPlayers
            // 
            this.lblFavPlayers.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblFavPlayers, "lblFavPlayers");
            this.lblFavPlayers.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblFavPlayers.Name = "lblFavPlayers";
            // 
            // lblAllPlayers
            // 
            this.lblAllPlayers.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblAllPlayers, "lblAllPlayers");
            this.lblAllPlayers.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAllPlayers.Name = "lblAllPlayers";
            // 
            // btnSavePlayers
            // 
            this.btnSavePlayers.BackgroundImage = global::WindowsFormsApp.Properties.Resources.football3;
            resources.ApplyResources(this.btnSavePlayers, "btnSavePlayers");
            this.btnSavePlayers.Name = "btnSavePlayers";
            this.btnSavePlayers.UseVisualStyleBackColor = true;
            this.btnSavePlayers.Click += new System.EventHandler(this.btnSavePlayers_Click);
            // 
            // flpFavPlayers
            // 
            this.flpFavPlayers.AllowDrop = true;
            resources.ApplyResources(this.flpFavPlayers, "flpFavPlayers");
            this.flpFavPlayers.Name = "flpFavPlayers";
            this.flpFavPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.FlpFavPlayers_DragDrop);
            this.flpFavPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.FlpFavPlayers_DragEnter);
            // 
            // flpAllPlayers
            // 
            this.flpAllPlayers.AllowDrop = true;
            resources.ApplyResources(this.flpAllPlayers, "flpAllPlayers");
            this.flpAllPlayers.Name = "flpAllPlayers";
            this.flpAllPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.FlpAllPlayers_DragDrop);
            this.flpAllPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.FlpFavPlayers_DragEnter);
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // FavouritePlayers
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp.Properties.Resources.Players1;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.flpAllPlayers);
            this.Controls.Add(this.flpFavPlayers);
            this.Controls.Add(this.btnSavePlayers);
            this.Controls.Add(this.lblAllPlayers);
            this.Controls.Add(this.lblFavPlayers);
            this.Name = "FavouritePlayers";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFavPlayers;
        private System.Windows.Forms.Label lblAllPlayers;
        private System.Windows.Forms.Button btnSavePlayers;
        private System.Windows.Forms.FlowLayoutPanel flpFavPlayers;
        private System.Windows.Forms.FlowLayoutPanel flpAllPlayers;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}