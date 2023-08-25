using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Drawing;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.DigitalSignatures;
using Vintasoft.Imaging.Pdf.Tree.Fonts;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;

using DemosCommonCode;
using DemosCommonCode.Pdf.Security;


namespace PdfDrawingDemo
{
    /// <summary>
    /// Represents a sample of interactive form signature fields.
    /// </summary>
    public class SignatureFieldsSample : InteractiveFormFieldsSample
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureFieldsSample"/> class.
        /// </summary>
        /// <param name="page">The PDF page.</param>
        /// <param name="graphics">The graphics.</param>
        /// <param name="fontSize">The font size.</param>
        /// <param name="showLogo">Indicates whether to show the logo image.</param>
        public SignatureFieldsSample(PdfPage page, PdfGraphics graphics, float fontSize, bool showLogo)
            : base(
            page,
            "class PdfInteractiveFormSignatureField",
            graphics,
            fontSize,
            70,
            showLogo)
        {
        }

        #endregion



        #region Methods

        /// <summary>
        /// Adds content to the report page.
        /// </summary>
        /// <param name="document">The PDF document.</param>
        /// <param name="graphics">The PDF graphics.</param>
        /// <param name="textBoxFactory">The text box factory.</param>
        /// <param name="font">The text font.</param>
        /// <param name="fontSize">The font size.</param>
        /// <param name="tablePen">The table pen.</param>
        /// <param name="firstColPercent">The first column size in percents.</param>
        protected override void AddContent(
            PdfDocument document,
            PdfGraphics graphics,
            TextBoxFactory textBoxFactory,
            PdfFont font,
            float fontSize,
            PdfPen tablePen,
            float firstColPercent)
        {
            document.InteractiveForm.NeedAppearances = false;
            document.InteractiveForm.SignatureFlags =
                PdfDocumentSignatureFlags.AppendOnly | PdfDocumentSignatureFlags.SignaturesExist;

            // select X509 certificate with public key
            X509Certificate2 certificate = SelectCertificate();


            #region Signature1

            // create string with information about used certificate
            string description = "Signature1: Signature field signing use PKCS#7 signature.";

            // if the test certificate (PDFDrawingDemo\\Resources\\TestCertificate.pfx) is used
            if (certificate != null && certificate.Issuer == "CN=PdfDrawingDemo Test")
            {
                description += "\nTest certificate with private key 'TestCertificate.pfx' is used.\nTo validate this signature you have to add the certificate from file 'PDFDrawingDemo\\Resources\\TestCertificate.pfx' to the list of Trusted Identities (see https://www.vintasoft.com/docs/vsimaging-dotnet/).";
            }
            else
            {
                description += "\n\n\n\n";
            }

            // add table row with information about field
            RectangleF cellDrawingBox = AddTableRow(description,
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create signature field
            PdfInteractiveFormSignatureField signatureField =
                new PdfInteractiveFormSignatureField(document, "Signature1", cellDrawingBox);

            // if the certificate is selected
            if (certificate != null)
            {
                try
                {
                    // create PDF PKCS#7 signature
                    PdfPkcsSignature signature = PdfPkcsSignature.CreatePkcs7Signature(certificate);
                    // cerate signature info
                    signatureField.SignatureInfo = new PdfSignatureInformation(document, signature);
                    signatureField.SignatureInfo.SigningTime = DateTime.Now;
                    signatureField.SignatureInfo.Location = CultureInfo.CurrentCulture.EnglishName;
                    signatureField.SignatureInfo.ContactInfo = "www.vintasoft.com";
                    signatureField.SignatureInfo.Reason = "PdfDrawingDemo Test Signature";
                    signatureField.SignatureInfo.SignerName = certificate.GetNameInfo(X509NameType.SimpleName, false);
                }
                catch (Exception exc)
                {
                    DemosTools.ShowErrorMessage(exc);
                }
            }

            // define the signature appearance
            SignatureAppearanceGraphicsFigure signatureAppearance = new SignatureAppearanceGraphicsFigure();
            signatureAppearance.SignatureField = signatureField;
            signatureAppearance.ShowSignerName = false;
            CreateSignatureAppearanceForm.SetDefaultSignatureAppearance(signatureAppearance);

            // add signature to PDF document
            AddFieldToPdfDocument(document, signatureField);

            #endregion


            #region Empty Signature2

            // add table row with information about field
            cellDrawingBox = AddTableRow(
                "Signature2: Empty signature field.",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create signature field
            PdfInteractiveFormSignatureField signatureField2 =
                new PdfInteractiveFormSignatureField(document, "Signature2", cellDrawingBox);

            // define the siganture appearance
            using (PdfGraphics g = signatureField2.CreateAppearanceGraphics())
            {
                RectangleF appearanceRect = signatureField2.Annotation.Rectangle;
                appearanceRect.X = 0;
                appearanceRect.Y = 0;
                g.SaveGraphicsState();
                g.DrawRectangle(new PdfPen(Color.LightGray, 2), appearanceRect);
                g.DrawString("Empty Signature Field", font, fontSize, new PdfBrush(Color.Gray), appearanceRect, PdfContentAlignment.Center, false);
                g.RestoreGraphicsState();
            }

            // add signature to PDF document
            AddFieldToPdfDocument(document, signatureField2);

            #endregion

        }


        /// <summary>
        /// Returns the certificate for new interactive form field.
        /// </summary>
        /// <returns>The certificate for new interactive form field.</returns>
        private X509Certificate2 SelectCertificate()
        {
            // create a reference to the certificate store with personal certificates
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            // open certificate store with personal certificates
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            // create collection with certificates from the certificate store with personal certificates
            X509Certificate2Collection certificates = new X509Certificate2Collection(store.Certificates);

            // open file 'PDFDrawingDemo\\Resources\\TestCertificate.pfx' with test certificate
            using (Stream stream = DemosResourcesManager.GetResourceAsStream("TestCertificate.pfx"))
            {
                // load test certificate into memory
                byte[] bytes = new byte[(int)stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                // add test certificate to the certificate collection
                certificates.Add(new X509Certificate2(bytes, "test"));
            }

            // show form that display certificates from certificate collection AND
            // allows to select certificate
            SelectCertificateForm dialog = new SelectCertificateForm(certificates);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // if the certificate does NOT have private key
                if (!dialog.SelectedCertificate.HasPrivateKey)
                {
                    // show error message
                    DemosTools.ShowErrorMessage("Certificate does not have private key.");
                }
                else
                {
                    // return certificate
                    return dialog.SelectedCertificate;
                }
            }

            return null;
        }

        #endregion

    }
}
