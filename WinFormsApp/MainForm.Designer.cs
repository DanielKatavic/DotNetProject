namespace WinFormsApp
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
            this.flpPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTeamName = new System.Windows.Forms.Label();
            this.flpFavourites = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flpPlayers
            // 
            this.flpPlayers.AutoScroll = true;
            this.flpPlayers.Location = new System.Drawing.Point(12, 109);
            this.flpPlayers.Name = "flpPlayers";
            this.flpPlayers.Size = new System.Drawing.Size(869, 275);
            this.flpPlayers.TabIndex = 0;
            this.flpPlayers.WrapContents = false;
            // 
            // lblTeamName
            // 
            this.lblTeamName.AutoSize = true;
            this.lblTeamName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTeamName.Location = new System.Drawing.Point(347, 58);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(199, 37);
            this.lblTeamName.TabIndex = 1;
            this.lblTeamName.Text = "Germany (DEU)";
            // 
            // flpFavourites
            // 
            this.flpFavourites.AutoScroll = true;
            this.flpFavourites.Location = new System.Drawing.Point(12, 467);
            this.flpFavourites.Name = "flpFavourites";
            this.flpFavourites.Size = new System.Drawing.Size(869, 275);
            this.flpFavourites.TabIndex = 2;
            this.flpFavourites.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(347, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Omiljeni igrači";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 862);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flpFavourites);
            this.Controls.Add(this.lblTeamName);
            this.Controls.Add(this.flpPlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flpPlayers;
        private Label lblTeamName;
        private FlowLayoutPanel flpFavourites;
        private Label label1;
    }
}