namespace DemosCommonCode.Pdf.Security
{
    partial class SelectCertificateForm
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
            this.certificatesListBox = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.certDitailsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // certificatesListBox
            // 
            this.certificatesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.certificatesListBox.BackColor = System.Drawing.SystemColors.Window;
            this.certificatesListBox.FormattingEnabled = true;
            this.certificatesListBox.Location = new System.Drawing.Point(12, 12);
            this.certificatesListBox.Name = "certificatesListBox";
            this.certificatesListBox.Size = new System.Drawing.Size(541, 173);
            this.certificatesListBox.TabIndex = 0;
            this.certificatesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.certificatesListBox_MouseDoubleClick);
            this.certificatesListBox.SelectedIndexChanged += new System.EventHandler(this.certificatesListBox_SelectedIndexChanged);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.addButton.Location = new System.Drawing.Point(12, 197);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(98, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add From File...";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(478, 197);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(397, 197);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // certDitailsButton
            // 
            this.certDitailsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.certDitailsButton.Location = new System.Drawing.Point(116, 197);
            this.certDitailsButton.Name = "certDitailsButton";
            this.certDitailsButton.Size = new System.Drawing.Size(98, 23);
            this.certDitailsButton.TabIndex = 4;
            this.certDitailsButton.Text = "Details...";
            this.certDitailsButton.UseVisualStyleBackColor = true;
            this.certDitailsButton.Click += new System.EventHandler(this.certDitailsButton_Click);
            // 
            // SelectCertificateForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(565, 232);
            this.Controls.Add(this.certDitailsButton);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.certificatesListBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectCertificateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Certificate";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox certificatesListBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button certDitailsButton;
    }
}