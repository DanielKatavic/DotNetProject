namespace WinFormsApp.UserControls
{
    partial class PlayerUserControl
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
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmChangePlayersImg = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAddToFav = new System.Windows.Forms.ToolStripMenuItem();
            this.lblName = new System.Windows.Forms.Label();
            this.lblFavourite = new System.Windows.Forms.Label();
            this.lblShirtNumber = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.imgCapitain = new System.Windows.Forms.PictureBox();
            this.ttUserControl = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapitain)).BeginInit();
            this.SuspendLayout();
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
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Agency FB", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(200, 36);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Ime Prezime";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayerCardControl_MouseDown);
            // 
            // lblFavourite
            // 
            this.lblFavourite.BackColor = System.Drawing.Color.Transparent;
            this.lblFavourite.Font = new System.Drawing.Font("Agency FB", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFavourite.Location = new System.Drawing.Point(151, 195);
            this.lblFavourite.Name = "lblFavourite";
            this.lblFavourite.Size = new System.Drawing.Size(49, 55);
            this.lblFavourite.TabIndex = 2;
            this.lblFavourite.Text = "☆";
            this.lblFavourite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFavourite.Click += new System.EventHandler(this.AddToFavourites_Click);
            // 
            // lblShirtNumber
            // 
            this.lblShirtNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblShirtNumber.Font = new System.Drawing.Font("Agency FB", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblShirtNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblShirtNumber.Location = new System.Drawing.Point(45, 79);
            this.lblShirtNumber.Name = "lblShirtNumber";
            this.lblShirtNumber.Size = new System.Drawing.Size(110, 105);
            this.lblShirtNumber.TabIndex = 3;
            this.lblShirtNumber.Text = "17";
            this.lblShirtNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblShirtNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayerCardControl_MouseDown);
            // 
            // lblPosition
            // 
            this.lblPosition.BackColor = System.Drawing.Color.Transparent;
            this.lblPosition.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPosition.Location = new System.Drawing.Point(45, 168);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(110, 55);
            this.lblPosition.TabIndex = 5;
            this.lblPosition.Text = "POS";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayerCardControl_MouseDown);
            // 
            // imgCapitain
            // 
            this.imgCapitain.BackColor = System.Drawing.Color.Transparent;
            this.imgCapitain.Image = global::WinFormsApp.Properties.Resources.captain_band;
            this.imgCapitain.Location = new System.Drawing.Point(0, 195);
            this.imgCapitain.Name = "imgCapitain";
            this.imgCapitain.Size = new System.Drawing.Size(59, 55);
            this.imgCapitain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgCapitain.TabIndex = 6;
            this.imgCapitain.TabStop = false;
            this.imgCapitain.Visible = false;
            // 
            // ttUserControl
            // 
            this.ttUserControl.AutomaticDelay = 200;
            this.ttUserControl.AutoPopDelay = 2000;
            this.ttUserControl.InitialDelay = 200;
            this.ttUserControl.ReshowDelay = 40;
            // 
            // PlayerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::WinFormsApp.Properties.Resources.football_shirt;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.imgCapitain);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblFavourite);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblShirtNumber);
            this.DoubleBuffered = true;
            this.Name = "PlayerUserControl";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Size = new System.Drawing.Size(200, 250);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayerCardControl_MouseDown);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgCapitain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem cmChangePlayersImg;
        private ToolStripMenuItem cmAddToFav;
        private Label lblName;
        private Label lblFavourite;
        private Label lblShirtNumber;
        private Label lblPosition;
        private PictureBox imgCapitain;
        private ToolTip ttUserControl;
    }
}
