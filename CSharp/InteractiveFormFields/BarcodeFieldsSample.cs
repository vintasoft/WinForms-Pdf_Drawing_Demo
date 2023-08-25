using System;
using System.Drawing;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Drawing;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Fonts;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;

#if !REMOVE_BARCODE_SDK
using Vintasoft.Barcode;
#endif

namespace PdfDrawingDemo
{
    /// <summary>
    /// Samples of the interactive form barcode fields.
    /// </summary>
    public class BarcodeFieldsSample : InteractiveFormFieldsSample
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeFieldsSample"/> class.
        /// </summary>
        /// <param name="page">The PDF page.</param>
        /// <param name="graphics">The PDF graphics.</param>
        /// <param name="fontSize">The font size.</param>
        /// <param name="showLogo">Indicates whether to show the logo image.</param>
        /// <exception cref="NotSupportedException">Unsupported VintaSoft Barcode .NET SDK Package.</exception>
        public BarcodeFieldsSample(PdfPage page, PdfGraphics graphics, float fontSize, bool showLogo)
            : base(
            page,
            "class PdfInteractiveFormBarcodeField",
            graphics,
            fontSize,
            70,
            showLogo)
        {
#if !REMOVE_BARCODE_SDK
            if ((BarcodeGlobalSettings.SDKPackage & SDKPackage.Writer1D) == 0 ||
                (BarcodeGlobalSettings.SDKPackage & SDKPackage.Writer2D) == 0)
                throw new NotSupportedException("Unsupported VintaSoft Barcode .NET SDK Package.");
#endif
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

#if !REMOVE_BARCODE_SDK
            document.InteractiveForm.NeedAppearances = false;
            document.InteractiveForm.CalculationOrder = new PdfInteractiveFormFieldList(document);

            // calculate action of barcode value
            PdfJavaScriptAction calculateValueAction = new PdfJavaScriptAction(document,
                @"event.value = this.getField('TextField1').value;");


            #region TextField1

            // add table row with information about field
            RectangleF fieldCellDrawingBox = AddTableRow(
                "TextField1: The barcode value. Write barcode value and press 'Enter'.\n",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create text field
            PdfInteractiveFormTextField textField1 = new PdfInteractiveFormTextField(
                document, "TextField1", fieldCellDrawingBox);
            textField1.TextValue = "test barcode value";
            textField1.DefaultValue = textField1.Value;
            // set the text default appearance
            textField1.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // add field to PDF document
            AddFieldToPdfDocument(document, textField1);

            #endregion


            #region barcodeField_PDF417

            // add table row with information about field
            fieldCellDrawingBox = AddTableRow(
                "barcodeField_PDF417: PDF417 Barcode Field. \n\n\n\n\n\n\n\n\n",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create PDF417 barcode field
            PdfInteractiveFormBarcodeField barcodeField_PDF417 = new PdfInteractiveFormBarcodeField(
                document, "barcodeField_PDF417", BarcodeSymbologyType.PDF417, fieldCellDrawingBox);

            // set barcode value
            barcodeField_PDF417.Value = textField1.Value;

            // set PDF417 error correction coefficient to Level4
            barcodeField_PDF417.ErrorCorrectionCoefficient = 4;

            // set the single module width to 0.017 inch
            barcodeField_PDF417.ModuleWidth = 0.017f;

            // add the barcode field to the calculated fields (calcualtion order) 
            // of the document interactive form fields
            barcodeField_PDF417.AdditionalActions = new PdfInteractiveFormFieldAdditionalActions(document);
            barcodeField_PDF417.AdditionalActions.Calculate = calculateValueAction;
            document.InteractiveForm.CalculationOrder.Add(barcodeField_PDF417);

            // add field to PDF document
            AddFieldToPdfDocument(document, barcodeField_PDF417);

            #endregion


            #region barcodeField_QRCode

            // add table row with information about field
            fieldCellDrawingBox = AddTableRow(
                "barcodeField_QRCode: QR Code Barcode Field. \n\n\n\n\n\n\n\n\n",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create QR code barcode field
            PdfInteractiveFormBarcodeField barcodeField_QRCode = new PdfInteractiveFormBarcodeField(
                document, "barcodeField_QRCode", BarcodeSymbologyType.QRCode, fieldCellDrawingBox);

            // set barcode value
            barcodeField_QRCode.Value = textField1.Value;

            // set QRCode error correction coefficient to 'Q'
            barcodeField_QRCode.ErrorCorrectionCoefficient = 2;
            
            // set the single module width to 0.025 inch
            barcodeField_QRCode.ModuleWidth = 0.025f;

            // add the barcode field to the calculated fields (calcualtion order) 
            // of the document interactive form fields
            barcodeField_QRCode.AdditionalActions = new PdfInteractiveFormFieldAdditionalActions(document);
            barcodeField_QRCode.AdditionalActions.Calculate = calculateValueAction;
            document.InteractiveForm.CalculationOrder.Add(barcodeField_QRCode);

            // add field to PDF document
            AddFieldToPdfDocument(document, barcodeField_QRCode);

            #endregion


            #region barcodeField_DataMatrix

            // add table row with information about field
            fieldCellDrawingBox = AddTableRow(
                "barcodeField_DataMatrix: DataMatrix Barcode Field. \n\n\n\n\n\n\n\n\n",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create DataMatrix barcode field
            PdfInteractiveFormBarcodeField barcodeField_DataMatrix = new PdfInteractiveFormBarcodeField(
                document, "barcodeField_DataMatrix", BarcodeSymbologyType.DataMatrix, fieldCellDrawingBox);

            // set barcode value
            barcodeField_DataMatrix.Value = textField1.Value;

            // set the single module width to 0.025 inch
            barcodeField_DataMatrix.ModuleWidth = 0.025f;

            // add the barcode field to the calculated fields (calcualtion order) 
            // of the document interactive form fields
            barcodeField_DataMatrix.AdditionalActions = new PdfInteractiveFormFieldAdditionalActions(document);
            barcodeField_DataMatrix.AdditionalActions.Calculate = calculateValueAction;
            document.InteractiveForm.CalculationOrder.Add(barcodeField_DataMatrix);

            // add field to PDF document
            AddFieldToPdfDocument(document, barcodeField_DataMatrix);

            #endregion
#endif
        }

        #endregion

    }
}
