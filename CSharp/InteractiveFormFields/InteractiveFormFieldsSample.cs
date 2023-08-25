using System.Drawing;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Drawing;
using Vintasoft.Imaging.Pdf.Drawing.GraphicsFigures;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Annotations;
using Vintasoft.Imaging.Pdf.Tree.Fonts;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;

namespace PdfDrawingDemo
{
    /// <summary>
    /// Provides an abstract base class for various samples of the interactive form fields.
    /// </summary>
    public abstract class InteractiveFormFieldsSample : ReportTemplate
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InteractiveFormFieldsSample"/> class.
        /// </summary>
        /// <param name="page">The PDF page.</param>
        /// <param name="name">The report name.</param>
        /// <param name="graphics">The graphics.</param>
        /// <param name="fontSize">The font size.</param>
        /// <param name="firstColPercent">The first column size in percents.</param>
        /// <param name="showLogo">Indicates whether to show the logo image.</param>
        public InteractiveFormFieldsSample(
            PdfPage page,
            string name,
            PdfGraphics graphics,
            float fontSize,
            float firstColPercent,
            bool showLogo)
            : base(
            page,
            page.Document.FontManager.GetStandardFont(PdfStandardFontType.Helvetica),
            fontSize * 2,
            name,
            showLogo)
        {
            PdfDocument document = page.Document;
            document.InteractiveForm = new PdfDocumentInteractiveForm(document);
            document.InteractiveForm.NeedAppearances = true;
            if (page.Annotations == null)
                page.Annotations = new PdfAnnotationList(document);

            Body.Orientation = PdfContentOrientation.Vertical;

            // set header size in percents
            Header.ElementSizeMode = PdfContentSizeMode.Percent;
            Header.ElementSize = 10;

            // set footer size in percents
            Footer.ElementSizeMode = PdfContentSizeMode.Percent;
            Footer.ElementSize = 10;

            PdfBrush headRowBrush = new PdfBrush(Color.LightGray);
            PdfBrush blackBrush = new PdfBrush(Color.Black);
            PdfPen tablePen = new PdfPen(Color.Black, 1f);
            PdfPen boldTablePen = new PdfPen(Color.Black, 2f);
            PdfFont timesRomanFont = document.FontManager.GetStandardFont(PdfStandardFontType.TimesRoman);

            TextBoxFigure sourceTextBox = new TextBoxFigure(blackBrush, "", timesRomanFont, fontSize, PdfContentAlignment.Center);
            TextBoxFactory textBoxFactory = new TextBoxFactory(sourceTextBox);

            AlignmentPanel row;
            AlignmentPanelElement cell;

            // header row
            //row = new AlignmentPanel(PdfContentSizeMode.Fixed, fontSize * 4);
            //cell = new AlignmentPanelElement(PdfContentSizeMode.Fill);
            //cell.Content = textBoxFactory.Create("", fontSize * 1.5f);
            //row.Add(cell);
            //Body.Add(row);

            row = new AlignmentPanel(PdfContentSizeMode.Fixed, fontSize * 2);
            row.Brush = headRowBrush;

            cell = new AlignmentPanelElement(PdfContentSizeMode.Percent, firstColPercent);
            cell.Pen = tablePen;
            cell.Content = textBoxFactory.Create("Description");
            row.Add(cell);

            cell = new AlignmentPanelElement();
            cell.Pen = tablePen;
            cell.Content = textBoxFactory.Create("Interactive Form Field Sample");
            row.Add(cell);

            Body.Add(row);

            sourceTextBox.TextAlignment = PdfContentAlignment.Left | PdfContentAlignment.Top;
            sourceTextBox.AutoHeight = true;
            sourceTextBox.Margin = new PdfContentPadding(fontSize);

            AddContent(document, graphics, textBoxFactory, timesRomanFont, fontSize, tablePen, firstColPercent);
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
        protected abstract void AddContent(
            PdfDocument document,
            PdfGraphics graphics,
            TextBoxFactory textBoxFactory,
            PdfFont font,
            float fontSize,
            PdfPen tablePen,
            float firstColPercent);

        /// <summary>
        /// Adds one row to the table.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="graphics">The PDF graphics.</param>
        /// <param name="firstColPercent">The first column size in percents.</param>
        /// <param name="tablePen">The table pen.</param>
        /// <param name="textBoxFactory">The text box factory.</param>
        /// <param name="fontSize">The font size.</param>
        /// <returns>Content cell bounding box.</returns>
        protected RectangleF AddTableRow(
            string description,
            PdfGraphics graphics,
            float firstColPercent,
            PdfPen tablePen,
            TextBoxFactory textBoxFactory,
            float fontSize)
        {
            // create table row
            AlignmentPanel row = new AlignmentPanel(PdfContentSizeMode.Auto);
            row.AutoHeight = true;
            row.Orientation = PdfContentOrientation.Horizontal;

            // description cell
            AlignmentPanelElement cell = new AlignmentPanelElement(PdfContentSizeMode.Percent, firstColPercent);
            cell.AutoHeight = true;
            cell.Pen = tablePen;
            cell.Content = textBoxFactory.Create(description);
            row.Add(cell);

            // content cell
            cell = new AlignmentPanelElement(PdfContentSizeMode.Fill);
            cell.Pen = tablePen;
            row.Add(cell);

            // add row to body
            Body.Add(row);

            // refresh table properties
            RefreshProperties(graphics);

            // returns content cell drawing box
            RectangleF cellDrawingBox = cell.GetDrawingBox();
            cellDrawingBox.Inflate(-fontSize, -fontSize);
            return cellDrawingBox;
        }

        /// <summary>
        /// Adds an interactive field to PDF document.
        /// </summary>
        /// <param name="document">The PDF document.</param>
        /// <param name="field">The field.</param>
        protected void AddFieldToPdfDocument(PdfDocument document, PdfInteractiveFormField field)
        {
            AddFieldToPdfDocument(document, field, true);
        }

        /// <summary>
        /// Adds an interactive field to PDF document.
        /// </summary>
        /// <param name="document">The PDF document.</param>
        /// <param name="field">The field.</param>
        /// <param name="updateAppearance">Indicates whether to update field appearance.</param>
        protected void AddFieldToPdfDocument(PdfDocument document, PdfInteractiveFormField field, bool updateAppearance)
        {
            // add field to an interactive form of PDF document
            document.InteractiveForm.Fields.Add(field);
            // add field annotation to PDF page
            document.Pages[0].Annotations.Add(field.Annotation);

            if (updateAppearance)
            {
                // update field appearance
                field.UpdateAppearance();
            }
        }

        /// <summary>
        /// Adds a group of interactive fields to PDF document.
        /// </summary>
        /// <param name="document">The PDF document.</param>
        /// <param name="fieldGroup">The field group.</param>
        protected void AddFieldGroupToPdfDocument(PdfDocument document, PdfInteractiveFormField fieldGroup)
        {
            // add field to an interactive form of PDF document
            document.InteractiveForm.Fields.Add(fieldGroup);
            // add field annotation to PDF page
            document.Pages[0].Annotations.AddRange(fieldGroup.GetAnnotations());

            // update field appearance
            fieldGroup.UpdateAppearance();
        }

        #endregion

    }
}
