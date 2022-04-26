namespace WinFormsApp.UserControls
{
    partial class PlayerGoalsControl
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
            this.imgBall = new System.Windows.Forms.PictureBox();
            this.lblNumberOfGoals = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgBall)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Agency FB", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(0, 75);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(200, 36);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Ime Prezime";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgBall
            // 
            this.imgBall.BackColor = System.Drawing.Color.Transparent;
            this.imgBall.Image = global::WinFormsApp.Properties.Resources.goal;
            this.imgBall.Location = new System.Drawing.Point(91, 156);
            this.imgBall.Name = "imgBall";
            this.imgBall.Size = new System.Drawing.Size(66, 56);
            this.imgBall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBall.TabIndex = 4;
            this.imgBall.TabStop = false;
            // 
            // lblNumberOfGoals
            // 
            this.lblNumberOfGoals.BackColor = System.Drawing.Color.Transparent;
            this.lblNumberOfGoals.Font = new System.Drawing.Font("Agency FB", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNumberOfGoals.Location = new System.Drawing.Point(63, 156);
            this.lblNumberOfGoals.Name = "lblNumberOfGoals";
            this.lblNumberOfGoals.Size = new System.Drawing.Size(27, 55);
            this.lblNumberOfGoals.TabIndex = 5;
            this.lblNumberOfGoals.Text = "1";
            this.lblNumberOfGoals.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PlayerGoalsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WinFormsApp.Properties.Resources.football_shirt;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.lblNumberOfGoals);
            this.Controls.Add(this.imgBall);
            this.Controls.Add(this.lblName);
            this.DoubleBuffered = true;
            this.Name = "PlayerGoalsControl";
            this.Size = new System.Drawing.Size(200, 250);
            ((System.ComponentModel.ISupportInitialize)(this.imgBall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblName;
        private PictureBox imgBall;
        private Label lblNumberOfGoals;
    }
}
