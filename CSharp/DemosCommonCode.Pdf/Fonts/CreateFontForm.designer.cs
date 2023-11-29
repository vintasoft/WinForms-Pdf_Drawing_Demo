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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.fontTypeGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 466);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 71);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(637, 395);
            this.panel3.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(637, 361);
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
            this.panel6.Size = new System.Drawing.Size(637, 361);
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
            this.pdfFontViewerControl.Size = new System.Drawing.Size(633, 46);
            this.pdfFontViewerControl.TabIndex = 0;
            this.pdfFontViewerControl.Text = "pdfFontViewerControl1";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonCancel);
            this.panel4.Controls.Add(this.buttonOk);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 361);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(637, 34);
            this.panel4.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(550, 6);
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
            this.buttonOk.Location = new System.Drawing.Point(469, 6);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 16;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(637, 71);
            this.panel2.TabIndex = 0;
            // 
            // fontTypeGroupBox
            // 
            this.fontTypeGroupBox.AutoSize = true;
            this.fontTypeGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fontTypeGroupBox.Controls.Add(this.fontTypeComboBox);
            this.fontTypeGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fontTypeGroupBox.Location = new System.Drawing.Point(483, 3);
            this.fontTypeGroupBox.MinimumSize = new System.Drawing.Size(150, 60);
            this.fontTypeGroupBox.Name = "fontTypeGroupBox";
            this.fontTypeGroupBox.Size = new System.Drawing.Size(151, 65);
            this.fontTypeGroupBox.TabIndex = 22;
            this.fontTypeGroupBox.TabStop = false;
            this.fontTypeGroupBox.Text = "Type of new Font";
            // 
            // fontTypeComboBox
            // 
            this.fontTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fontTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontTypeComboBox.FormattingEnabled = true;
            this.fontTypeComboBox.Items.AddRange(new object[] {
            "Simple Font",
            "CID Font (Composite)"});
            this.fontTypeComboBox.Location = new System.Drawing.Point(6, 22);
            this.fontTypeComboBox.Name = "fontTypeComboBox";
            this.fontTypeComboBox.Size = new System.Drawing.Size(139, 21);
            this.fontTypeComboBox.TabIndex = 14;
            this.fontTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.fontTypeComboBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.fontsComboBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(277, 3);
            this.groupBox2.MinimumSize = new System.Drawing.Size(200, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 65);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Source Font";
            // 
            // fontsComboBox
            // 
            this.fontsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fontsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontsComboBox.FormattingEnabled = true;
            this.fontsComboBox.Location = new System.Drawing.Point(5, 23);
            this.fontsComboBox.Name = "fontsComboBox";
            this.fontsComboBox.Size = new System.Drawing.Size(189, 21);
            this.fontsComboBox.TabIndex = 13;
            this.fontsComboBox.SelectedIndexChanged += new System.EventHandler(this.fontsComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 65);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fonts Source";
            // 
            // standardFontRadioButton
            // 
            this.standardFontRadioButton.AutoSize = true;
            this.standardFontRadioButton.Location = new System.Drawing.Point(3, 3);
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
            this.systemFontRadioButton.Location = new System.Drawing.Point(116, 3);
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
            this.fromTTFRadioButton.Location = new System.Drawing.Point(116, 26);
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
            this.fromPDFDocumentRadioButton.Location = new System.Drawing.Point(3, 26);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.standardFontRadioButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.fromTTFRadioButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.systemFontRadioButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.fromPDFDocumentRadioButton, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(262, 46);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.fontTypeGroupBox, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(637, 71);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // CreateFontForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(637, 466);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "CreateFontForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create new PDF font";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.createFontForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.fontTypeGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}