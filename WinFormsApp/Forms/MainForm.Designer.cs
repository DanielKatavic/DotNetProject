namespace WinFormsApp.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblTeamName = new System.Windows.Forms.Label();
            this.flpFavourites = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flpPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flpGoals = new System.Windows.Forms.FlowLayoutPanel();
            this.flpYellowCards = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.flpMatches = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.hrvatskiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.printPlayersWithYellowCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPlayersWithGoalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printDocYellowCards = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocGoals = new System.Drawing.Printing.PrintDocument();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.lblTeamName);
            this.tabPage1.Controls.Add(this.flpFavourites);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.flpPlayers);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // lblTeamName
            // 
            resources.ApplyResources(this.lblTeamName, "lblTeamName");
            this.lblTeamName.Name = "lblTeamName";
            // 
            // flpFavourites
            // 
            this.flpFavourites.AllowDrop = true;
            resources.ApplyResources(this.flpFavourites, "flpFavourites");
            this.flpFavourites.Name = "flpFavourites";
            this.flpFavourites.DragDrop += new System.Windows.Forms.DragEventHandler(this.Players_DragDrop);
            this.flpFavourites.DragEnter += new System.Windows.Forms.DragEventHandler(this.Players_DragEnter);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Name = "label1";
            // 
            // flpPlayers
            // 
            this.flpPlayers.AllowDrop = true;
            resources.ApplyResources(this.flpPlayers, "flpPlayers");
            this.flpPlayers.Name = "flpPlayers";
            this.flpPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.Players_DragDrop);
            this.flpPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.Players_DragEnter);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.flpGoals);
            this.tabPage2.Controls.Add(this.flpYellowCards);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Enter += new System.EventHandler(this.SecondPage_Enter);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // flpGoals
            // 
            this.flpGoals.AllowDrop = true;
            resources.ApplyResources(this.flpGoals, "flpGoals");
            this.flpGoals.Name = "flpGoals";
            // 
            // flpYellowCards
            // 
            this.flpYellowCards.AllowDrop = true;
            resources.ApplyResources(this.flpYellowCards, "flpYellowCards");
            this.flpYellowCards.Name = "flpYellowCards";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.flpMatches);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Enter += new System.EventHandler(this.ThirdPage_Enter);
            // 
            // flpMatches
            // 
            resources.ApplyResources(this.flpMatches, "flpMatches");
            this.flpMatches.Name = "flpMatches";
            // 
            // toolStrip
            // 
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripSeparator2,
            this.toolStripDropDownButton2});
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // toolStripButton1
            // 
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.SettingsIcon_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hrvatskiToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::WinFormsApp.Properties.Resources.translate;
            resources.ApplyResources(this.toolStripDropDownButton1, "toolStripDropDownButton1");
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            // 
            // hrvatskiToolStripMenuItem
            // 
            this.hrvatskiToolStripMenuItem.Image = global::WinFormsApp.Properties.FlagsResources.CRO;
            this.hrvatskiToolStripMenuItem.Name = "hrvatskiToolStripMenuItem";
            resources.ApplyResources(this.hrvatskiToolStripMenuItem, "hrvatskiToolStripMenuItem");
            this.hrvatskiToolStripMenuItem.Click += new System.EventHandler(this.ChangeLangToCro_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Image = global::WinFormsApp.Properties.FlagsResources.ENG;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.ChangeLangToEng_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printPlayersWithYellowCardsToolStripMenuItem,
            this.printPlayersWithGoalsToolStripMenuItem});
            this.toolStripDropDownButton2.Image = global::WinFormsApp.Properties.Resources.printing;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            resources.ApplyResources(this.toolStripDropDownButton2, "toolStripDropDownButton2");
            // 
            // printPlayersWithYellowCardsToolStripMenuItem
            // 
            this.printPlayersWithYellowCardsToolStripMenuItem.Name = "printPlayersWithYellowCardsToolStripMenuItem";
            resources.ApplyResources(this.printPlayersWithYellowCardsToolStripMenuItem, "printPlayersWithYellowCardsToolStripMenuItem");
            this.printPlayersWithYellowCardsToolStripMenuItem.Click += new System.EventHandler(this.PrintPlayersWithYellowCards_Click);
            // 
            // printPlayersWithGoalsToolStripMenuItem
            // 
            this.printPlayersWithGoalsToolStripMenuItem.Name = "printPlayersWithGoalsToolStripMenuItem";
            resources.ApplyResources(this.printPlayersWithGoalsToolStripMenuItem, "printPlayersWithGoalsToolStripMenuItem");
            this.printPlayersWithGoalsToolStripMenuItem.Click += new System.EventHandler(this.PrintPlayersWithGoals_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.lblProgress});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // lblProgress
            // 
            this.lblProgress.Name = "lblProgress";
            resources.ApplyResources(this.lblProgress, "lblProgress");
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printDocYellowCards;
            this.printDialog.UseEXDialog = true;
            // 
            // printDocYellowCards
            // 
            this.printDocYellowCards.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.YellowCards_PrintPage);
            // 
            // printPreviewDialog
            // 
            resources.ApplyResources(this.printPreviewDialog, "printPreviewDialog");
            this.printPreviewDialog.Document = this.printDocYellowCards;
            this.printPreviewDialog.Name = "printPreviewDialog";
            // 
            // printDocGoals
            // 
            this.printDocGoals.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.Goals_PrintPage);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabPage tabPage1;
        private Label lblTeamName;
        private FlowLayoutPanel flpFavourites;
        private Label label1;
        private FlowLayoutPanel flpPlayers;
        private TabPage tabPage2;
        private TabControl tabControl;
        private FlowLayoutPanel flpYellowCards;
        private FlowLayoutPanel flpGoals;
        private TabPage tabPage3;
        private FlowLayoutPanel flpMatches;
        private ToolStrip toolStrip;
        private ToolStripButton toolStripButton1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem hrvatskiToolStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
        private Label label3;
        private Label label2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private StatusStrip statusStrip;
        private ToolStripProgressBar progressBar;
        private ToolStripStatusLabel lblProgress;
        private PrintDialog printDialog;
        private System.Drawing.Printing.PrintDocument printDocYellowCards;
        private PrintPreviewDialog printPreviewDialog;
        private ToolStripDropDownButton toolStripDropDownButton2;
        private ToolStripMenuItem printPlayersWithYellowCardsToolStripMenuItem;
        private ToolStripMenuItem printPlayersWithGoalsToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocGoals;
    }
}