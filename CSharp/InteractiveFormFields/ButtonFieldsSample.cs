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
    public class ButtonFieldsSample : InteractiveFormFieldsSample
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonFieldsSample"/> class.
        /// </summary>
        /// <param name="page">The PDF page.</param>
        /// <param name="graphics">The PDF graphics.</param>
        /// <param name="fontSize">The font size.</param>
        /// <param name="showLogo">The first column size in percents.</param>
        public ButtonFieldsSample(PdfPage page, PdfGraphics graphics, float fontSize, bool showLogo)
            : base(
            page,
            "class PdfInteractiveFormPushButtonField",
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

            #region Button1 - Button with dynamic appearance

            // add table row with information about button
            RectangleF fieldCellDrawingBox = AddTableRow(
                "Button1: Button with dynamic appearance (border style; text default appearance; normal caption). Button appearance is generated dynamically by the viewer application.",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create a button
            PdfInteractiveFormPushButtonField button1 = new PdfInteractiveFormPushButtonField(document, "Button1", fieldCellDrawingBox);
            // set the border style
            button1.Annotation.BorderStyleType = PdfAnnotationBorderStyleType.Beveled;
            button1.Annotation.BorderWidth = 1;
            // set the appearance characteristics
            button1.Annotation.AppearanceCharacteristics = new PdfAnnotationAppearanceCharacteristics(document);
            button1.Annotation.AppearanceCharacteristics.BackgroundColor = Color.LightGray;
            button1.Annotation.AppearanceCharacteristics.ButtonNormalCaption = "Button1";
            // set the text default appearance
            button1.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // add button to PDF document
            AddFieldToPdfDocument(document, button1, false);

            #endregion


            #region Button2 - Button with dynamic appearance

            // add table row with information about button
            fieldCellDrawingBox = AddTableRow(
                "Button2: Button with dynamic appearance (border style; text default appearance; normal, down and rollover caption). Button appearance is generated dynamically by the viewer application.",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create a button
            PdfInteractiveFormPushButtonField button2 = new PdfInteractiveFormPushButtonField(document, "Button2", fieldCellDrawingBox);
            // sets border style
            button2.Annotation.BorderStyleType = PdfAnnotationBorderStyleType.Beveled;
            button2.Annotation.BorderWidth = 1;
            // set the appearance characteristics
            button2.Annotation.AppearanceCharacteristics = new PdfAnnotationAppearanceCharacteristics(document);
            button2.Annotation.HighlightingMode = PdfAnnotationHighlightingMode.Push;
            button2.Annotation.AppearanceCharacteristics.BackgroundColor = Color.LightGray;
            button2.Annotation.AppearanceCharacteristics.ButtonNormalCaption = "Button2 (Normal)";
            button2.Annotation.AppearanceCharacteristics.ButtonDownCaption = "Button2 (Down)";
            button2.Annotation.AppearanceCharacteristics.ButtonRolloverCaption = "Button2 (Rollover)";
            // set the text default appearance
            button2.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // add button to PDF document
            AddFieldToPdfDocument(document, button2, false);

            #endregion


            #region Button3 - Button with custom appearance

            // add table row with information about button
            fieldCellDrawingBox = AddTableRow(
                "Button3: Button with custom normal appearance defined using PDF graphical commands (normal appearance only).",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create button
            PdfInteractiveFormPushButtonField button3 = new PdfInteractiveFormPushButtonField(document, "Button3", fieldCellDrawingBox);
            // create "Normal" appearance
            using (PdfGraphics g = button3.CreateAppearanceGraphics())
            {
                RectangleF appearanceRect = button3.Annotation.Rectangle;
                appearanceRect.X = 0;
                appearanceRect.Y = 0;
                g.SaveGraphicsState();
                g.FillRectangle(new PdfBrush(Color.LightGray), appearanceRect);
                g.DrawRectangle(new PdfPen(Color.Black, 2), appearanceRect);
                g.DrawString("Button3", font, fontSize, new PdfBrush(Color.Black), appearanceRect, PdfContentAlignment.Center, false);
                g.RestoreGraphicsState();
            }

            // add button to PDF document
            AddFieldToPdfDocument(document, button3, false);

            #endregion


            #region Button4 - Button with custom appearances

            // add table row with information about button
            fieldCellDrawingBox = AddTableRow(
                "Button 4: Button with custom normal, rollover and down appearances defined using PDF graphical commands.",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create button
            PdfInteractiveFormPushButtonField button4 = new PdfInteractiveFormPushButtonField(document, "Button4", fieldCellDrawingBox);
            // set the highlighting mode
            button4.Annotation.HighlightingMode = PdfAnnotationHighlightingMode.Push;
            // create "Normal" appearance
            using (PdfGraphics g = button4.Annotation.CreateNormalAppearanceGraphics())
            {
                RectangleF appearanceRect = button4.Annotation.Rectangle;
                appearanceRect.X = 0;
                appearanceRect.Y = 0;
                g.SaveGraphicsState();
                g.FillRectangle(new PdfBrush(Color.LightGray), appearanceRect);
                g.DrawRectangle(new PdfPen(Color.Black, 2), appearanceRect);
                g.DrawString("Button4 (Normal)", font, fontSize, new PdfBrush(Color.Black), appearanceRect, PdfContentAlignment.Center, false);
                g.RestoreGraphicsState();
            }
            // create "Rollover" appearance
            using (PdfGraphics g = button4.Annotation.CreateRolloverAppearanceGraphics())
            {
                RectangleF appearanceRect = button4.Annotation.Rectangle;
                appearanceRect.X = 0;
                appearanceRect.Y = 0;
                g.SaveGraphicsState();
                g.FillRectangle(new PdfBrush(Color.Gray), appearanceRect);
                g.DrawRectangle(new PdfPen(Color.Black, 2), appearanceRect);
                g.DrawString("Button4 (Rollover)", font, fontSize, new PdfBrush(Color.LightGreen), appearanceRect, PdfContentAlignment.Center, false);
                g.RestoreGraphicsState();
            }
            // create "Down" appearance
            using (PdfGraphics g = button4.Annotation.CreateDownAppearanceGraphics())
            {
                RectangleF appearanceRect = button4.Annotation.Rectangle;
                appearanceRect.X = 0;
                appearanceRect.Y = 0;
                g.SaveGraphicsState();
                g.FillRectangle(new PdfBrush(Color.Gray), appearanceRect);
                g.DrawRectangle(new PdfPen(Color.Black, 2), appearanceRect);
                g.DrawString("Button4 (Down)", font, fontSize, new PdfBrush(Color.Red), appearanceRect, PdfContentAlignment.Center, false);
                g.RestoreGraphicsState();
            }

            // add button to PDF document
            AddFieldToPdfDocument(document, button4, false);

            #endregion


            #region Button5 - Button with the Activate action

            // add table row with information about button
            fieldCellDrawingBox = AddTableRow(
                "Button5: Button with the Activate action specified by JavaScript code. Action supports the following action types: PdfGotoAction, PdfLaunchAction, PdfUriAction, PdfSubmitFormAction, PdfResetFormAction, PdfInteractiveFormImportDataAction, PdfJavaScriptAction.",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create button
            PdfInteractiveFormPushButtonField button5 = new PdfInteractiveFormPushButtonField(document, "Button5", fieldCellDrawingBox);
            // set the border style
            button5.Annotation.BorderStyleType = PdfAnnotationBorderStyleType.Beveled;
            button5.Annotation.BorderWidth = 1;
            // set the appearance characteristics
            button5.Annotation.AppearanceCharacteristics = new PdfAnnotationAppearanceCharacteristics(document);
            button5.Annotation.AppearanceCharacteristics.BackgroundColor = Color.LightGray;
            button5.Annotation.AppearanceCharacteristics.ButtonNormalCaption = "Button5";
            // set the text default appearance
            button5.SetTextDefaultAppearance(font, fontSize, Color.Black);
            // set the button action
            PdfJavaScriptAction action = new PdfJavaScriptAction(document, "app.alert({cMsg:'Test button.Annotation.ActivateAction property.', nIcon:3});");
            button5.Annotation.ActivateAction = action;

            // add button to PDF document
            AddFieldToPdfDocument(document, button5, false);

            #endregion


            #region Button6 - Button with dynamic appearance with icons

            // add table row with information about button
            fieldCellDrawingBox = AddTableRow(
                "Button6: Button with dynamic appearance (border style; text default appearance; normal, down and rollover icons). Button appearance is generated dynamically by the viewer application.",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create a button
            PdfInteractiveFormPushButtonField button6 = new PdfInteractiveFormPushButtonField(document, "Button6", fieldCellDrawingBox);
            // set the appearance characteristics
            PdfAnnotationAppearanceCharacteristics appearanceCharacteristics = new PdfAnnotationAppearanceCharacteristics(document);
            button6.Annotation.AppearanceCharacteristics = appearanceCharacteristics;
            button6.Annotation.HighlightingMode = PdfAnnotationHighlightingMode.Push;

            appearanceCharacteristics.ButtonNormalCaption = "Normal Caption";
            appearanceCharacteristics.ButtonRolloverCaption = "Rollover Caption";
            appearanceCharacteristics.ButtonDownCaption = "Down Caption";

            appearanceCharacteristics.ButtonCaptionIconRelation = PdfAnnotationCaptionIconRelation.CaptionOverIcon;
            appearanceCharacteristics.ButtonIconFit = new PdfAnnotationIconFit(document);
            appearanceCharacteristics.ButtonIconFit.IconScaleMode = PdfAnnotationIconScaleMode.AlwaysScale;
            appearanceCharacteristics.ButtonIconFit.MaintainAspectRatio = true;

            // create "Normal" icon
            button6.Annotation.AppearanceCharacteristics.ButtonNormalIcon = new PdfFormXObjectResource(document, new RectangleF(0,0,70,20));
            using (PdfGraphics g = PdfGraphics.FromForm(appearanceCharacteristics.ButtonNormalIcon))
            {
                RectangleF appearanceRect = appearanceCharacteristics.ButtonNormalIcon.BoundingBox;
                appearanceRect.X = 0;
                appearanceRect.Y = 0;
                g.SaveGraphicsState();
                g.FillRectangle(new PdfBrush(Color.Green), appearanceRect);
                g.DrawRectangle(new PdfPen(Color.Lime, 2), appearanceRect);
                appearanceRect.Inflate(-2, -2);
                g.DrawString("Normal Icon", font, fontSize / 2, new PdfBrush(Color.Gray), appearanceRect, PdfContentAlignment.Left | PdfContentAlignment.Top, false);
                g.RestoreGraphicsState();
            }

            // create "Rollover" icon
            button6.Annotation.AppearanceCharacteristics.ButtonRolloverIcon = new PdfFormXObjectResource(document, new RectangleF(0, 0, 70, 20));
            using (PdfGraphics g = PdfGraphics.FromForm(appearanceCharacteristics.ButtonRolloverIcon))
            {
                RectangleF appearanceRect = appearanceCharacteristics.ButtonRolloverIcon.BoundingBox;
                appearanceRect.X = 0;
                appearanceRect.Y = 0;
                g.SaveGraphicsState();
                g.FillRectangle(new PdfBrush(Color.Blue), appearanceRect);
                g.DrawRectangle(new PdfPen(Color.Lime, 2), appearanceRect);
                appearanceRect.Inflate(-2, -2);
                g.DrawString("Rollover Icon", font, fontSize / 2, new PdfBrush(Color.Gray), appearanceRect, PdfContentAlignment.Left | PdfContentAlignment.Top, false);
                g.RestoreGraphicsState();
            }

            // create "Down" icon
            button6.Annotation.AppearanceCharacteristics.ButtonDownIcon = new PdfFormXObjectResource(document, new RectangleF(0, 0, 70, 20));
            using (PdfGraphics g = PdfGraphics.FromForm(appearanceCharacteristics.ButtonDownIcon))
            {
                RectangleF appearanceRect = appearanceCharacteristics.ButtonDownIcon.BoundingBox;
                appearanceRect.X = 0;
                appearanceRect.Y = 0;
                g.SaveGraphicsState();
                g.FillRectangle(new PdfBrush(Color.Red), appearanceRect);
                g.DrawRectangle(new PdfPen(Color.Lime, 2), appearanceRect);
                appearanceRect.Inflate(-2, -2);
                g.DrawString("Down Icon", font, fontSize / 2, new PdfBrush(Color.Gray), appearanceRect, PdfContentAlignment.Left| PdfContentAlignment.Top, false);
                g.RestoreGraphicsState();
            }

            // set the text default appearance
            button6.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // add button to PDF document
            AddFieldToPdfDocument(document, button6, false);

            #endregion

        }

        #endregion

    }
}
