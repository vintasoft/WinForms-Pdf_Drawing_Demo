#if REMOVE_PDF_PLUGIN
#error Remove CreateFontForm from project.
#endif

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Tree.Fonts;

using DemosCommonCode.Pdf.Security;
using DemosCommonCode.Imaging;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A form that allows to create new PDF font.
    /// </summary>
    public partial class CreateFontForm : Form
    {

        #region Fields

        /// <summary>
        /// The PDF document.
        /// </summary>
        PdfDocument _document;

        /// <summary>
        /// Selected PDF document.
        /// </summary>
        PdfDocument _selectedDocument;

        /// <summary>
        /// Temp PDF document.
        /// </summary>
        PdfDocument _tempDocument;

        /// <summary>
        /// A stream that contains TrueType font.
        /// </summary>
        Stream _ttfStream;

        /// <summary>
        /// Indicates that form is initialized.
        /// </summary>
        bool _isInitialized = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFontForm"/> class.
        /// </summary>
        public CreateFontForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFontForm"/> class.
        /// </summary>
        /// <param name="document">The PDF document.</param>
        public CreateFontForm(PdfDocument document)
            : this()
        {
            // init current PDF document
            _document = document;
            // select font type
            fontTypeComboBox.SelectedIndex = 1;
            // indicate that standard font is selected
            standardFontRadioButton.Checked = true;

            // indicate that form is initialized
            _isInitialized = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFontForm"/> class.
        /// </summary>
        /// <param name="document">The PDF document.</param>
        /// <param name="font">The font from PDF document.</param>
        public CreateFontForm(PdfDocument document, PdfFont font)
            : this()
        {
            // if font is empty
            if (font == null)
            {
                // init current PDF document
                _document = document;
                // select font type
                fontTypeComboBox.SelectedIndex = 1;
                // indicate that standard font is selected
                standardFontRadioButton.Checked = true;
            }
            // if font is not empty
            else
            {
                // init current PDF document
                _document = font.Document;
                // init selected PDF document
                _selectedDocument = _document;
                // init selected font
                _selectedFont = font;
                // indicate that PDF document font is selected
                fromPDFDocumentRadioButton.Checked = true;
                // show font in font viewer
                pdfFontViewerControl.PdfFont = font;

                // get fonts of PDF document
                IList<PdfFont> fonts = _selectedDocument.GetFonts();
                // for each font
                for (int i = 0; i < fonts.Count; i++)
                {
                    // add font to the fonts combo box
                    fontsComboBox.Items.Add(string.Format("[{1}] {0}", fonts[i].FontName, fonts[i].ObjectNumber));
                }
                fontsComboBox.SelectedIndex = fonts.IndexOf(font);
            }
            // show type group box
            fontTypeGroupBox.Visible = false;

            // indicate that form is initialized
            _isInitialized = true;
        }

        #endregion



        #region Properties

        PdfFont _selectedFont;
        /// <summary>
        /// Gets the selected PDF font.
        /// </summary>
        public PdfFont SelectedFont
        {
            get
            {
                return _selectedFont;
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the Click event of ButtonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the Click event of ButtonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                // if system font is selected
                if (systemFontRadioButton.Checked)
                {
                    // get selected font
                    string fontName = (string)fontsComboBox.SelectedItem;
                    try
                    {
                        // get TrueType font from the system
                        _selectedFont = GetTrueTypeFontFromSystem(fontName, _document, PdfCompression.Zip);
                    }
                    catch (Exception ex)
                    {
                        // show error message
                        DemosTools.ShowErrorMessage(ex);
                        return;
                    }
                }
                // if TrueType font is selected
                else if (fromTTFRadioButton.Checked)
                {
                    // if TrueType font stream is empty
                    if (_ttfStream == null)
                        return;

                    // set stream position
                    _ttfStream.Position = 0;
                    // set font
                    _selectedFont = GetTrueTypeFontFromStream(_ttfStream, _document, PdfCompression.Zip);
                }
                // if PDF document font is selected
                else if (fromPDFDocumentRadioButton.Checked)
                {
                    // if selected document is empty
                    if (_selectedDocument == null)
                        return;

                    // get fonts from document
                    PdfFont[] fonts = _selectedDocument.GetFonts();
                    // get selected font
                    PdfFont font = fonts[fontsComboBox.SelectedIndex];

                    // if selected font is located in current document
                    if (_selectedDocument == _document)
                    {
                        // set selected font
                        _selectedFont = font;
                    }
                    // if selected font is located in another document
                    else
                    {
                        // create a font copy and use it as selected font
                        _selectedFont = _document.FontManager.CreateFontCopy(font);
                    }
                }
                // if standard font is selected
                else if (standardFontRadioButton.Checked)
                {
                    // set selected font
                    _selectedFont = _document.FontManager.GetStandardFont((PdfStandardFontType)fontsComboBox.SelectedItem);
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of FontsComboBox object.
        /// </summary>
        private void fontsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // show font in font viewer
            SetFontInFontViewer();
        }

        /// <summary>
        /// Handles the CheckedChanged event of FromTTFRadioButton object.
        /// </summary>
        private void fromTTFRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // if TrueType font stream is not empty
            if (_ttfStream != null)
            {
                // close stream
                _ttfStream.Close();
                _ttfStream.Dispose();
                _ttfStream = null;
            }

            // if TrueType font is selected
            if (fromTTFRadioButton.Checked)
            {
                // remove all fonts from fonts combo box
                fontsComboBox.Items.Clear();
                // hide font type group box
                fontTypeGroupBox.Visible = false;
                // if open file dialog result is OK
                if (openTTFFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // open TrueType font file 
                        _ttfStream = File.OpenRead(openTTFFileDialog.FileName);
                        // show font in font viewer
                        SetFontInFontViewer();
                        // show font type group box
                        fontTypeGroupBox.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        // remove font from font viewer
                        pdfFontViewerControl.PdfFont = null;
                        // show error message
                        DemosTools.ShowErrorMessage(ex);
                    }
                }
                // if TrueType font is NOT selected
                else
                {
                    // remove font from font viewer
                    pdfFontViewerControl.PdfFont = null;
                }
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of SystemFontRadioButton object.
        /// </summary>
        private void systemFontRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // if system font is selected
            if (systemFontRadioButton.Checked)
            {
                // show font type group box
                fontTypeGroupBox.Visible = true;
                // remove all fonts from fonts combo box
                fontsComboBox.Items.Clear();
                fontsComboBox.SelectedIndex = -1;

                // get system font names
                string[] fontNames = CustomFontProgramsController.GetSystemInstalledFontNames();
                // for each font in name
                foreach (string fontName in fontNames)
                {
                    // skip font collections
                    string fontFilename = CustomFontProgramsController.GetSystemInstalledFontFileName(fontName);
                    if (Path.GetExtension(fontFilename).ToUpperInvariant() == ".TTC")
                        continue;

                    // add font name to the fonts combo box
                    fontsComboBox.Items.Add(fontName);
                }
                fontsComboBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Handles the FormClosing event of CreateFontForm object.
        /// </summary>
        private void createFontForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // free all resources
            FreeResources();
        }

        /// <summary>
        /// Handles the CheckedChanged event of FromPDFDocumentRadioButton object.
        /// </summary>
        private void fromPDFDocumentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // if form is initialized
            if (!_isInitialized)
                return;

            // remove all fonts from fonts combo box 
            fontsComboBox.Items.Clear();
            // if selected PDF document is not empty
            if (_selectedDocument != null)
            {
                // if selected PDF document is not current PDF document
                if (_selectedDocument != _document)
                {
                    // close selected PDF document
                    _selectedDocument.Dispose();
                }
                _selectedDocument = null;
                // remove font from font viewer 
                pdfFontViewerControl.PdfFont = null;
            }

            // if PDF document font is selected 
            if (fromPDFDocumentRadioButton.Checked)
            {
                // show font type group box
                fontTypeGroupBox.Visible = false;
                // if open file dialog result is OK
                if (openPdfDocumentDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // set selected PDF document
                        _selectedDocument = new PdfDocument(openPdfDocumentDialog.FileName, true);
                        // if authentication is successful
                        if (PdfDocumentPasswordForm.Authenticate(_selectedDocument, openPdfDocumentDialog.FileName))
                        {
                            // get fonts from PDF document
                            IList<PdfFont> fonts = _selectedDocument.GetFonts();
                            // if font list is not empty
                            if (fonts.Count > 0)
                            {
                                // for each font
                                for (int i = 0; i < fonts.Count; i++)
                                {
                                    // add font to the fonts combo box
                                    fontsComboBox.Items.Add(string.Format("[{1}] {0}", fonts[i].FontName, fonts[i].ObjectNumber));
                                }
                                fontsComboBox.SelectedIndex = 0;
                            }
                            // if font list is empty
                            else
                            {
                                // show warning message
                                DemosTools.ShowWarningMessage("This document does not contain fonts.");
                                // close selected PDF document
                                _selectedDocument.Dispose();
                                _selectedDocument = null;
                            }
                        }
                        // if authentication is not successful
                        else
                        {
                            // close selected PDF document
                            _selectedDocument.Dispose();
                            _selectedDocument = null;
                        }

                    }
                    catch (Exception ex)
                    {
                        // remove font from font viewer
                        pdfFontViewerControl.PdfFont = null;
                        // show error message
                        DemosTools.ShowErrorMessage(ex);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of StandardFontRadioButton object.
        /// </summary>
        private void standardFontRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // remove all fonts from fonts combo box 
            fontsComboBox.Items.Clear();
            // if standard font is selected
            if (standardFontRadioButton.Checked)
            {
                // show font type group box
                fontTypeGroupBox.Visible = false;
                fontsComboBox.SelectedIndex = -1;
                // for each standard font
                for (int i = 0; i < PdfFont.StandardFontsCount; i++)
                {
                    // add font to the fonts combo box
                    fontsComboBox.Items.Add((PdfStandardFontType)i);
                }
                fontsComboBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of FontTypeComboBox object.
        /// </summary>
        private void fontTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // show font in font viewer
            SetFontInFontViewer();
        } 

        #endregion

        /// <summary>
        /// Shows system font in font viewer.
        /// </summary>
        private void SetFontFromSystemFonts()
        {
            // get selected font
            string fontName = (string)fontsComboBox.SelectedItem;
            try
            {
                // get old temp document
                PdfDocument oldTempDocument = _tempDocument;
                // get new temp document
                _tempDocument = new PdfDocument(PdfFormat.Pdf_14);
                // get TrueType font from the system and set the font to the font viewer
                pdfFontViewerControl.PdfFont = GetTrueTypeFontFromSystem(fontName, _tempDocument, PdfCompression.None);
                // if old temp document is not empty
                if (oldTempDocument != null)
                {
                    // close old temp document
                    oldTempDocument.Dispose();
                }
            }
            catch (Exception ex)
            {
                // remove font from font viewer
                pdfFontViewerControl.PdfFont = null;
                // show error message
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Shows font in font viewer.
        /// </summary>
        private void SetFontInFontViewer()
        {
            try
            {
                // if TrueType font is selected
                if (fromTTFRadioButton.Checked)
                {
                    // get old temp document
                    PdfDocument oldTempDocument = _tempDocument;
                    // get new temp document
                    _tempDocument = new PdfDocument(PdfFormat.Pdf_14);
                    // get TrueType font from the stream and set font to the font viewer
                    pdfFontViewerControl.PdfFont = GetTrueTypeFontFromStream(_ttfStream, _tempDocument, PdfCompression.None);
                    // if old temp document is not empty
                    if (oldTempDocument != null)
                    {
                        // close old temp document
                        oldTempDocument.Dispose();
                    }
                }
                // if TrueType font is not selected
                else
                {
                    // if font in fonts combo box is selected
                    if (fontsComboBox.SelectedIndex >= 0)
                    {
                        // if system font is selected 
                        if (systemFontRadioButton.Checked)
                        {
                            // show system font in font viewer
                            SetFontFromSystemFonts();
                        }
                        // if PDF document font is selected
                        else if (fromPDFDocumentRadioButton.Checked)
                        {
                            // get fonts from selected PDF document
                            PdfFont[] fonts = _selectedDocument.GetFonts();
                            // show selected font in font viewer
                            pdfFontViewerControl.PdfFont = fonts[fontsComboBox.SelectedIndex];
                        }
                        // if standard font is selected
                        else if (standardFontRadioButton.Checked)
                        {
                            // if temp document if empty
                            if (_tempDocument == null)
                            {
                                // get new temp document
                                _tempDocument = new PdfDocument(PdfFormat.Pdf_14);
                            }
                            // show selected font in font viewer
                            pdfFontViewerControl.PdfFont = _tempDocument.FontManager.GetStandardFont(((PdfStandardFontType)fontsComboBox.SelectedIndex));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Returns TrueType font from the system.
        /// </summary>
        /// <param name="fontName">TrueType font name.</param>
        /// <param name="document">A PDF document.</param>
        /// <param name="compression">A PDF compression.</param>
        /// <returns>TrueType font.</returns>
        private PdfFont GetTrueTypeFontFromSystem(string fontName, PdfDocument document, PdfCompression compression)
        {
            // open TrueType font file
            using (Stream stream = File.OpenRead(CustomFontProgramsController.GetSystemInstalledFontFileName(fontName)))
            {
                // get TrueType font from a stream
                return GetTrueTypeFontFromStream(stream, document, compression);
            }
        }

        /// <summary>
        /// Returns TrueType font from a stream.
        /// </summary>
        /// <param name="ttfStream">A stream that contains TrueType font.</param>
        /// <param name="document">A PDF document.</param>
        /// <param name="compression">A PDF compression.</param>
        /// <returns>TrueType font.</returns>
        private PdfFont GetTrueTypeFontFromStream(Stream ttfStream, PdfDocument document, PdfCompression compression)
        {
            // if simple font type is selected
            if (fontTypeComboBox.SelectedIndex == 0)
            {
                // return simple font type
                return document.FontManager.CreateSimpleFontFromTrueTypeFont(ttfStream, compression);
            }
            // retutn composite font type
            return document.FontManager.CreateCIDFontFromTrueTypeFont(ttfStream, compression);
        }

        /// <summary>
        /// Releases resources.
        /// </summary>
        private void FreeResources()
        {
            // if true type font stream is not empty
            if (_ttfStream != null)
            {
                // close stream
                _ttfStream.Close();
                _ttfStream.Dispose();
            }

            // if selected PDF document is not empty
            // and selected PDF document is not current PDF document
            if (_selectedDocument != null && _selectedDocument != _document)
            {
                // close curret PDF document
                _selectedDocument.Dispose();
            }
            // if temp document is not empty
            if (_tempDocument != null)
            {
                // close temp document
                _tempDocument.Dispose();
                _tempDocument = null;
            }
        }

        #endregion

    }
}
