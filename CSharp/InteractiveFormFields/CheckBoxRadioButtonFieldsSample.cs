using System.Drawing;
using System.Text;

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
    public class CheckBoxRadioButtonFieldsSample : InteractiveFormFieldsSample
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBoxRadioButtonFieldsSample"/> class.
        /// </summary>
        /// <param name="page">The PDF page.</param>
        /// <param name="graphics">The PDF graphics.</param>
        /// <param name="fontSize">The font size.</param>
        /// <param name="showLogo">Indicates whether to show the logo image.</param>
        public CheckBoxRadioButtonFieldsSample(PdfPage page, PdfGraphics graphics, float fontSize, bool showLogo)
            : base(
            page,
            "class PdfInteractiveFormCheckBoxField\nclass PdfInteractiveFormRadioButtonGroupField",
            graphics,
            fontSize,
            70,
            showLogo)
        {
        }

        #endregion



        #region Methods

        #region PROTECTED

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
        protected override void AddContent(PdfDocument document, PdfGraphics graphics, TextBoxFactory textBoxFactory, PdfFont font, float fontSize, PdfPen tablePen, float firstColPercent)
        {
            PdfFont symbolsFont = document.FontManager.GetStandardFont(PdfStandardFontType.ZapfDingbats);
            float symbolFontSize = fontSize * 1.75f;


            #region CheckBox1

            // add table row with information about field
            RectangleF cellDrawingBox = AddTableRow(
                "CheckBox1: Checkbox with 2 custom appearances ('Yes' and 'Off'). Default value is 'Off'.\n",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create check box
            PdfInteractiveFormCheckBoxField checkBox1 = new PdfInteractiveFormCheckBoxField(document, "CheckBox1", cellDrawingBox);
            RectangleF contentRect = cellDrawingBox;
            contentRect.X = 0;
            contentRect.Y = 0;

            // create "Yes" appearance
            using (PdfGraphics g = checkBox1.CreateYesAppearanceGraphics())
            {
                g.DrawString("o", symbolsFont, symbolFontSize, new PdfBrush(Color.Black), contentRect, PdfContentAlignment.Center, false);
                g.DrawString("4", symbolsFont, symbolFontSize, new PdfBrush(Color.Green), contentRect, PdfContentAlignment.Center, false);
            }

            // create "Off" appearance
            using (PdfGraphics g = checkBox1.CreateOffAppearanceGraphics())
            {
                g.DrawString("o", symbolsFont, symbolFontSize, new PdfBrush(Color.Black), contentRect, PdfContentAlignment.Center, false);
            }

            // set value and default value
            checkBox1.Value = "Off";
            checkBox1.DefaultValue = checkBox1.Value;

            // add check box to PDF document
            AddFieldToPdfDocument(document, checkBox1);

            #endregion


            #region CheckBox2

            // add table row with information about field
            cellDrawingBox = AddTableRow(
                "CheckBox2: Checkbox with 2 custom appearances ('On' and 'Off') and custom text. Default value is 'On'.",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create check box
            checkBox1 = new PdfInteractiveFormCheckBoxField(document, "CheckBox2", cellDrawingBox);
            contentRect = cellDrawingBox;
            contentRect.X = 0;
            contentRect.Y = 0;
            RectangleF textRect = contentRect;
            PdfContentAlignment textAlignment = PdfContentAlignment.Left | PdfContentAlignment.Top | PdfContentAlignment.Bottom;

            // create "On" appearance
            using (PdfGraphics g = checkBox1.CreateAppearanceGraphics("On"))
            {
                g.DrawString("o", symbolsFont, symbolFontSize, new PdfBrush(Color.Black), contentRect, textAlignment, false);
                g.DrawString("8", symbolsFont, symbolFontSize, new PdfBrush(Color.Red), contentRect, textAlignment, false);

                float w, h;
                g.MeasureString("o", symbolsFont, symbolFontSize, out w, out h);
                textRect.X += w * 1.25f;
                textRect.Width -= w * 1.25f;
                g.DrawString("CheckBox2 (State = 'On')", font, fontSize, new PdfBrush(Color.Black), textRect, textAlignment, false);
            }

            // create "Off" appearance
            using (PdfGraphics g = checkBox1.CreateOffAppearanceGraphics())
            {
                g.DrawString("o", symbolsFont, symbolFontSize, new PdfBrush(Color.Black), contentRect, textAlignment, false);
                g.DrawString("CheckBox2 (State = 'Off')", font, fontSize, new PdfBrush(Color.Black), textRect, textAlignment, false);
            }

            // set value and default value
            checkBox1.Value = "On";
            checkBox1.DefaultValue = checkBox1.Value;

            // add check box to PDF document
            AddFieldToPdfDocument(document, checkBox1);

            #endregion


            #region RadioGroup1

            // add table row with information about field
            cellDrawingBox = AddTableRow(
                "RadioGroup1: Simple radio group with four radio buttons ('1','2','3','4'). Default value is '2'.\n",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create radio group
            PdfInteractiveFormRadioButtonGroupField radioGroup = new PdfInteractiveFormRadioButtonGroupField(document, "RadioGroup1");

            // add radio buttons to the radio group
            AddSimpleRadioButtons(radioGroup, font, fontSize, cellDrawingBox, "1", "2", "3", "4");

            // set value and default value
            radioGroup.CheckedAppearanceStateName = "2";
            radioGroup.DefaultCheckedAppearanceStateName = radioGroup.CheckedAppearanceStateName;

            // add radio group to PDF document
            AddFieldGroupToPdfDocument(document, radioGroup);

            #endregion


            #region RadioGroup2

            // add table row with information about field
            cellDrawingBox = AddTableRow(
                "RadioGroup2: Radio group with three radio buttons ('One','Two','Three'). Default value is 'Two'.",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create radio group
            radioGroup = new PdfInteractiveFormRadioButtonGroupField(document, "RadioGroup2");

            // add radio buttons to the radio group
            AddRadioButtons(radioGroup, font, fontSize, cellDrawingBox, "One", "Two", "Three");

            // set value and default value
            radioGroup.CheckedAppearanceStateName = "Two";
            radioGroup.DefaultCheckedAppearanceStateName = radioGroup.CheckedAppearanceStateName;

            // add radio group to PDF document
            AddFieldGroupToPdfDocument(document, radioGroup);

            #endregion


            #region GroupValues

            // add table row with information about field
            cellDrawingBox = AddTableRow(
                "GroupValues: Multi-line read-only calculated text field.\nPdfJavaScriptAction used to calculate value of this field.\n",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create text field
            PdfInteractiveFormTextField textField = new PdfInteractiveFormTextField(document, "GroupValues", cellDrawingBox);
            textField.IsMultiline = true;
            textField.IsReadOnly = true;

            // set the text default appearance
            textField.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // create JavaScript code that updates value of GroupValues field
            StringBuilder javaScriptCode = new StringBuilder();
            javaScriptCode.Append("var f1 = this.getField('RadioGroup1');");
            javaScriptCode.Append("var f2 = this.getField('RadioGroup2');");
            javaScriptCode.Append("var result = this.getField('GroupValues');");
            javaScriptCode.Append("result.value = 'RadioGroup1='+f1.value+'\\nRadioGroup2='+f2.value;");

            // create JavaScript action
            PdfJavaScriptAction updateGroupValuesAction = new PdfJavaScriptAction(document, javaScriptCode.ToString());

            // set a program that will calculate value of result field
            textField.AdditionalActions = new PdfInteractiveFormFieldAdditionalActions(document);
            textField.AdditionalActions.Calculate = updateGroupValuesAction;

            // specify that program must be executed when page is opened
            textField.Annotation.AdditionalActions.PageOpen = updateGroupValuesAction;

            // add result field to the calculated fields (calcualtion order) 
            // of the document interactive form fields
            document.InteractiveForm.CalculationOrder = new PdfInteractiveFormFieldList(document);
            document.InteractiveForm.CalculationOrder.Add(textField);

            // add text field to PDF document
            AddFieldToPdfDocument(document, textField);

            #endregion


            #region ResetButton

            // add table row with information about field
            cellDrawingBox = AddTableRow(
                "ResetButton: Resets the form fields to their default values.\n",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create field
            PdfInteractiveFormPushButtonField resetButton = new PdfInteractiveFormPushButtonField(document, "ResetButton", cellDrawingBox);

            // set UserInterfaceName that is used as tooltip in most readers
            resetButton.UserInterfaceName = "Resets all fields of PDF document.";

            // set Reset action as Activate action
            resetButton.Annotation.ActivateAction = new PdfResetFormAction(document);

            // set border style
            resetButton.Annotation.BorderStyleType = PdfAnnotationBorderStyleType.Beveled;
            resetButton.Annotation.BorderWidth = 1;

            // set appearance characteristics
            resetButton.Annotation.AppearanceCharacteristics = new PdfAnnotationAppearanceCharacteristics(document);
            resetButton.Annotation.AppearanceCharacteristics.BackgroundColor = Color.LightGray;
            resetButton.Annotation.AppearanceCharacteristics.ButtonNormalCaption = "Reset";

            // set text default appearance
            resetButton.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // add button to PDF document
            AddFieldToPdfDocument(document, resetButton);

            #endregion
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Adds simple radio buttons to a radio group.
        /// </summary>
        /// <param name="radioButtonGroup">A group of radio button interactive form fields.</param>
        /// <param name="font">The text font.</param>
        /// <param name="fontSize">The font size.</param>
        /// <param name="rect">The radio button rectangle.</param>
        /// <param name="values">Radio buttons values.</param>
        private void AddSimpleRadioButtons(
            PdfInteractiveFormRadioButtonGroupField radioButtonGroup,
            PdfFont font,
            float fontSize,
            RectangleF rect,
            params string[] values)
        {
            PdfDocument document = radioButtonGroup.Document;
            PdfBrush offBrush = new PdfBrush(Color.Black);
            PdfBrush onBrush = new PdfBrush(Color.Black);
            PdfFont symbolsFont = document.FontManager.GetStandardFont(PdfStandardFontType.ZapfDingbats);
            float symbolFontSize = fontSize * 1.5f;

            // for each radio button
            for (int i = 0; i < values.Length; i++)
            {
                string radioButtonValue = values[i];
                RectangleF radioButtonRect = new RectangleF(
                    rect.X + i * rect.Width / values.Length, rect.Y, rect.Width / values.Length, rect.Height);

                // create radio button
                PdfInteractiveFormRadioButtonField radioButton = new PdfInteractiveFormRadioButtonField(document, radioButtonRect);

                radioButtonRect.X = 0;
                radioButtonRect.Y = 0;
                RectangleF textRect = radioButtonRect;

                PdfContentAlignment textAlignment = PdfContentAlignment.Center;

                // create normal appearance
                using (PdfGraphics g = radioButton.CreateAppearanceGraphics(radioButtonValue))
                {
                    g.DrawString("m", symbolsFont, symbolFontSize, offBrush, radioButtonRect, textAlignment, false);
                    g.DrawString("l", symbolsFont, symbolFontSize, onBrush, radioButtonRect, textAlignment, false);

                }

                // create "Off" appearance
                using (PdfGraphics g = radioButton.CreateOffAppearanceGraphics())
                {
                    g.DrawString("m", symbolsFont, symbolFontSize, offBrush, radioButtonRect, textAlignment, false);
                }

                // add radio button the group field
                radioButtonGroup.Kids.Add(radioButton);
            }
        }

        /// <summary>
        /// Adds radio buttons to a radio group.
        /// </summary>
        /// <param name="radioButtonGroup">A group of radio button interactive form fields.</param>
        /// <param name="font">The text font.</param>
        /// <param name="fontSize">The font size.</param>
        /// <param name="rect">The radio button rectangle.</param>
        /// <param name="values">Radio buttons values.</param>
        private void AddRadioButtons(
            PdfInteractiveFormRadioButtonGroupField radioButtonGroup,
            PdfFont font,
            float fontSize,
            RectangleF rect,
            params string[] values)
        {
            PdfDocument document = radioButtonGroup.Document;
            PdfBrush offBrush = new PdfBrush(Color.Black);
            PdfBrush onBrush = new PdfBrush(Color.Green);
            PdfFont symbolsFont = document.FontManager.GetStandardFont(PdfStandardFontType.ZapfDingbats);
            float symbolFontSize = fontSize * 1.5f;

            // for each radio button
            for (int i = 0; i < values.Length; i++)
            {
                string radioButtonValue = values[i];
                RectangleF radioButtonRect = new RectangleF(
                    rect.X + i * rect.Width / values.Length, rect.Y, rect.Width / values.Length, rect.Height);

                // create radio button
                PdfInteractiveFormRadioButtonField radioButton = new PdfInteractiveFormRadioButtonField(document, radioButtonRect);

                radioButtonRect.X = 0;
                radioButtonRect.Y = 0;
                RectangleF textRect = radioButtonRect;

                PdfContentAlignment textAlignment = PdfContentAlignment.Left | PdfContentAlignment.Top | PdfContentAlignment.Bottom;

                // create normal appearance
                using (PdfGraphics g = radioButton.CreateAppearanceGraphics(radioButtonValue))
                {
                    g.DrawString("m", symbolsFont, symbolFontSize, offBrush, radioButtonRect, textAlignment, false);
                    g.DrawString("l", symbolsFont, symbolFontSize, onBrush, radioButtonRect, textAlignment, false);

                    float w, h;
                    g.MeasureString("m", symbolsFont, symbolFontSize, out w, out h);
                    textRect.X += w * 1.25f;
                    textRect.Width -= w * 1.25f;
                    g.DrawString(radioButtonValue, font, fontSize, offBrush, textRect, textAlignment, false);

                }
                // create "Off" appearance
                using (PdfGraphics g = radioButton.CreateOffAppearanceGraphics())
                {
                    g.DrawString("m", symbolsFont, symbolFontSize, offBrush, radioButtonRect, textAlignment, false);
                    g.DrawString(radioButtonValue, font, fontSize, offBrush, textRect, textAlignment, false);
                }

                // add radio button the group field
                radioButtonGroup.Kids.Add(radioButton);
            }
        }

        /// <summary>
        /// Creates the Reset button field.
        /// </summary>
        /// <param name="document">The PDF document.</param>
        /// <param name="drawingBox">The drawing box of field.</param>
        /// <param name="font">The font of field text.</param>
        /// <param name="fontSize">The font size of the field text.</param>
        /// <returns>The Reset button field.</returns>
        private PdfInteractiveFormPushButtonField CreateResetButtonField(
            PdfDocument document,
            RectangleF drawingBox,
            PdfFont font,
            float fontSize)
        {
            // create field
            PdfInteractiveFormPushButtonField field = new PdfInteractiveFormPushButtonField(document, "ResetButton", drawingBox);
            // set the UserInterfaceName that is used as tooltip in most readers
            field.UserInterfaceName = "Resets all fields of PDF document.";
            // set the Reset action as Activate action
            field.Annotation.ActivateAction = new PdfResetFormAction(document);

            // set the border style
            field.Annotation.BorderStyleType = PdfAnnotationBorderStyleType.Beveled;
            field.Annotation.BorderWidth = 1;

            // set the appearance characteristics
            field.Annotation.AppearanceCharacteristics = new PdfAnnotationAppearanceCharacteristics(document);
            field.Annotation.AppearanceCharacteristics.BackgroundColor = Color.LightGray;
            field.Annotation.AppearanceCharacteristics.ButtonNormalCaption = "Reset";

            // set the text default appearance
            field.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // return the field
            return field;
        }

        #endregion

        #endregion

    }
}
