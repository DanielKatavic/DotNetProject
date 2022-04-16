namespace WinFormsApp
{
    partial class PlayerCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerCard));
            this.imgPlayer = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblShirtNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // imgPlayer
            // 
            this.imgPlayer.ErrorImage = null;
            this.imgPlayer.Image = ((System.Drawing.Image)(resources.GetObject("imgPlayer.Image")));
            this.imgPlayer.InitialImage = null;
            this.imgPlayer.Location = new System.Drawing.Point(0, 0);
            this.imgPlayer.Name = "imgPlayer";
            this.imgPlayer.Size = new System.Drawing.Size(200, 250);
            this.imgPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgPlayer.TabIndex = 0;
            this.imgPlayer.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.SystemColors.Control;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(3, 68);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(194, 35);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Ime Prezime";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShirtNumber
            // 
            this.lblShirtNumber.BackColor = System.Drawing.SystemColors.Control;
            this.lblShirtNumber.Font = new System.Drawing.Font("Segoe UI", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblShirtNumber.Location = new System.Drawing.Point(45, 112);
            this.lblShirtNumber.Name = "lblShirtNumber";
            this.lblShirtNumber.Size = new System.Drawing.Size(110, 74);
            this.lblShirtNumber.TabIndex = 2;
            this.lblShirtNumber.Text = "7";
            this.lblShirtNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblShirtNumber);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.imgPlayer);
            this.Name = "PlayerCard";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Size = new System.Drawing.Size(200, 250);
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox imgPlayer;
        private Label lblName;
        private Label lblShirtNumber;
    }
}
