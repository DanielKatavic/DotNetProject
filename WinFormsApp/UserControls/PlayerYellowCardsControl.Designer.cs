namespace WinFormsApp.UserControls
{
    partial class PlayerYellowCardControl
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
            this.lblName = new System.Windows.Forms.Label();
            this.imgYellowCard = new System.Windows.Forms.PictureBox();
            this.lblNumberOfCards = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgYellowCard)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(0, 55);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(200, 36);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Ime Prezime";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgYellowCard
            // 
            this.imgYellowCard.BackColor = System.Drawing.Color.Transparent;
            this.imgYellowCard.Image = global::WinFormsApp.Properties.Resources.yellow_card;
            this.imgYellowCard.Location = new System.Drawing.Point(61, 147);
            this.imgYellowCard.Name = "imgYellowCard";
            this.imgYellowCard.Size = new System.Drawing.Size(139, 103);
            this.imgYellowCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgYellowCard.TabIndex = 3;
            this.imgYellowCard.TabStop = false;
            this.imgYellowCard.Visible = false;
            // 
            // lblNumberOfCards
            // 
            this.lblNumberOfCards.BackColor = System.Drawing.Color.Transparent;
            this.lblNumberOfCards.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNumberOfCards.Location = new System.Drawing.Point(73, 172);
            this.lblNumberOfCards.Name = "lblNumberOfCards";
            this.lblNumberOfCards.Size = new System.Drawing.Size(27, 41);
            this.lblNumberOfCards.TabIndex = 4;
            this.lblNumberOfCards.Text = "1";
            this.lblNumberOfCards.Visible = false;
            // 
            // PlayerYellowCardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WinFormsApp.Properties.Resources._default;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.lblNumberOfCards);
            this.Controls.Add(this.imgYellowCard);
            this.Controls.Add(this.lblName);
            this.Name = "PlayerYellowCardControl";
            this.Size = new System.Drawing.Size(200, 250);
            ((System.ComponentModel.ISupportInitialize)(this.imgYellowCard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblName;
        private PictureBox imgYellowCard;
        private Label lblNumberOfCards;
    }
}
