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
            Vintasoft.Imaging.Utils.WinFormsSystemClipboard winFormsSystemClipboard2 = new Vintasoft.Imaging.Utils.WinFormsSystemClipboard();
            Vintasoft.Imaging.Codecs.Decoders.RenderingSettings renderingSettings2 = new Vintasoft.Imaging.Codecs.Decoders.RenderingSettings();
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(502, 334);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 88);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Background";
            // 
            // backgroundColorRadioButton
            // 
            this.backgroundColorRadioButton.AutoSize = true;
            this.backgroundColorRadioButton.Location = new System.Drawing.Point(3, 49);
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
            this.backgroundImageRadioButton.Location = new System.Drawing.Point(3, 26);
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
            this.backgroundNoneRadioButton.Location = new System.Drawing.Point(3, 3);
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
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 88);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Text";
            // 
            // contactInfoCheckBox
            // 
            this.contactInfoCheckBox.AutoSize = true;
            this.contactInfoCheckBox.Checked = true;
            this.contactInfoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.contactInfoCheckBox.Location = new System.Drawing.Point(3, 49);
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
            this.reasonCheckBox.Location = new System.Drawing.Point(93, 3);
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
            this.dateCheckBox.Location = new System.Drawing.Point(93, 26);
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
            this.locationCheckBox.Location = new System.Drawing.Point(3, 26);
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
            this.nameCheckBox.Location = new System.Drawing.Point(3, 3);
            this.nameCheckBox.Name = "nameCheckBox";
            this.nameCheckBox.Size = new System.Drawing.Size(54, 17);
            this.nameCheckBox.TabIndex = 0;
            this.nameCheckBox.Text = "Name";
            this.nameCheckBox.UseVisualStyleBackColor = true;
            this.nameCheckBox.CheckedChanged += new System.EventHandler(this.textCheckBox_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.tableLayoutPanel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(186, 88);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Signature";
            // 
            // signatureNameRadioButton
            // 
            this.signatureNameRadioButton.AutoSize = true;
            this.signatureNameRadioButton.Location = new System.Drawing.Point(3, 26);
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
            this.signatureImageRadioButton.Location = new System.Drawing.Point(3, 49);
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
            this.signatureNoneRadioButton.Location = new System.Drawing.Point(3, 3);
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
            this.groupBox4.Controls.Add(this.signatureAppearanceEditor);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(195, 3);
            this.groupBox4.Name = "groupBox4";
            this.tableLayoutPanel4.SetRowSpan(this.groupBox4, 3);
            this.groupBox4.Size = new System.Drawing.Size(455, 304);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Signature Appearance Visual Editor (click to edit)";
            // 
            // signatureAppearanceEditor
            // 
            this.signatureAppearanceEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.signatureAppearanceEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signatureAppearanceEditor.Clipboard = winFormsSystemClipboard2;
            this.signatureAppearanceEditor.ImageRenderingSettings = renderingSettings2;
            this.signatureAppearanceEditor.ImageRotationAngle = 0;
            this.signatureAppearanceEditor.Location = new System.Drawing.Point(6, 19);
            this.signatureAppearanceEditor.Name = "signatureAppearanceEditor";
            this.signatureAppearanceEditor.Size = new System.Drawing.Size(443, 279);
            this.signatureAppearanceEditor.SizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.signatureAppearanceEditor.TabIndex = 3;
            this.signatureAppearanceEditor.Text = "imageViewer1";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(583, 334);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.nameCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.contactInfoCheckBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.reasonCheckBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.locationCheckBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateCheckBox, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(180, 69);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.signatureNoneRadioButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.signatureImageRadioButton, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.signatureNameRadioButton, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(180, 69);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.backgroundNoneRadioButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.backgroundColorRadioButton, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.backgroundImageRadioButton, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(180, 69);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBox4, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(653, 310);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // CreateSignatureAppearanceForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(670, 366);
            this.Controls.Add(this.tableLayoutPanel4);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    }
}