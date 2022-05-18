using Utility.Models;

namespace WinFormsApp.Forms
{
    partial class WelcomeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            this.label1 = new System.Windows.Forms.Label();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAccess = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.teamBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.teamBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbGender
            // 
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbGender, "cbGender");
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Name = "cbGender";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cbLanguage
            // 
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbLanguage, "cbLanguage");
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.SelectionChangeCommitted += new System.EventHandler(this.LanguageChanged);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.SystemColors.Control;
            this.btnContinue.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnContinue, "btnContinue");
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.BtnContinue_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cbAccess
            // 
            this.cbAccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbAccess, "cbAccess");
            this.cbAccess.FormattingEnabled = true;
            this.cbAccess.Name = "cbAccess";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // teamBindingSource
            // 
            this.teamBindingSource.DataSource = typeof(Utility.Models.Team);
            // 
            // WelcomeForm
            // 
            this.AcceptButton = this.btnContinue;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ControlBox = false;
            this.Controls.Add(this.cbAccess);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.cbLanguage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "WelcomeForm";
            this.Load += new System.EventHandler(this.WelcomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.teamBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox cbGender;
        private Label label2;
        private ComboBox cbLanguage;
        private Button btnContinue;
        private Button btnCancel;
        private Label label3;
        private ComboBox cbAccess;
        private Label label4;
        private BindingSource teamBindingSource;
    }
}