namespace WinFormsApp
{
    partial class PlayerCardControl
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
            this.lblCaptain = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
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
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(0, 55);
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
            this.lblFavourite.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFavourite.Location = new System.Drawing.Point(151, 195);
            this.lblFavourite.Name = "lblFavourite";
            this.lblFavourite.Size = new System.Drawing.Size(49, 55);
            this.lblFavourite.TabIndex = 2;
            this.lblFavourite.Text = "☆";
            this.lblFavourite.Click += new System.EventHandler(this.AddToFavourites_Click);
            // 
            // lblShirtNumber
            // 
            this.lblShirtNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblShirtNumber.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblShirtNumber.Location = new System.Drawing.Point(25, 91);
            this.lblShirtNumber.Name = "lblShirtNumber";
            this.lblShirtNumber.Size = new System.Drawing.Size(151, 93);
            this.lblShirtNumber.TabIndex = 3;
            this.lblShirtNumber.Text = "17";
            this.lblShirtNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblShirtNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayerCardControl_MouseDown);
            // 
            // lblCaptain
            // 
            this.lblCaptain.BackColor = System.Drawing.Color.Transparent;
            this.lblCaptain.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCaptain.Location = new System.Drawing.Point(96, 195);
            this.lblCaptain.Name = "lblCaptain";
            this.lblCaptain.Size = new System.Drawing.Size(49, 55);
            this.lblCaptain.TabIndex = 4;
            this.lblCaptain.Text = "C";
            this.lblCaptain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCaptain.Visible = false;
            this.lblCaptain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayerCardControl_MouseDown);
            // 
            // lblPosition
            // 
            this.lblPosition.BackColor = System.Drawing.Color.Transparent;
            this.lblPosition.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPosition.Location = new System.Drawing.Point(0, 195);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(100, 55);
            this.lblPosition.TabIndex = 5;
            this.lblPosition.Text = "POS";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayerCardControl_MouseDown);
            // 
            // PlayerCardControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WinFormsApp.Properties.Resources._default;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblCaptain);
            this.Controls.Add(this.lblFavourite);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblShirtNumber);
            this.Name = "PlayerCardControl";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Size = new System.Drawing.Size(200, 250);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayerCardControl_MouseDown);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem cmChangePlayersImg;
        private ToolStripMenuItem cmAddToFav;
        private Label lblName;
        private Label lblFavourite;
        private Label lblShirtNumber;
        private Label lblCaptain;
        private Label lblPosition;
    }
}
