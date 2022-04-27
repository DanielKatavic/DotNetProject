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
            this.flpGoals = new System.Windows.Forms.FlowLayoutPanel();
            this.flpYellowCards = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.flpMatches = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.hrvatskiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.lblTeamName);
            this.tabPage1.Controls.Add(this.flpFavourites);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.flpPlayers);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(914, 801);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Popis igrača";
            // 
            // lblTeamName
            // 
            this.lblTeamName.Font = new System.Drawing.Font("Agency FB", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTeamName.Location = new System.Drawing.Point(337, 45);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(240, 40);
            this.lblTeamName.TabIndex = 1;
            this.lblTeamName.Text = "Country name";
            this.lblTeamName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpFavourites
            // 
            this.flpFavourites.AllowDrop = true;
            this.flpFavourites.Location = new System.Drawing.Point(3, 454);
            this.flpFavourites.Name = "flpFavourites";
            this.flpFavourites.Size = new System.Drawing.Size(908, 275);
            this.flpFavourites.TabIndex = 2;
            this.flpFavourites.WrapContents = false;
            this.flpFavourites.DragDrop += new System.Windows.Forms.DragEventHandler(this.Players_DragDrop);
            this.flpFavourites.DragEnter += new System.Windows.Forms.DragEventHandler(this.Players_DragEnter);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Agency FB", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(337, 394);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Favourite players";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpPlayers
            // 
            this.flpPlayers.AllowDrop = true;
            this.flpPlayers.AutoScroll = true;
            this.flpPlayers.Location = new System.Drawing.Point(3, 97);
            this.flpPlayers.Name = "flpPlayers";
            this.flpPlayers.Size = new System.Drawing.Size(908, 275);
            this.flpPlayers.TabIndex = 0;
            this.flpPlayers.WrapContents = false;
            this.flpPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.Players_DragDrop);
            this.flpPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.Players_DragEnter);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.flpGoals);
            this.tabPage2.Controls.Add(this.flpYellowCards);
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(914, 801);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sortirani igrači";
            this.tabPage2.Enter += new System.EventHandler(this.SecondPage_Enter);
            // 
            // flpGoals
            // 
            this.flpGoals.AllowDrop = true;
            this.flpGoals.AutoScroll = true;
            this.flpGoals.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpGoals.Location = new System.Drawing.Point(634, 6);
            this.flpGoals.Name = "flpGoals";
            this.flpGoals.Size = new System.Drawing.Size(272, 787);
            this.flpGoals.TabIndex = 2;
            this.flpGoals.WrapContents = false;
            // 
            // flpYellowCards
            // 
            this.flpYellowCards.AllowDrop = true;
            this.flpYellowCards.AutoScroll = true;
            this.flpYellowCards.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpYellowCards.Location = new System.Drawing.Point(8, 6);
            this.flpYellowCards.Name = "flpYellowCards";
            this.flpYellowCards.Size = new System.Drawing.Size(272, 787);
            this.flpYellowCards.TabIndex = 1;
            this.flpYellowCards.WrapContents = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(0, 33);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(922, 829);
            this.tabControl.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.flpMatches);
            this.tabPage3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(914, 801);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Sve utakmice";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Enter += new System.EventHandler(this.ThirdPage_Enter);
            // 
            // flpMatches
            // 
            this.flpMatches.AutoScroll = true;
            this.flpMatches.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMatches.Location = new System.Drawing.Point(8, 3);
            this.flpMatches.Name = "flpMatches";
            this.flpMatches.Size = new System.Drawing.Size(898, 790);
            this.flpMatches.TabIndex = 0;
            this.flpMatches.WrapContents = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(922, 30);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(30, 30);
            this.toolStripButton1.Text = "Postavke";
            this.toolStripButton1.Click += new System.EventHandler(this.Settings_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hrvatskiToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 27);
            this.toolStripDropDownButton1.Text = "Promijeni jezik";
            // 
            // hrvatskiToolStripMenuItem
            // 
            this.hrvatskiToolStripMenuItem.Image = global::WinFormsApp.Properties.FlagsResources.CRO;
            this.hrvatskiToolStripMenuItem.Name = "hrvatskiToolStripMenuItem";
            this.hrvatskiToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.hrvatskiToolStripMenuItem.Text = "Hrvatski";
            this.hrvatskiToolStripMenuItem.Click += new System.EventHandler(this.ChangeLangToCro_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Image = global::WinFormsApp.Properties.FlagsResources.ENG;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.ChangeLangToEng_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 862);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

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
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem hrvatskiToolStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
    }
}