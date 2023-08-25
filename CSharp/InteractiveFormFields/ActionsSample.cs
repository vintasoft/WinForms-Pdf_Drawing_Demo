using System.Drawing;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Drawing;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Annotations;
using Vintasoft.Imaging.Pdf.Tree.Fonts;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;

namespace PdfDrawingDemo
{
    /// <summary>
    /// Samples of the interactive form push button fields.
    /// </summary>
    public class ActionsSample : InteractiveFormFieldsSample
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionsSample"/> class.
        /// </summary>
        /// <param name="page">The PDF page.</param>
        /// <param name="graphics">The PDF graphics.</param>
        /// <param name="fontSize">The font size.</param>
        /// <param name="showLogo">Indicates whether to show the logo image.</param>
        public ActionsSample(PdfPage page, PdfGraphics graphics, float fontSize, bool showLogo)
            : base(
            page,
            "Actions",
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
            PdfInteractiveFormPushButtonField button;
            PdfPage destPage = document.Pages[1];

            #region GotoAction

            PdfGotoAction gotoAction;
            // GotoAction: Fit
            button = CreateButton(
                document, graphics, textBoxFactory, font, fontSize, tablePen, firstColPercent,
                "GotoAction (Fit): Executes Goto Action (PdfGotoAction) use Fit Destination (PdfDestinationFit).",
                "GotoAction (Fit)");
            gotoAction = new PdfGotoAction(new PdfDestinationFit(document, destPage));
            button.Annotation.ActivateAction = gotoAction;

            // GotoAction: FitHorizontal
            button = CreateButton(
                document, graphics, textBoxFactory, font, fontSize, tablePen, firstColPercent,
                "GotoAction (FitHorizontal): Executes Goto Action (PdfGotoAction) use Fit Horizontal (PdfDestinationFitHorizontal).",
                "GotoAction (FitHorizontal)");
            gotoAction = new PdfGotoAction(new PdfDestinationFitHorizontal(document, destPage));
            button.Annotation.ActivateAction = gotoAction;

            // GotoAction: FitVertical
            button = CreateButton(
                document, graphics, textBoxFactory, font, fontSize, tablePen, firstColPercent,
                "GotoAction (FitVertical): Executes Goto Action (PdfGotoAction) use Fit Vertical (PdfDestinationFitVertical).",
                "GotoAction (FitVertical)");
            gotoAction = new PdfGotoAction(new PdfDestinationFitVertical(document, destPage));
            button.Annotation.ActivateAction = gotoAction;

            // GotoAction: FitRectangle
            RectangleF testRect = new RectangleF(200, 500, 300, 150);
            using (PdfGraphics g = PdfGraphics.FromPage(destPage))
            {
                g.DrawString(testRect.ToString(), font, 12, new PdfBrush(Color.Black), testRect, PdfContentAlignment.Center, false);
                g.DrawRectangle(new PdfPen(Color.Green), testRect);
                g.FillEllipse(new PdfBrush(Color.Red), testRect.X - 5, testRect.Y - 5, 10, 10);
            }
            button = CreateButton(
               document, graphics, textBoxFactory, font, fontSize, tablePen, firstColPercent,
               "GotoAction (FitRectangle): Executes Goto Action (PdfGotoAction) use Fit Rectangle (PdfDestinationFitRectangle).",
               "GotoAction (FitRectangle)");
            gotoAction = new PdfGotoAction(new PdfDestinationFitRectangle(document, destPage, testRect));
            button.Annotation.ActivateAction = gotoAction;

            // GotoAction: XYZoom:
            button = CreateButton(
                document, graphics, textBoxFactory, font, fontSize, tablePen, firstColPercent,
                string.Format("GotoAction (XYZ): Executes Goto Action (PdfGotoAction) use Fit XYZ (PdfDestinationXYZ) X={0}, Y={1}, Zoom=2.5X", testRect.X, testRect.Y),
                "GotoAction (XYZ)");
            gotoAction = new PdfGotoAction(new PdfDestinationXYZ(document, destPage, testRect.Location, 2.5f));
            button.Annotation.ActivateAction = gotoAction;

            #endregion


            #region URI action

            button = CreateButton(
                document, graphics, textBoxFactory, font, fontSize, tablePen, firstColPercent,
                "URI Action: Executes URI Action (PdfUriAction).\n",
                "URI Action");
            button.Annotation.ActivateAction = new PdfUriAction(document, "https://www.vintasoft.com"); ;

            #endregion


            #region Launch action

            button = CreateButton(
                document, graphics, textBoxFactory, font, fontSize, tablePen, firstColPercent,
                "Launch Action: Executes Launch Action (PdfLaunchAction).\n",
                "Launch Action");
            button.Annotation.ActivateAction = new PdfLaunchAction(document, "notepad.exe");

            #endregion


            #region JavaScript Action

            button = CreateButton(
                document, graphics, textBoxFactory, font, fontSize, tablePen, firstColPercent,
                "JavaScript Action: Executes an JavaScript (PdfJavaScriptAction).\n",
                "JavaScript Action");
            button.Annotation.ActivateAction =
                new PdfJavaScriptAction(document, "app.alert({cTitle:'JavaScript sample', cMsg:'Document contains '+this.numFields+' fields.', nIcon:3});");

            #endregion


            #region AnnotationHide Action

            PdfAnnotationHideAction annotationHideAction;
            button = CreateButton(
                document, graphics, textBoxFactory, font, fontSize, tablePen, firstColPercent,
                "AnnotationHide Action: Hides an annotation of this button.\n",
                "Hide Annotation");
            annotationHideAction = new PdfAnnotationHideAction(true, button.Annotation);
            button.Annotation.ActivateAction = annotationHideAction;

            annotationHideAction = new PdfAnnotationHideAction(false, button.Annotation);
            button = CreateButton(
                document, graphics, textBoxFactory, font, fontSize, tablePen, firstColPercent,
                "AnnotationHide Action: Shows an annotation of previous button.\n",
                "Show Annotation");
            button.Annotation.ActivateAction = annotationHideAction;

            #endregion


            #region SubmitActions

            #region TextField1 - Single line text field

            // add table row with information about field
            RectangleF fieldCellDrawingBox = AddTableRow(
                "TextField1: Single line text field that uses to test Submit actions.\n",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create text field
            PdfInteractiveFormTextField textField1 = new PdfInteractiveFormTextField(document, "TextField1", fieldCellDrawingBox);
            textField1.Value = new PdfInteractiveFormTextFieldStringValue(document, "text string");
            textField1.DefaultValue = textField1.Value;
            textField1.TextQuadding = TextQuaddingType.Centered;

            // set the text default appearance
            textField1.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // add field to PDF document
            AddFieldToPdfDocument(document, textField1);

            #endregion


            string submitUrl = "http://localhost/TestPdfSubmit.ashx";
            PdfSubmitFormAction submitFormAction;

            // XFDF
            button = CreateButton(
                document, graphics, textBoxFactory, font, fontSize, tablePen, firstColPercent,
                "Submit Form Action: Sumbmit form in XFDF format.\n",
                "Submit XFDF");
            submitFormAction = new PdfSubmitFormAction(document);
            submitFormAction.SubmitFormat = PdfInteractiveFormFieldSubmitFormat.XFDF;
            submitFormAction.Url = submitUrl;
            button.Annotation.ActivateAction = submitFormAction;

            // PDF
            button = CreateButton(
                document, graphics, textBoxFactory, font, fontSize, tablePen, firstColPercent,
                "Submit Form Action: Sumbmit form in PDF format.\n",
                "Submit PDF");
            submitFormAction = new PdfSubmitFormAction(document);
            submitFormAction.SubmitFormat = PdfInteractiveFormFieldSubmitFormat.PDF;
            submitFormAction.Url = submitUrl;
            button.Annotation.ActivateAction = submitFormAction;

            // FDF
            button = CreateButton(
                document, graphics, textBoxFactory, font, fontSize, tablePen, firstColPercent,
                "Submit Form Action: Sumbmit form in FDF format.\n",
                "Submit FDF");
            submitFormAction = new PdfSubmitFormAction(document);
            submitFormAction.SubmitFormat = PdfInteractiveFormFieldSubmitFormat.FDF;
            submitFormAction.Url = submitUrl;
            button.Annotation.ActivateAction = submitFormAction;

            // HTML
            button = CreateButton(
                document, graphics, textBoxFactory, font, fontSize, tablePen, firstColPercent,
                "Submit Form Action: Sumbmit form in HTML format.\n",
                "Submit HTML");
            submitFormAction = new PdfSubmitFormAction(document);
            submitFormAction.SubmitFormat = PdfInteractiveFormFieldSubmitFormat.HTML;
            submitFormAction.Url = submitUrl;
            button.Annotation.ActivateAction = submitFormAction;

            #endregion


            #region Named Action

            button = CreateButton(
                document, graphics, textBoxFactory, font, fontSize, tablePen, firstColPercent,
                "Named Action: Executes 'NextPage' viewer action (PdfNamedAction).\n",
                "NextPage");
            button.Annotation.ActivateAction = new PdfNamedAction(document, "NextPage");

            #endregion

        }


        /// <summary>
        /// Creates the button.
        /// </summary>
        /// <param name="document">The PDF document.</param>
        /// <param name="graphics">The PDF graphics.</param>
        /// <param name="textBoxFactory">The text box factory.</param>
        /// <param name="font">The font.</param>
        /// <param name="fontSize">The font size.</param>
        /// <param name="tablePen">The table pen.</param>
        /// <param name="firstColPercent">The first column size in percents.</param>
        /// <param name="description">The description.</param>
        /// <param name="name">The button name.</param>
        /// <returns>Interactive form field that defines push button.</returns>
        private PdfInteractiveFormPushButtonField CreateButton(PdfDocument document, PdfGraphics graphics, TextBoxFactory textBoxFactory, PdfFont font, float fontSize, PdfPen tablePen, float firstColPercent, string description, string name)
        {
            // add table row with information about button
            RectangleF fieldCellDrawingBox = AddTableRow(description, graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create a button
            PdfInteractiveFormPushButtonField button = new PdfInteractiveFormPushButtonField(document, name, fieldCellDrawingBox);
            // set the border style
            button.Annotation.BorderStyleType = PdfAnnotationBorderStyleType.Beveled;
            button.Annotation.BorderWidth = 1;
            // set the appearance characteristics
            button.Annotation.HighlightingMode = PdfAnnotationHighlightingMode.Push;
            button.Annotation.AppearanceCharacteristics = new PdfAnnotationAppearanceCharacteristics(document);
            button.Annotation.AppearanceCharacteristics.BackgroundColor = Color.LightGray;
            button.Annotation.AppearanceCharacteristics.ButtonNormalCaption = name;
            // set the text default appearance
            button.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // add button to PDF document
            AddFieldToPdfDocument(document, button);

            return button;
        }

        #endregion

    }
}
