namespace DemosCommonCode.Pdf.Security
{
    partial class CreateSignatureAppearanceForm
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundColorRadioButton = new System.Windows.Forms.RadioButton();
            this.backgroundImageRadioButton = new System.Windows.Forms.RadioButton();
            this.backgroundNoneRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.contactInfoCheckBox = new System.Windows.Forms.CheckBox();
            this.reasonCheckBox = new System.Windows.Forms.CheckBox();
            this.dateCheckBox = new System.Windows.Forms.CheckBox();
            this.locationCheckBox = new System.Windows.Forms.CheckBox();
            this.nameCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.signatureNameRadioButton = new System.Windows.Forms.RadioButton();
            this.signatureImageRadioButton = new System.Windows.Forms.RadioButton();
            this.signatureNoneRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.signatureAppearanceEditor = new Vintasoft.Imaging.UI.ImageViewer();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(456, 266);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.backgroundColorRadioButton);
            this.groupBox1.Controls.Add(this.backgroundImageRadioButton);
            this.groupBox1.Controls.Add(this.backgroundNoneRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(4, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 83);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Background";
            // 
            // backgroundColorRadioButton
            // 
            this.backgroundColorRadioButton.AutoSize = true;
            this.backgroundColorRadioButton.Location = new System.Drawing.Point(8, 59);
            this.backgroundColorRadioButton.Name = "backgroundColorRadioButton";
            this.backgroundColorRadioButton.Size = new System.Drawing.Size(58, 17);
            this.backgroundColorRadioButton.TabIndex = 2;
            this.backgroundColorRadioButton.Text = "Color...";
            this.backgroundColorRadioButton.UseVisualStyleBackColor = true;
            this.backgroundColorRadioButton.Click += new System.EventHandler(this.backgroundColorRadioButton_Click);
            // 
            // backgroundImageRadioButton
            // 
            this.backgroundImageRadioButton.AutoSize = true;
            this.backgroundImageRadioButton.Location = new System.Drawing.Point(8, 39);
            this.backgroundImageRadioButton.Name = "backgroundImageRadioButton";
            this.backgroundImageRadioButton.Size = new System.Drawing.Size(106, 17);
            this.backgroundImageRadioButton.TabIndex = 1;
            this.backgroundImageRadioButton.Text = "Imported image...";
            this.backgroundImageRadioButton.UseVisualStyleBackColor = true;
            this.backgroundImageRadioButton.Click += new System.EventHandler(this.backgroundImageRadioButton_Click);
            // 
            // backgroundNoneRadioButton
            // 
            this.backgroundNoneRadioButton.AutoSize = true;
            this.backgroundNoneRadioButton.Checked = true;
            this.backgroundNoneRadioButton.Location = new System.Drawing.Point(8, 19);
            this.backgroundNoneRadioButton.Name = "backgroundNoneRadioButton";
            this.backgroundNoneRadioButton.Size = new System.Drawing.Size(51, 17);
            this.backgroundNoneRadioButton.TabIndex = 0;
            this.backgroundNoneRadioButton.TabStop = true;
            this.backgroundNoneRadioButton.Text = "None";
            this.backgroundNoneRadioButton.UseVisualStyleBackColor = true;
            this.backgroundNoneRadioButton.CheckedChanged += new System.EventHandler(this.backgroundNoneRadioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.contactInfoCheckBox);
            this.groupBox2.Controls.Add(this.reasonCheckBox);
            this.groupBox2.Controls.Add(this.dateCheckBox);
            this.groupBox2.Controls.Add(this.locationCheckBox);
            this.groupBox2.Controls.Add(this.nameCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(4, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 72);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Text";
            // 
            // contactInfoCheckBox
            // 
            this.contactInfoCheckBox.AutoSize = true;
            this.contactInfoCheckBox.Checked = true;
            this.contactInfoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.contactInfoCheckBox.Location = new System.Drawing.Point(8, 51);
            this.contactInfoCheckBox.Name = "contactInfoCheckBox";
            this.contactInfoCheckBox.Size = new System.Drawing.Size(84, 17);
            this.contactInfoCheckBox.TabIndex = 4;
            this.contactInfoCheckBox.Text = "Contact Info";
            this.contactInfoCheckBox.UseVisualStyleBackColor = true;
            this.contactInfoCheckBox.CheckedChanged += new System.EventHandler(this.textCheckBox_CheckedChanged);
            // 
            // reasonCheckBox
            // 
            this.reasonCheckBox.AutoSize = true;
            this.reasonCheckBox.Checked = true;
            this.reasonCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.reasonCheckBox.Location = new System.Drawing.Point(94, 15);
            this.reasonCheckBox.Name = "reasonCheckBox";
            this.reasonCheckBox.Size = new System.Drawing.Size(63, 17);
            this.reasonCheckBox.TabIndex = 3;
            this.reasonCheckBox.Text = "Reason";
            this.reasonCheckBox.UseVisualStyleBackColor = true;
            this.reasonCheckBox.CheckedChanged += new System.EventHandler(this.textCheckBox_CheckedChanged);
            // 
            // dateCheckBox
            // 
            this.dateCheckBox.AutoSize = true;
            this.dateCheckBox.Checked = true;
            this.dateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dateCheckBox.Location = new System.Drawing.Point(94, 33);
            this.dateCheckBox.Name = "dateCheckBox";
            this.dateCheckBox.Size = new System.Drawing.Size(49, 17);
            this.dateCheckBox.TabIndex = 2;
            this.dateCheckBox.Text = "Date";
            this.dateCheckBox.UseVisualStyleBackColor = true;
            this.dateCheckBox.CheckedChanged += new System.EventHandler(this.textCheckBox_CheckedChanged);
            // 
            // locationCheckBox
            // 
            this.locationCheckBox.AutoSize = true;
            this.locationCheckBox.Checked = true;
            this.locationCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.locationCheckBox.Location = new System.Drawing.Point(8, 33);
            this.locationCheckBox.Name = "locationCheckBox";
            this.locationCheckBox.Size = new System.Drawing.Size(67, 17);
            this.locationCheckBox.TabIndex = 1;
            this.locationCheckBox.Text = "Location";
            this.locationCheckBox.UseVisualStyleBackColor = true;
            this.locationCheckBox.CheckedChanged += new System.EventHandler(this.textCheckBox_CheckedChanged);
            // 
            // nameCheckBox
            // 
            this.nameCheckBox.AutoSize = true;
            this.nameCheckBox.Checked = true;
            this.nameCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nameCheckBox.Location = new System.Drawing.Point(8, 15);
            this.nameCheckBox.Name = "nameCheckBox";
            this.nameCheckBox.Size = new System.Drawing.Size(54, 17);
            this.nameCheckBox.TabIndex = 0;
            this.nameCheckBox.Text = "Name";
            this.nameCheckBox.UseVisualStyleBackColor = true;
            this.nameCheckBox.CheckedChanged += new System.EventHandler(this.textCheckBox_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.signatureNameRadioButton);
            this.groupBox3.Controls.Add(this.signatureImageRadioButton);
            this.groupBox3.Controls.Add(this.signatureNoneRadioButton);
            this.groupBox3.Location = new System.Drawing.Point(4, 94);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(168, 87);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Signature";
            // 
            // signatureNameRadioButton
            // 
            this.signatureNameRadioButton.AutoSize = true;
            this.signatureNameRadioButton.Location = new System.Drawing.Point(8, 40);
            this.signatureNameRadioButton.Name = "signatureNameRadioButton";
            this.signatureNameRadioButton.Size = new System.Drawing.Size(53, 17);
            this.signatureNameRadioButton.TabIndex = 2;
            this.signatureNameRadioButton.Text = "Name";
            this.signatureNameRadioButton.UseVisualStyleBackColor = true;
            this.signatureNameRadioButton.CheckedChanged += new System.EventHandler(this.signatureNameRadioButton_CheckedChanged);
            // 
            // signatureImageRadioButton
            // 
            this.signatureImageRadioButton.AutoSize = true;
            this.signatureImageRadioButton.Location = new System.Drawing.Point(8, 62);
            this.signatureImageRadioButton.Name = "signatureImageRadioButton";
            this.signatureImageRadioButton.Size = new System.Drawing.Size(106, 17);
            this.signatureImageRadioButton.TabIndex = 1;
            this.signatureImageRadioButton.Text = "Imported image...";
            this.signatureImageRadioButton.UseVisualStyleBackColor = true;
            this.signatureImageRadioButton.Click += new System.EventHandler(this.signatureImageRadioButton_Click);
            // 
            // signatureNoneRadioButton
            // 
            this.signatureNoneRadioButton.AutoSize = true;
            this.signatureNoneRadioButton.Checked = true;
            this.signatureNoneRadioButton.Location = new System.Drawing.Point(8, 19);
            this.signatureNoneRadioButton.Name = "signatureNoneRadioButton";
            this.signatureNoneRadioButton.Size = new System.Drawing.Size(51, 17);
            this.signatureNoneRadioButton.TabIndex = 0;
            this.signatureNoneRadioButton.TabStop = true;
            this.signatureNoneRadioButton.Text = "None";
            this.signatureNoneRadioButton.UseVisualStyleBackColor = true;
            this.signatureNoneRadioButton.CheckedChanged += new System.EventHandler(this.signatureNoneRadioButton_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.signatureAppearanceEditor);
            this.groupBox4.Location = new System.Drawing.Point(178, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(434, 252);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Signature Appearance Visual Editor (click to edit)";
            // 
            // signatureAppearanceEditor
            // 
            this.signatureAppearanceEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.signatureAppearanceEditor.AutoScroll = true;
            this.signatureAppearanceEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signatureAppearanceEditor.Location = new System.Drawing.Point(6, 19);
            this.signatureAppearanceEditor.Name = "signatureAppearanceEditor";
            this.signatureAppearanceEditor.Size = new System.Drawing.Size(422, 227);
            this.signatureAppearanceEditor.SizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.signatureAppearanceEditor.TabIndex = 3;
            this.signatureAppearanceEditor.Text = "imageViewer1";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(537, 266);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // CreateSignatureAppearanceForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(624, 298);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.MinimizeBox = false;
            this.Name = "CreateSignatureAppearanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Signature Appearance";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton backgroundColorRadioButton;
        private System.Windows.Forms.RadioButton backgroundImageRadioButton;
        private System.Windows.Forms.RadioButton backgroundNoneRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox reasonCheckBox;
        private System.Windows.Forms.CheckBox dateCheckBox;
        private System.Windows.Forms.CheckBox locationCheckBox;
        private System.Windows.Forms.CheckBox nameCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton signatureImageRadioButton;
        private System.Windows.Forms.RadioButton signatureNoneRadioButton;
        private System.Windows.Forms.RadioButton signatureNameRadioButton;
        private System.Windows.Forms.CheckBox contactInfoCheckBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private Vintasoft.Imaging.UI.ImageViewer signatureAppearanceEditor;
        private System.Windows.Forms.Button buttonCancel;
    }
}