using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Tree.DigitalSignatures;
using Vintasoft.Imaging.Pdf.UI;

using DemosCommonCode.Imaging;
using DemosCommonCode.Imaging.Codecs;

namespace DemosCommonCode.Pdf.Security
{
    /// <summary>
    /// A form that allows to create signature field appearance.
    /// </summary>
    public partial class CreateSignatureAppearanceForm : Form
    {

        #region Fields

        /// <summary>
        /// The grahic figure that defines the signature appearance.
        /// </summary>
        SignatureAppearanceGraphicsFigure _signatureAppearance;

        /// <summary>
        /// The open image dialog.
        /// </summary>
        OpenFileDialog _openImageDialog = new OpenFileDialog();

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSignatureAppearanceForm"/> class.
        /// </summary>
        public CreateSignatureAppearanceForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSignatureAppearanceForm"/> class.
        /// </summary>
        /// <param name="signatureAppearance">The signature appearance.</param>
        public CreateSignatureAppearanceForm(SignatureAppearanceGraphicsFigure signatureAppearance)
            : this()
        {
            _signatureAppearance = signatureAppearance;

            CodecsFileFilters.SetOpenFileDialogFilter(_openImageDialog);

            // create temp PDF document
            MemoryStream ms = new MemoryStream();
            using (PdfDocument tempDocument = new PdfDocument())
            {
                tempDocument.Pages.Add(_signatureAppearance.SignatureField.Annotation.Rectangle.Size);
                tempDocument.Save(ms);
            }
            signatureAppearanceEditor.Images.Add(ms, true);

            // use PdfContentEditorTool for editing the signature appearance
            PdfContentEditorTool editorTool = new PdfContentEditorTool();
            editorTool.RenderFiguresWhenImageIndexChanging = false;
            editorTool.FigureViewCollection.Add(GraphicsFigureViewFactory.CreateView(_signatureAppearance));
            signatureAppearanceEditor.VisualTool = editorTool;

            // update states of checkboxes
            backgroundNoneRadioButton.Checked = false;
            backgroundImageRadioButton.Checked = false;
            backgroundColorRadioButton.Checked = false;
            if (signatureAppearance.BackgroundImage != null)
                backgroundImageRadioButton.Checked = true;
            else if (signatureAppearance.BackgroundColor != Color.Transparent)
                backgroundColorRadioButton.Checked = true;
            else
                backgroundNoneRadioButton.Checked = true;

            if (signatureAppearance.SignatureImage != null)
                backgroundImageRadioButton.Checked = true;
            else if (signatureAppearance.ShowSignerName)
                signatureNameRadioButton.Checked = true;
            else
                signatureNoneRadioButton.Checked = true;

            // update signature text
            UpdateSignatureText(
                _signatureAppearance,
                nameCheckBox.Checked,
                reasonCheckBox.Checked,
                locationCheckBox.Checked,
                contactInfoCheckBox.Checked,
                dateCheckBox.Checked);            
        }

        #endregion



        #region Methods

        /// <summary>
        /// Sets the default signature appearance.
        /// </summary>
        /// <param name="signatureAppearance">The signature appearance figure.</param>
        public static void SetDefaultSignatureAppearance(
            SignatureAppearanceGraphicsFigure signatureAppearance)
        {
            signatureAppearance.SetDefaultLocations();
            UpdateSignatureText(signatureAppearance, true, true, true, true, true);
            signatureAppearance.DrawOnSignatureField();
        }


        /// <summary>
        /// Raizes event <see cref="E:System.Windows.Forms.Form.Closed" />.
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {
            // delete temp PDF document  
            signatureAppearanceEditor.Images.ClearAndDisposeItems();
        }


        /// <summary>
        /// Handles the Click event of the "OK" button.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                _signatureAppearance.DrawOnSignatureField();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of the "Cancel" button.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the Click event of the "backgroundImageRadioButton" button.
        /// </summary>
        private void backgroundImageRadioButton_Click(object sender, EventArgs e)
        {
            VintasoftImage image = null;
            if (SelectImage(out image))
            {
                _signatureAppearance.BackgroundColor = Color.Transparent;
                _signatureAppearance.BackgroundImage = image;
            }
        }

