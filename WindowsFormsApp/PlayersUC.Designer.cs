namespace WindowsFormsApp
{
    partial class PlayersUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblPlayersName = new System.Windows.Forms.Label();
            this.lblPlayersNbr = new System.Windows.Forms.Label();
            this.lblPlayersPosition = new System.Windows.Forms.Label();
            this.contextMenuUC = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblCaptain = new System.Windows.Forms.Label();
            this.btnContextMoveToAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnContextMoveToFav = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChangeImage = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.pbStar = new System.Windows.Forms.PictureBox();
            this.contextMenuUC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayersName
            // 
            this.lblPlayersName.Location = new System.Drawing.Point(130, 16);
            this.lblPlayersName.Name = "lblPlayersName";
            this.lblPlayersName.Size = new System.Drawing.Size(227, 22);
            this.lblPlayersName.TabIndex = 0;
            this.lblPlayersName.Text = "label1";
            // 
            // lblPlayersNbr
            // 
            this.lblPlayersNbr.AutoSize = true;
            this.lblPlayersNbr.Location = new System.Drawing.Point(363, 16);
            this.lblPlayersNbr.Name = "lblPlayersNbr";
            this.lblPlayersNbr.Size = new System.Drawing.Size(11, 17);
            this.lblPlayersNbr.TabIndex = 1;
            this.lblPlayersNbr.Text = "l";
            // 
            // lblPlayersPosition
            // 
            this.lblPlayersPosition.Location = new System.Drawing.Point(389, 15);
            this.lblPlayersPosition.Name = "lblPlayersPosition";
            this.lblPlayersPosition.Size = new System.Drawing.Size(77, 23);
            this.lblPlayersPosition.TabIndex = 2;
            this.lblPlayersPosition.Text = "label1";
            // 
            // contextMenuUC
            // 
            this.contextMenuUC.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuUC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnContextMoveToAll,
            this.btnContextMoveToFav});
            this.contextMenuUC.Name = "contextMenuUC";
            this.contextMenuUC.Size = new System.Drawing.Size(210, 56);
            // 
            // lblCaptain
            // 
            this.lblCaptain.AutoSize = true;
            this.lblCaptain.Location = new System.Drawing.Point(472, 16);
            this.lblCaptain.Name = "lblCaptain";
            this.lblCaptain.Size = new System.Drawing.Size(38, 17);
            this.lblCaptain.TabIndex = 5;
            this.lblCaptain.Text = "label";
            // 
            // btnContextMoveToAll
            // 
            this.btnContextMoveToAll.Image = global::WindowsFormsApp.Properties.Resources.group;
            this.btnContextMoveToAll.Name = "btnContextMoveToAll";
            this.btnContextMoveToAll.Size = new System.Drawing.Size(209, 26);
            this.btnContextMoveToAll.Text = "Move to All Players";
            this.btnContextMoveToAll.Click += new System.EventHandler(this.btnContextMoveToAll_Click);
            // 
            // btnContextMoveToFav
            // 
            this.btnContextMoveToFav.Image = global::WindowsFormsApp.Properties.Resources.output_onlinepngtools;
            this.btnContextMoveToFav.Name = "btnContextMoveToFav";
            this.btnContextMoveToFav.Size = new System.Drawing.Size(209, 26);
            this.btnContextMoveToFav.Text = "Move to Favourites";
            this.btnContextMoveToFav.Click += new System.EventHandler(this.btnContextMoveToFav_Click);
            // 
            // btnChangeImage
            // 
            this.btnChangeImage.BackgroundImage = global::WindowsFormsApp.Properties.Resources.plus;
            this.btnChangeImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChangeImage.Location = new System.Drawing.Point(26, 7);
            this.btnChangeImage.Name = "btnChangeImage";
            this.btnChangeImage.Size = new System.Drawing.Size(37, 34);
            this.btnChangeImage.TabIndex = 8;
            this.btnChangeImage.UseVisualStyleBackColor = true;
            this.btnChangeImage.Click += new System.EventHandler(this.btnChangeImage_Click);
            // 
            // pbImage
            // 
            this.pbImage.InitialImage = null;
            this.pbImage.Location = new System.Drawing.Point(69, 5);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(55, 44);
            this.pbImage.TabIndex = 7;
            this.pbImage.TabStop = false;
            // 
            // pbStar
            // 
            this.pbStar.BackgroundImage = global::WindowsFormsApp.Properties.Resources.output_onlinepngtools;
            this.pbStar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbStar.Location = new System.Drawing.Point(553, 5);
            this.pbStar.Name = "pbStar";
            this.pbStar.Size = new System.Drawing.Size(33, 33);
            this.pbStar.TabIndex = 6;
            this.pbStar.TabStop = false;
            this.pbStar.Visible = false;
            // 
            // PlayersUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.contextMenuUC;
            this.Controls.Add(this.btnChangeImage);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.pbStar);
            this.Controls.Add(this.lblCaptain);
            this.Controls.Add(this.lblPlayersPosition);
            this.Controls.Add(this.lblPlayersNbr);
            this.Controls.Add(this.lblPlayersName);
            this.Name = "PlayersUC";
            this.Size = new System.Drawing.Size(589, 52);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayersUC_MouseDown);
            this.contextMenuUC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayersName;
        private System.Windows.Forms.Label lblPlayersNbr;
        private System.Windows.Forms.Label lblPlayersPosition;
        private System.Windows.Forms.ContextMenuStrip contextMenuUC;
        private System.Windows.Forms.ToolStripMenuItem btnContextMoveToAll;
        private System.Windows.Forms.ToolStripMenuItem btnContextMoveToFav;
        private System.Windows.Forms.Label lblCaptain;
        private System.Windows.Forms.PictureBox pbStar;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnChangeImage;
    }
}
