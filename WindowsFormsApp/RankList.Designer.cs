namespace WindowsFormsApp
{
    partial class RankList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankList));
            this.flpGoals = new System.Windows.Forms.FlowLayoutPanel();
            this.lbGoals = new System.Windows.Forms.ListBox();
            this.flpYellowCards = new System.Windows.Forms.FlowLayoutPanel();
            this.lbYellowCards = new System.Windows.Forms.ListBox();
            this.flpAttendance = new System.Windows.Forms.FlowLayoutPanel();
            this.lbAttendance = new System.Windows.Forms.ListBox();
            this.lblGoals = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblYellowCards = new System.Windows.Forms.Label();
            this.lblAttendance = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.btnSettings = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.flpGoals.SuspendLayout();
            this.flpYellowCards.SuspendLayout();
            this.flpAttendance.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpGoals
            // 
            this.flpGoals.Controls.Add(this.lbGoals);
            resources.ApplyResources(this.flpGoals, "flpGoals");
            this.flpGoals.Name = "flpGoals";
            // 
            // lbGoals
            // 
            this.lbGoals.FormattingEnabled = true;
            resources.ApplyResources(this.lbGoals, "lbGoals");
            this.lbGoals.Name = "lbGoals";
            // 
            // flpYellowCards
            // 
            this.flpYellowCards.Controls.Add(this.lbYellowCards);
            resources.ApplyResources(this.flpYellowCards, "flpYellowCards");
            this.flpYellowCards.Name = "flpYellowCards";
            // 
            // lbYellowCards
            // 
            this.lbYellowCards.FormattingEnabled = true;
            resources.ApplyResources(this.lbYellowCards, "lbYellowCards");
            this.lbYellowCards.Name = "lbYellowCards";
            // 
            // flpAttendance
            // 
            this.flpAttendance.Controls.Add(this.lbAttendance);
            resources.ApplyResources(this.flpAttendance, "flpAttendance");
            this.flpAttendance.Name = "flpAttendance";
            // 
            // lbAttendance
            // 
            this.lbAttendance.FormattingEnabled = true;
            resources.ApplyResources(this.lbAttendance, "lbAttendance");
            this.lbAttendance.Name = "lbAttendance";
            // 
            // lblGoals
            // 
            resources.ApplyResources(this.lblGoals, "lblGoals");
            this.lblGoals.BackColor = System.Drawing.Color.Transparent;
            this.lblGoals.ForeColor = System.Drawing.Color.White;
            this.lblGoals.Name = "lblGoals";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblYellowCards
            // 
            resources.ApplyResources(this.lblYellowCards, "lblYellowCards");
            this.lblYellowCards.BackColor = System.Drawing.Color.Transparent;
            this.lblYellowCards.ForeColor = System.Drawing.Color.White;
            this.lblYellowCards.Name = "lblYellowCards";
            // 
            // lblAttendance
            // 
            resources.ApplyResources(this.lblAttendance, "lblAttendance");
            this.lblAttendance.BackColor = System.Drawing.Color.Transparent;
            this.lblAttendance.ForeColor = System.Drawing.Color.White;
            this.lblAttendance.Name = "lblAttendance";
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = global::WindowsFormsApp.Properties.Resources.football3;
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // btnSettings
            // 
            this.btnSettings.BackgroundImage = global::WindowsFormsApp.Properties.Resources.settings3;
            resources.ApplyResources(this.btnSettings, "btnSettings");
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // RankList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp.Properties.Resources.teren;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblAttendance);
            this.Controls.Add(this.lblYellowCards);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblGoals);
            this.Controls.Add(this.flpAttendance);
            this.Controls.Add(this.flpYellowCards);
            this.Controls.Add(this.flpGoals);
            this.Name = "RankList";
            this.Load += new System.EventHandler(this.RankList_Load);
            this.flpGoals.ResumeLayout(false);
            this.flpYellowCards.ResumeLayout(false);
            this.flpAttendance.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpGoals;
        private System.Windows.Forms.FlowLayoutPanel flpYellowCards;
        private System.Windows.Forms.FlowLayoutPanel flpAttendance;
        private System.Windows.Forms.Label lblGoals;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblYellowCards;
        private System.Windows.Forms.Label lblAttendance;
        private System.Windows.Forms.ListBox lbGoals;
        private System.Windows.Forms.ListBox lbYellowCards;
        private System.Windows.Forms.ListBox lbAttendance;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}