namespace DemosCommonCode.Pdf
{
    partial class CreateFontForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pdfFontViewerControl = new Vintasoft.Imaging.Pdf.UI.PdfFontViewerControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fontTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.fontTypeComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fontsComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.standardFontRadioButton = new System.Windows.Forms.RadioButton();
            this.systemFontRadioButton = new System.Windows.Forms.RadioButton();
            this.fromTTFRadioButton = new System.Windows.Forms.RadioButton();
            this.fromPDFDocumentRadioButton = new System.Windows.Forms.RadioButton();
            this.openTTFFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openPdfDocumentDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.fontTypeGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 454);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 68);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(634, 386);
            this.panel3.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(634, 352);
            this.panel5.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.AutoScroll = true;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.pdfFontViewerControl);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(634, 352);
            this.panel6.TabIndex = 19;
            // 
            // pdfFontViewerControl
            // 
            this.pdfFontViewerControl.BackColor = System.Drawing.Color.White;
            this.pdfFontViewerControl.CellSize = new System.Drawing.Size(32, 32);
            this.pdfFontViewerControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pdfFontViewerControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pdfFontViewerControl.FontColor = System.Drawing.Color.Black;
            this.pdfFontViewerControl.Location = new System.Drawing.Point(0, 0);
            this.pdfFontViewerControl.Name = "pdfFontViewerControl";
            this.pdfFontViewerControl.PdfFont = null;
            this.pdfFontViewerControl.Size = new System.Drawing.Size(630, 46);
            this.pdfFontViewerControl.TabIndex = 0;
            this.pdfFontViewerControl.Text = "pdfFontViewerControl1";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonCancel);
            this.panel4.Controls.Add(this.buttonOk);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 352);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(634, 34);
            this.panel4.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(547, 6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOk.Location = new System.Drawing.Point(466, 6);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 16;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fontTypeGroupBox);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 68);
            this.panel2.TabIndex = 0;
            // 
            // fontTypeGroupBox
            // 
            this.fontTypeGroupBox.Controls.Add(this.fontTypeComboBox);
            this.fontTypeGroupBox.Location = new System.Drawing.Point(487, 4);
            this.fontTypeGroupBox.Name = "fontTypeGroupBox";
            this.fontTypeGroupBox.Size = new System.Drawing.Size(144, 60);
            this.fontTypeGroupBox.TabIndex = 22;
            this.fontTypeGroupBox.TabStop = false;
            this.fontTypeGroupBox.Text = "Type of new Font";
            // 
            // fontTypeComboBox
            // 
            this.fontTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontTypeComboBox.FormattingEnabled = true;
            this.fontTypeComboBox.Items.AddRange(new object[] {
            "Simple Font",
            "CID Font (Composite)"});
            this.fontTypeComboBox.Location = new System.Drawing.Point(6, 22);
            this.fontTypeComboBox.Name = "fontTypeComboBox";
            this.fontTypeComboBox.Size = new System.Drawing.Size(132, 21);
            this.fontTypeComboBox.TabIndex = 14;
            this.fontTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.fontTypeComboBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fontsComboBox);
            this.groupBox2.Location = new System.Drawing.Point(278, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(203, 60);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Source Font";
            // 
            // fontsComboBox
            // 
            this.fontsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontsComboBox.FormattingEnabled = true;
            this.fontsComboBox.Location = new System.Drawing.Point(5, 23);
            this.fontsComboBox.Name = "fontsComboBox";
            this.fontsComboBox.Size = new System.Drawing.Size(192, 21);
            this.fontsComboBox.TabIndex = 13;
            this.fontsComboBox.SelectedIndexChanged += new System.EventHandler(this.fontsComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.standardFontRadioButton);
            this.groupBox1.Controls.Add(this.systemFontRadioButton);
            this.groupBox1.Controls.Add(this.fromTTFRadioButton);
            this.groupBox1.Controls.Add(this.fromPDFDocumentRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 60);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fonts Source";
            // 
            // standardFontRadioButton
            // 
            this.standardFontRadioButton.AutoSize = true;
            this.standardFontRadioButton.Location = new System.Drawing.Point(6, 15);
            this.standardFontRadioButton.Name = "standardFontRadioButton";
            this.standardFontRadioButton.Size = new System.Drawing.Size(97, 17);
            this.standardFontRadioButton.TabIndex = 19;
            this.standardFontRadioButton.Text = "Standard Fonts";
            this.standardFontRadioButton.UseVisualStyleBackColor = true;
            this.standardFontRadioButton.CheckedChanged += new System.EventHandler(this.standardFontRadioButton_CheckedChanged);
            // 
            // systemFontRadioButton
            // 
            this.systemFontRadioButton.AutoSize = true;
            this.systemFontRadioButton.Location = new System.Drawing.Point(121, 15);
            this.systemFontRadioButton.Name = "systemFontRadioButton";
            this.systemFontRadioButton.Size = new System.Drawing.Size(143, 17);
            this.systemFontRadioButton.TabIndex = 14;
            this.systemFontRadioButton.Text = "System Fonts (TrueType)";
            this.systemFontRadioButton.UseVisualStyleBackColor = true;
            this.systemFontRadioButton.CheckedChanged += new System.EventHandler(this.systemFontRadioButton_CheckedChanged);
            // 
            // fromTTFRadioButton
            // 
            this.fromTTFRadioButton.AutoSize = true;
            this.fromTTFRadioButton.Location = new System.Drawing.Point(121, 37);
            this.fromTTFRadioButton.Name = "fromTTFRadioButton";
            this.fromTTFRadioButton.Size = new System.Drawing.Size(123, 17);
            this.fromTTFRadioButton.TabIndex = 15;
            this.fromTTFRadioButton.Text = "TrueType Font File...";
            this.fromTTFRadioButton.UseVisualStyleBackColor = true;
            this.fromTTFRadioButton.CheckedChanged += new System.EventHandler(this.fromTTFRadioButton_CheckedChanged);
            // 
            // fromPDFDocumentRadioButton
            // 
            this.fromPDFDocumentRadioButton.AutoSize = true;
            this.fromPDFDocumentRadioButton.Location = new System.Drawing.Point(6, 37);
            this.fromPDFDocumentRadioButton.Name = "fromPDFDocumentRadioButton";
            this.fromPDFDocumentRadioButton.Size = new System.Drawing.Size(107, 17);
            this.fromPDFDocumentRadioButton.TabIndex = 18;
            this.fromPDFDocumentRadioButton.Text = "PDF Document...";
            this.fromPDFDocumentRadioButton.UseVisualStyleBackColor = true;
            this.fromPDFDocumentRadioButton.CheckedChanged += new System.EventHandler(this.fromPDFDocumentRadioButton_CheckedChanged);
            // 
            // openTTFFileDialog
            // 
            this.openTTFFileDialog.DefaultExt = "ttf";
            this.openTTFFileDialog.Filter = "TrueType Fonts (*.ttf)|*.ttf";
            // 
            // openPdfDocumentDialog
            // 
            this.openPdfDocumentDialog.DefaultExt = "pdf";
            this.openPdfDocumentDialog.Filter = "PDF Documents (*.pdf)|*.pdf";
            // 
            // CreateFontForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(634, 454);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "CreateFontForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create new PDF font";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.createFontForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.fontTypeGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private Vintasoft.Imaging.Pdf.UI.PdfFontViewerControl pdfFontViewerControl;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.RadioButton fromPDFDocumentRadioButton;
        private System.Windows.Forms.ComboBox fontsComboBox;
        private System.Windows.Forms.RadioButton fromTTFRadioButton;
        private System.Windows.Forms.RadioButton systemFontRadioButton;
        private System.Windows.Forms.OpenFileDialog openTTFFileDialog;
        private System.Windows.Forms.OpenFileDialog openPdfDocumentDialog;
        private System.Windows.Forms.RadioButton standardFontRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox fontTypeGroupBox;
        private System.Windows.Forms.ComboBox fontTypeComboBox;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}