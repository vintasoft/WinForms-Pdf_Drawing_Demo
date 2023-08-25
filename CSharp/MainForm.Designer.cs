namespace PdfDrawingDemo
{
    partial class MainForm
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
            Vintasoft.Imaging.Utils.WinFormsSystemClipboard winFormsSystemClipboard1 = new Vintasoft.Imaging.Utils.WinFormsSystemClipboard();
            Vintasoft.Imaging.Codecs.Decoders.RenderingSettings renderingSettings1 = new Vintasoft.Imaging.Codecs.Decoders.RenderingSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInPDFReaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paperSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paperSizeToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.rotatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontSizeToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.showLogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontSymbolsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicsTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomPrimitivesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transformsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateAtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicsStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setClipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawStringAlignmentTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.measureStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcTwTsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilingPatternToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearGradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interactiveFormsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxComboBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxRadioButtonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.digitalSignatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barcodeFieldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alignmentPanelElementContentAlignmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionalContentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePdfFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imageViewer1 = new Vintasoft.Imaging.UI.ImageViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageViewerToolStrip1 = new DemosCommonCode.Imaging.ImageViewerToolStrip();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.graphicsTestToolStripMenuItem,
            this.interactiveFormsToolStripMenuItem,
            this.testToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem,
            this.viewInPDFReaderToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // viewInPDFReaderToolStripMenuItem
            // 
            this.viewInPDFReaderToolStripMenuItem.Name = "viewInPDFReaderToolStripMenuItem";
            this.viewInPDFReaderToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.viewInPDFReaderToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.viewInPDFReaderToolStripMenuItem.Text = "View in PDF reader";
            this.viewInPDFReaderToolStripMenuItem.Click += new System.EventHandler(this.viewInPDFReaderToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paperSizeToolStripMenuItem,
            this.fontSizeToolStripMenuItem,
            this.showLogoToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // paperSizeToolStripMenuItem
            // 
            this.paperSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paperSizeToolStripComboBox,
            this.rotatedToolStripMenuItem});
            this.paperSizeToolStripMenuItem.Name = "paperSizeToolStripMenuItem";
            this.paperSizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.paperSizeToolStripMenuItem.Text = "Paper Size";
            // 
            // paperSizeToolStripComboBox
            // 
            this.paperSizeToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paperSizeToolStripComboBox.Name = "paperSizeToolStripComboBox";
            this.paperSizeToolStripComboBox.Size = new System.Drawing.Size(121, 23);
            // 
            // rotatedToolStripMenuItem
            // 
            this.rotatedToolStripMenuItem.CheckOnClick = true;
            this.rotatedToolStripMenuItem.Name = "rotatedToolStripMenuItem";
            this.rotatedToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.rotatedToolStripMenuItem.Text = "Rotated";
            // 
            // fontSizeToolStripMenuItem
            // 
            this.fontSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontSizeToolStripComboBox});
            this.fontSizeToolStripMenuItem.Name = "fontSizeToolStripMenuItem";
            this.fontSizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fontSizeToolStripMenuItem.Text = "Font Size";
            // 
            // fontSizeToolStripComboBox
            // 
            this.fontSizeToolStripComboBox.Items.AddRange(new object[] {
            "4",
            "6",
            "8",
            "10",
            "12",
            "14",
            "16",
            "18",
            "20",
            "25",
            "30"});
            this.fontSizeToolStripComboBox.Name = "fontSizeToolStripComboBox";
            this.fontSizeToolStripComboBox.Size = new System.Drawing.Size(121, 23);
            this.fontSizeToolStripComboBox.Text = "10";
            // 
            // showLogoToolStripMenuItem
            // 
            this.showLogoToolStripMenuItem.Checked = true;
            this.showLogoToolStripMenuItem.CheckOnClick = true;
            this.showLogoToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showLogoToolStripMenuItem.Name = "showLogoToolStripMenuItem";
            this.showLogoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showLogoToolStripMenuItem.Text = "Show Logo";
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorTableToolStripMenuItem,
            this.fontSymbolsToolStripMenuItem1});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.reportToolStripMenuItem.Text = "Table";
            // 
            // colorTableToolStripMenuItem
            // 
            this.colorTableToolStripMenuItem.Name = "colorTableToolStripMenuItem";
            this.colorTableToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.colorTableToolStripMenuItem.Text = "Color Table";
            this.colorTableToolStripMenuItem.Click += new System.EventHandler(this.colorTableToolStripMenuItem_Click);
            // 
            // fontSymbolsToolStripMenuItem1
            // 
            this.fontSymbolsToolStripMenuItem1.Name = "fontSymbolsToolStripMenuItem1";
            this.fontSymbolsToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.fontSymbolsToolStripMenuItem1.Text = "Font Symbols";
            this.fontSymbolsToolStripMenuItem1.Click += new System.EventHandler(this.fontSymbolsToolStripMenuItem1_Click);
            // 
            // graphicsTestToolStripMenuItem
            // 
            this.graphicsTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomPrimitivesToolStripMenuItem,
            this.transformsToolStripMenuItem,
            this.graphicsStateToolStripMenuItem,
            this.setClipToolStripMenuItem,
            this.drawStringToolStripMenuItem,
            this.drawStringAlignmentTestToolStripMenuItem,
            this.measureStringToolStripMenuItem,
            this.tcTwTsToolStripMenuItem,
            this.tilingPatternToolStripMenuItem,
            this.linearGradientToolStripMenuItem});
            this.graphicsTestToolStripMenuItem.Name = "graphicsTestToolStripMenuItem";
            this.graphicsTestToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.graphicsTestToolStripMenuItem.Text = "PdfGraphics";
            // 
            // randomPrimitivesToolStripMenuItem
            // 
            this.randomPrimitivesToolStripMenuItem.Name = "randomPrimitivesToolStripMenuItem";
            this.randomPrimitivesToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.randomPrimitivesToolStripMenuItem.Text = "Random Primitives";
            this.randomPrimitivesToolStripMenuItem.Click += new System.EventHandler(this.randomPrimitivesToolStripMenuItem_Click);
            // 
            // transformsToolStripMenuItem
            // 
            this.transformsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.translateToolStripMenuItem,
            this.scaleToolStripMenuItem,
            this.rotateToolStripMenuItem,
            this.rotateAtToolStripMenuItem});
            this.transformsToolStripMenuItem.Name = "transformsToolStripMenuItem";
            this.transformsToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.transformsToolStripMenuItem.Text = "Transforms";
            // 
            // translateToolStripMenuItem
            // 
            this.translateToolStripMenuItem.Name = "translateToolStripMenuItem";
            this.translateToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.translateToolStripMenuItem.Text = "Translate";
            this.translateToolStripMenuItem.Click += new System.EventHandler(this.translateToolStripMenuItem_Click);
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.scaleToolStripMenuItem.Text = "Translate and Scale";
            this.scaleToolStripMenuItem.Click += new System.EventHandler(this.scaleToolStripMenuItem_Click);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.rotateToolStripMenuItem.Text = "Rotate";
            this.rotateToolStripMenuItem.Click += new System.EventHandler(this.rotateToolStripMenuItem_Click);
            // 
            // rotateAtToolStripMenuItem
            // 
            this.rotateAtToolStripMenuItem.Name = "rotateAtToolStripMenuItem";
            this.rotateAtToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.rotateAtToolStripMenuItem.Text = "Rotate At";
            this.rotateAtToolStripMenuItem.Click += new System.EventHandler(this.rotateAtToolStripMenuItem_Click);
            // 
            // graphicsStateToolStripMenuItem
            // 
            this.graphicsStateToolStripMenuItem.Name = "graphicsStateToolStripMenuItem";
            this.graphicsStateToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.graphicsStateToolStripMenuItem.Text = "Graphics State";
            this.graphicsStateToolStripMenuItem.Click += new System.EventHandler(this.graphicsStateToolStripMenuItem_Click);
            // 
            // setClipToolStripMenuItem
            // 
            this.setClipToolStripMenuItem.Name = "setClipToolStripMenuItem";
            this.setClipToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.setClipToolStripMenuItem.Text = "SetClip";
            this.setClipToolStripMenuItem.Click += new System.EventHandler(this.setClipToolStripMenuItem_Click);
            // 
            // drawStringToolStripMenuItem
            // 
            this.drawStringToolStripMenuItem.Name = "drawStringToolStripMenuItem";
            this.drawStringToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.drawStringToolStripMenuItem.Text = "DrawString (Arial)";
            this.drawStringToolStripMenuItem.Click += new System.EventHandler(this.drawStringToolStripMenuItem_Click);
            // 
            // drawStringAlignmentTestToolStripMenuItem
            // 
            this.drawStringAlignmentTestToolStripMenuItem.Name = "drawStringAlignmentTestToolStripMenuItem";
            this.drawStringAlignmentTestToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.drawStringAlignmentTestToolStripMenuItem.Text = "DrawString (AlignmentTest)";
            this.drawStringAlignmentTestToolStripMenuItem.Click += new System.EventHandler(this.drawStringAlignmentTestToolStripMenuItem_Click);
            // 
            // measureStringToolStripMenuItem
            // 
            this.measureStringToolStripMenuItem.Name = "measureStringToolStripMenuItem";
            this.measureStringToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.measureStringToolStripMenuItem.Text = "MeasureString";
            this.measureStringToolStripMenuItem.Click += new System.EventHandler(this.measureStringToolStripMenuItem_Click);
            // 
            // tcTwTsToolStripMenuItem
            // 
            this.tcTwTsToolStripMenuItem.Name = "tcTwTsToolStripMenuItem";
            this.tcTwTsToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.tcTwTsToolStripMenuItem.Text = "Character/Word/Line Spacing";
            this.tcTwTsToolStripMenuItem.Click += new System.EventHandler(this.tcTwTsToolStripMenuItem_Click);
            // 
            // tilingPatternToolStripMenuItem
            // 
            this.tilingPatternToolStripMenuItem.Name = "tilingPatternToolStripMenuItem";
            this.tilingPatternToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.tilingPatternToolStripMenuItem.Text = "Tiling Pattern";
            this.tilingPatternToolStripMenuItem.Click += new System.EventHandler(this.tilingPatternToolStripMenuItem_Click);
            // 
            // linearGradientToolStripMenuItem
            // 
            this.linearGradientToolStripMenuItem.Name = "linearGradientToolStripMenuItem";
            this.linearGradientToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.linearGradientToolStripMenuItem.Text = "Linear Gradient";
            this.linearGradientToolStripMenuItem.Click += new System.EventHandler(this.linearGradientToolStripMenuItem_Click);
            // 
            // interactiveFormsToolStripMenuItem
            // 
            this.interactiveFormsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonToolStripMenuItem,
            this.textToolStripMenuItem,
            this.listBoxComboBoxToolStripMenuItem,
            this.checkBoxRadioButtonsToolStripMenuItem,
            this.digitalSignatureToolStripMenuItem,
            this.barcodeFieldsToolStripMenuItem,
            this.testActionsToolStripMenuItem});
            this.interactiveFormsToolStripMenuItem.Name = "interactiveFormsToolStripMenuItem";
            this.interactiveFormsToolStripMenuItem.Size = new System.Drawing.Size(138, 20);
            this.interactiveFormsToolStripMenuItem.Text = "Interactive Form Fields";
            // 
            // buttonToolStripMenuItem
            // 
            this.buttonToolStripMenuItem.Name = "buttonToolStripMenuItem";
            this.buttonToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.buttonToolStripMenuItem.Text = "Button";
            this.buttonToolStripMenuItem.Click += new System.EventHandler(this.buttonToolStripMenuItem_Click);
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.textToolStripMenuItem.Text = "Text";
            this.textToolStripMenuItem.Click += new System.EventHandler(this.textToolStripMenuItem_Click);
            // 
            // listBoxComboBoxToolStripMenuItem
            // 
            this.listBoxComboBoxToolStripMenuItem.Name = "listBoxComboBoxToolStripMenuItem";
            this.listBoxComboBoxToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.listBoxComboBoxToolStripMenuItem.Text = "ListBox, ComboBox";
            this.listBoxComboBoxToolStripMenuItem.Click += new System.EventHandler(this.listBoxToolStripMenuItem_Click);
            // 
            // checkBoxRadioButtonsToolStripMenuItem
            // 
            this.checkBoxRadioButtonsToolStripMenuItem.Name = "checkBoxRadioButtonsToolStripMenuItem";
            this.checkBoxRadioButtonsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.checkBoxRadioButtonsToolStripMenuItem.Text = "CheckBox, RadioButtons";
            this.checkBoxRadioButtonsToolStripMenuItem.Click += new System.EventHandler(this.checkBoxRadioButtonsToolStripMenuItem_Click);
            // 
            // digitalSignatureToolStripMenuItem
            // 
            this.digitalSignatureToolStripMenuItem.Name = "digitalSignatureToolStripMenuItem";
            this.digitalSignatureToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.digitalSignatureToolStripMenuItem.Text = "Digital Signature";
            this.digitalSignatureToolStripMenuItem.Click += new System.EventHandler(this.digitalSignatureToolStripMenuItem_Click);
            // 
            // barcodeFieldsToolStripMenuItem
            // 
            this.barcodeFieldsToolStripMenuItem.Name = "barcodeFieldsToolStripMenuItem";
            this.barcodeFieldsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.barcodeFieldsToolStripMenuItem.Text = "Barcode Fields";
            this.barcodeFieldsToolStripMenuItem.Click += new System.EventHandler(this.barcodeFieldsToolStripMenuItem_Click);
            // 
            // testActionsToolStripMenuItem
            // 
            this.testActionsToolStripMenuItem.Name = "testActionsToolStripMenuItem";
            this.testActionsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.testActionsToolStripMenuItem.Text = "Actions";
            this.testActionsToolStripMenuItem.Click += new System.EventHandler(this.testActionsToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alignmentPanelElementContentAlignmentToolStripMenuItem,
            this.optionalContentToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // alignmentPanelElementContentAlignmentToolStripMenuItem
            // 
            this.alignmentPanelElementContentAlignmentToolStripMenuItem.Name = "alignmentPanelElementContentAlignmentToolStripMenuItem";
            this.alignmentPanelElementContentAlignmentToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.alignmentPanelElementContentAlignmentToolStripMenuItem.Text = "AlignmentPanel.ContentAlignment";
            this.alignmentPanelElementContentAlignmentToolStripMenuItem.Click += new System.EventHandler(this.alignmentPanelElementContentAlignmentToolStripMenuItem_Click);
            // 
            // optionalContentToolStripMenuItem
            // 
            this.optionalContentToolStripMenuItem.Name = "optionalContentToolStripMenuItem";
            this.optionalContentToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.optionalContentToolStripMenuItem.Text = "Optional Content";
            this.optionalContentToolStripMenuItem.Click += new System.EventHandler(this.optionalContentToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // savePdfFileDialog
            // 
            this.savePdfFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 540);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.imageViewer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 512);
            this.panel3.TabIndex = 1;
            // 
            // imageViewer1
            // 
            this.imageViewer1.Clipboard = winFormsSystemClipboard1;
            this.imageViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer1.ImageRenderingSettings = renderingSettings1;
            this.imageViewer1.ImageRotationAngle = 0;
            this.imageViewer1.Location = new System.Drawing.Point(0, 0);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.ShortcutCut = System.Windows.Forms.Shortcut.None;
            this.imageViewer1.ShortcutDelete = System.Windows.Forms.Shortcut.None;
            this.imageViewer1.ShortcutInsert = System.Windows.Forms.Shortcut.None;
            this.imageViewer1.ShortcutSelectAll = System.Windows.Forms.Shortcut.None;
            this.imageViewer1.Size = new System.Drawing.Size(784, 512);
            this.imageViewer1.TabIndex = 0;
            this.imageViewer1.Text = "imageViewer1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.imageViewerToolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 28);
            this.panel2.TabIndex = 0;
            // 
            // imageViewerToolStrip1
            // 
            this.imageViewerToolStrip1.AssociatedZoomTrackBar = null;
            this.imageViewerToolStrip1.CanOpenFile = false;
            this.imageViewerToolStrip1.CanPrint = false;
            this.imageViewerToolStrip1.ImageViewer = this.imageViewer1;
            this.imageViewerToolStrip1.ScanButtonEnabled = true;
            this.imageViewerToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.imageViewerToolStrip1.Name = "imageViewerToolStrip1";
            this.imageViewerToolStrip1.PageCount = 0;
            this.imageViewerToolStrip1.PrintButtonEnabled = false;
            this.imageViewerToolStrip1.SaveButtonEnabled = true;
            this.imageViewerToolStrip1.Size = new System.Drawing.Size(784, 25);
            this.imageViewerToolStrip1.TabIndex = 0;
            this.imageViewerToolStrip1.Text = "imageViewerToolStrip1";
            this.imageViewerToolStrip1.UseImageViewerImages = true;
            this.imageViewerToolStrip1.SaveFile += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VintaSoft PDF Drawing Demo";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog savePdfFileDialog;
        private System.Windows.Forms.ToolStripMenuItem viewInPDFReaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paperSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox paperSizeToolStripComboBox;
        private System.Windows.Forms.ToolStripMenuItem rotatedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox fontSizeToolStripComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private Vintasoft.Imaging.UI.ImageViewer imageViewer1;
        private System.Windows.Forms.Panel panel2;
        private DemosCommonCode.Imaging.ImageViewerToolStrip imageViewerToolStrip1;
        private System.Windows.Forms.ToolStripMenuItem showLogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alignmentPanelElementContentAlignmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interactiveFormsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listBoxComboBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkBoxRadioButtonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem digitalSignatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barcodeFieldsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionalContentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testActionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphicsTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomPrimitivesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transformsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem translateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateAtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphicsStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setClipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawStringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawStringAlignmentTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem measureStringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tcTwTsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tilingPatternToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linearGradientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontSymbolsToolStripMenuItem1;
    }
}