        /// <summary>
        /// Selects the image from file.
        /// </summary>
        /// <param name="image">Selected image.</param>
        /// <returns>
        /// <b>true</b> - image is selected;
        /// <b>false</b> - image is NOT selected.
        /// </returns>
        private bool SelectImage(out VintasoftImage image)
        {
            image = null;
            if (_openImageDialog.ShowDialog() == DialogResult.OK)
            {
                // select image from image collection
                image = SelectImageForm.SelectImageFromFile(_openImageDialog.FileName);

                // if the selected image is not null return true
                return image != null;
            }
            return false;
        }

        /// <summary>
        /// Handles the Click event of the "Background->Imported image" radio button.
        /// </summary>
        private void backgroundColorRadioButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = _signatureAppearance.BackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _signatureAppearance.BackgroundImage = null;
                _signatureAppearance.BackgroundColor = colorDialog.Color;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the "Background->None" radio button.
        /// </summary>
        private void backgroundNoneRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_signatureAppearance != null)
            {
                if (backgroundNoneRadioButton.Checked)
                {
                    _signatureAppearance.BackgroundImage = null;
                    _signatureAppearance.BackgroundColor = Color.Transparent;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the "Signature->Imported image" radio button.
        /// </summary>
        private void signatureImageRadioButton_Click(object sender, EventArgs e)
        {
            _signatureAppearance.ShowSignerName = false;
            VintasoftImage image = null;
            if (SelectImage(out image))
                _signatureAppearance.SignatureImage = image;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the "Signature->None" radio button.
        /// </summary>
        private void signatureNoneRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_signatureAppearance != null)
            {
                if (signatureNoneRadioButton.Checked)
                {
                    _signatureAppearance.ShowSignerName = false;
                    _signatureAppearance.SignatureImage = null;
                }
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the "Background->Name" radio button.
        /// </summary>
        private void signatureNameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_signatureAppearance != null)
            {
                if (signatureNameRadioButton.Checked)
                {
                    _signatureAppearance.ShowSignerName = true;
                    _signatureAppearance.SignatureImage = null;
                }
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the text boxes.
        /// </summary>
        private void textCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_signatureAppearance != null)
            {
                UpdateSignatureText(
                    _signatureAppearance,
                    nameCheckBox.Checked,
                    reasonCheckBox.Checked,
                    locationCheckBox.Checked,
                    contactInfoCheckBox.Checked,
                    dateCheckBox.Checked);
            }
        }

        /// <summary>
        /// Updates the signature text.
        /// </summary>
        /// <param name="signatureAppearance">The signature appearance.</param>
        /// <param name="addName">Indicates whether the signer name must be added
        /// to the signature text.</param>
        /// <param name="addReason">Indicates whether the signature reason must be added
        /// to the signature text.</param>
        /// <param name="addLocation">Indicates whether the signature location must be added
        /// to the signature text.</param>
        /// <param name="addContactInfo">Indicates whether the signer contact information must be added
        /// to the signature text.</param>
        /// <param name="addDate">Indicates whether the signature date must be added
        /// to the signature text.</param>
        private static void UpdateSignatureText(
            SignatureAppearanceGraphicsFigure signatureAppearance,
            bool addName,
            bool addReason,
            bool addLocation,
            bool addContactInfo,
            bool addDate)
        {
            StringBuilder text = new StringBuilder();
            PdfSignatureInformation signatureInfo = signatureAppearance.SignatureField.SignatureInfo;
            if (signatureInfo == null)
            {
                text.AppendLine("Empty Signature Field");                
            }
            else
            {
                if (addName && signatureInfo.SignerName != null)
                    text.AppendLine(string.Format("Digitally signed by {0}", signatureInfo.SignerName));
                if (addReason && signatureInfo.Reason != null)
                    text.AppendLine(string.Format("Reason: {0}", signatureInfo.Reason));
                if (addLocation && signatureInfo.Location != null)
                    text.AppendLine(string.Format("Location: {0}", signatureInfo.Location));
                if (addContactInfo && signatureInfo.ContactInfo != null)
                    text.AppendLine(string.Format("Contact: {0}", signatureInfo.ContactInfo));
                if (addDate && signatureInfo.SigningTime != DateTime.MinValue)
                    text.AppendLine(string.Format("Signing Date:\n{0}", signatureInfo.SigningTime.ToString("f", CultureInfo.InvariantCulture)));
            }

            if (text.Length > 0)
            {
                text.Remove(text.Length - 1, 1);
                signatureAppearance.Text = text.ToString();
            }
            else
            {
                signatureAppearance.Text = null;
            }

            signatureAppearance.UpdateSignerName();
        }

        #endregion

    }
}
