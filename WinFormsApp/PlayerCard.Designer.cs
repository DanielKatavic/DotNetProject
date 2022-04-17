namespace WinFormsApp
{
    partial class PlayerCardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerCardForm));
            this.lblName = new System.Windows.Forms.Label();
            this.lblShirtNumber = new System.Windows.Forms.Label();
            this.lblFavourite = new System.Windows.Forms.Label();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.lblCaptain = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmChangePlayersImg = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAddToFav = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlImage.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(2, 66);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(194, 35);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Ime Prezime";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShirtNumber
            // 
            this.lblShirtNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblShirtNumber.Font = new System.Drawing.Font("Segoe UI", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblShirtNumber.Location = new System.Drawing.Point(28, 101);
            this.lblShirtNumber.Name = "lblShirtNumber";
            this.lblShirtNumber.Size = new System.Drawing.Size(141, 105);
            this.lblShirtNumber.TabIndex = 2;
            this.lblShirtNumber.Text = "7";
            this.lblShirtNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFavourite
            // 
            this.lblFavourite.AutoSize = true;
            this.lblFavourite.BackColor = System.Drawing.Color.Transparent;
            this.lblFavourite.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFavourite.Location = new System.Drawing.Point(148, 204);
            this.lblFavourite.Margin = new System.Windows.Forms.Padding(0);
            this.lblFavourite.Name = "lblFavourite";
            this.lblFavourite.Size = new System.Drawing.Size(48, 46);
            this.lblFavourite.TabIndex = 3;
            this.lblFavourite.Text = "☆";
            this.lblFavourite.Click += new System.EventHandler(this.AddToFavourites_Click);
            // 
            // pnlImage
            // 
            this.pnlImage.BackColor = System.Drawing.Color.Transparent;
            this.pnlImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlImage.BackgroundImage")));
            this.pnlImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlImage.Controls.Add(this.lblCaptain);
            this.pnlImage.Controls.Add(this.lblName);
            this.pnlImage.Controls.Add(this.lblShirtNumber);
            this.pnlImage.Controls.Add(this.lblFavourite);
            this.pnlImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImage.Location = new System.Drawing.Point(2, 0);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(196, 250);
            this.pnlImage.TabIndex = 4;
            // 
            // lblCaptain
            // 
            this.lblCaptain.AutoSize = true;
            this.lblCaptain.BackColor = System.Drawing.Color.Transparent;
            this.lblCaptain.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCaptain.ForeColor = System.Drawing.Color.Red;
            this.lblCaptain.Location = new System.Drawing.Point(114, 210);
            this.lblCaptain.Margin = new System.Windows.Forms.Padding(0);
            this.lblCaptain.Name = "lblCaptain";
            this.lblCaptain.Size = new System.Drawing.Size(34, 37);
            this.lblCaptain.TabIndex = 4;
            this.lblCaptain.Text = "C";
            this.lblCaptain.Visible = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmChangePlayersImg,
            this.cmAddToFav});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(188, 48);
            // 
            // cmChangePlayersImg
            // 
            this.cmChangePlayersImg.Name = "cmChangePlayersImg";
            this.cmChangePlayersImg.Size = new System.Drawing.Size(187, 22);
            this.cmChangePlayersImg.Text = "Promijeni sliku igrača";
            this.cmChangePlayersImg.Click += new System.EventHandler(this.ChangePlayersImage_Click);
            // 
            // cmAddToFav
            // 
            this.cmAddToFav.Name = "cmAddToFav";
            this.cmAddToFav.Size = new System.Drawing.Size(187, 22);
            this.cmAddToFav.Text = "Dodaj u favorite";
            this.cmAddToFav.Click += new System.EventHandler(this.AddToFavourites_Click);
            // 
            // PlayerCardForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.pnlImage);
            this.Name = "PlayerCardForm";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Size = new System.Drawing.Size(200, 250);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayerCardForm_MouseDown);
            this.pnlImage.ResumeLayout(false);
            this.pnlImage.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Label lblName;
        private Label lblShirtNumber;
        private Label lblFavourite;
        private Panel pnlImage;
        private Label lblCaptain;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem cmChangePlayersImg;
        private ToolStripMenuItem cmAddToFav;
    }
}
