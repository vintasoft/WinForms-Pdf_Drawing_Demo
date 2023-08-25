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
    /// Represents samples of the interactive form text fields.
    /// </summary>
    public class TextFieldsSample : InteractiveFormFieldsSample
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TextFieldsSample"/> class.
        /// </summary>
        /// <param name="page">The PDF page.</param>
        /// <param name="graphics">The graphics.</param>
        /// <param name="fontSize">The font size.</param>
        /// <param name="showLogo">Indicates whether to show the logo image.</param>
        public TextFieldsSample(PdfPage page, PdfGraphics graphics, float fontSize, bool showLogo)
            : base(
            page,
            "class PdfInteractiveFormTextField",
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
            #region TextField1 - Single line text field

            // add table row with information about field
            RectangleF fieldCellDrawingBox = AddTableRow(
                "TextField1: Single line text field.\nField appearance is defined using field properties (text; text default appearance; text quadding) and generated dynamically by the viewer application.",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create text field
            PdfInteractiveFormTextField textField1 = new PdfInteractiveFormTextField(document, "TextField1", fieldCellDrawingBox);
            textField1.Value = new PdfInteractiveFormTextFieldStringValue(document, "text string");
            textField1.DefaultValue = textField1.Value;
            textField1.TextQuadding = TextQuaddingType.Centered;

            // set text default appearance
            textField1.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // add field to PDF document
            AddFieldToPdfDocument(document, textField1);

            #endregion


            #region TextField2 - Multiline text field

            // add table row with information about field
            fieldCellDrawingBox = AddTableRow(
                "TextField2: Multiline text field.\nField appearance is defined using field properties (text; text default appearance) and generated dynamically by the viewer application.",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create text field
            PdfInteractiveFormTextField textField2 = new PdfInteractiveFormTextField(document, "TextField2", fieldCellDrawingBox, "line1\nline2");
            textField2.DefaultValue = textField2.Value;
            textField2.IsMultiline = true;

            // set text default appearance
            textField2.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // add field to PDF document
            AddFieldToPdfDocument(document, textField2);

            #endregion


            #region TextField3 - Password text field

            // add table row with information about field
            fieldCellDrawingBox = AddTableRow(
                "TextField3: Password text field.\nField appearance is defined using field properties (text; text default appearance) and generated dynamically by the viewer application.",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create text field
            PdfInteractiveFormTextField textField3 = new PdfInteractiveFormTextField(document, "TextField3", fieldCellDrawingBox, "Password");
            textField3.DefaultValue = textField3.Value;
            textField3.IsPassword = true;

            // set text default appearance
            textField3.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // add field to PDF document
            AddFieldToPdfDocument(document, textField3);

            #endregion


            #region TextField4 - Single line text field, maximum text length is 13

            // add table row with information about field
            fieldCellDrawingBox = AddTableRow(
                "TextField4: Single line text field, maximum text length is 13.\nField appearance is defined using field properties (text; text default appearance) and generated dynamically by the viewer application.",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create text field
            PdfInteractiveFormTextField textField4 = new PdfInteractiveFormTextField(document, "TextField4", fieldCellDrawingBox, "MaxLength=13");
            textField4.DefaultValue = textField4.Value;
            textField4.MaxLength = 13;

            // set text default appearance
            textField4.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // add field to PDF document
            AddFieldToPdfDocument(document, textField4);

            #endregion


            #region TextField5 - Single line text field with dynamic appearance

            // add table row with information about field
            fieldCellDrawingBox = AddTableRow(
                "TextField5: Single line text field with dynamic appearance.\nField appearance is defined using the appearance characteristics (border style; text default appearance) and generated dynamically by the viewer application.",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create text field
            PdfInteractiveFormTextField textField5 = new PdfInteractiveFormTextField(document, "TextField5", fieldCellDrawingBox, "text string");
            textField5.DefaultValue = textField5.Value;

            // set border style
            textField5.Annotation.BorderStyleType = PdfAnnotationBorderStyleType.Inset;
            textField5.Annotation.BorderWidth = 1;

            // set appearance characteristics
            textField5.Annotation.AppearanceCharacteristics = new PdfAnnotationAppearanceCharacteristics(document);
            textField5.Annotation.AppearanceCharacteristics.BorderColor = Color.Black;
            textField5.Annotation.AppearanceCharacteristics.BackgroundColor = Color.LightBlue;

            // set text default appearance
            textField5.SetTextDefaultAppearance(font, fontSize, Color.Red);

            // add field to PDF document
            AddFieldToPdfDocument(document, textField5);

            #endregion


            #region TextField6 - Single line text field with custom appearance

            // add table row with information about field
            fieldCellDrawingBox = AddTableRow(
                "TextField6: Single line text field with custom appearance.\nField appearance is defined using PDF graphical commands.",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create text field
            PdfInteractiveFormTextField textField6 = new PdfInteractiveFormTextField(document, "TextField6", fieldCellDrawingBox, "text string");
            textField6.DefaultValue = textField6.Value;

            // create field appearance
            using (PdfGraphics g = textField6.CreateAppearanceGraphics())
            {
                RectangleF rect = textField6.Annotation.Rectangle;
                rect.X = 0;
                rect.Y = 0;
                g.SaveGraphicsState();
                g.FillRectangle(new PdfBrush(Color.LightBlue), rect);
                g.DrawRectangle(new PdfPen(Color.Black, 2), rect);
                g.RestoreGraphicsState();
            }

            // sets the text default appearance
            textField6.SetTextDefaultAppearance(font, fontSize, Color.Red);

            // add field to PDF document
            AddFieldToPdfDocument(document, textField6);

            #endregion


            #region NumericField - Numeric-only text field

            // add table row with information about field
            fieldCellDrawingBox = AddTableRow(
                "NumericField: Numeric-only text field.\nKeystroke action is used for validating entered field value and replacing letters to an empty char.",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create text field
            PdfInteractiveFormTextField numericField = new PdfInteractiveFormTextField(document, "NumericField", fieldCellDrawingBox, "12345");
            numericField.DefaultValue = numericField.Value;

            // set the text default appearance
            numericField.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // create JavaScript code for validation method (0-9 digits)
            StringBuilder javaScriptCode = new StringBuilder();
            javaScriptCode.AppendLine("var regex = /[^0-9]/;");
            javaScriptCode.AppendLine("if(regex.test(event.change))");
            javaScriptCode.AppendLine("  event.change = '';");

            // create JavaScript action
            PdfJavaScriptAction action = new PdfJavaScriptAction(document, javaScriptCode.ToString());

            // create additional actions for field
            numericField.AdditionalActions = new PdfInteractiveFormFieldAdditionalActions(document);

            // add Keystroke action
            numericField.AdditionalActions.Keystroke = action;

            // add field to PDF document
            AddFieldToPdfDocument(document, numericField);

            #endregion


            #region FileSelect - Text field and button for file selection

            // add table row with information about field
            fieldCellDrawingBox = AddTableRow(
                "FileSelect: Text field and button for file selection. Text field is marked as file selection field (textField.IsFileSelect property). Button uses JavaScript action for selecting file into TextField.",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);
            fieldCellDrawingBox.Height = fontSize * 1.75f;
            fieldCellDrawingBox.Width = fieldCellDrawingBox.Width - fontSize * 2;

            // create file select text field
            PdfInteractiveFormTextField fileSelectField = new PdfInteractiveFormTextField(document, "FileSelect", fieldCellDrawingBox);
            fileSelectField.IsFileSelect = true;

            // set border style
            fileSelectField.Annotation.BorderStyleType = PdfAnnotationBorderStyleType.Inset;
            fileSelectField.Annotation.BorderWidth = 1;

            // set appearance characteristics
            fileSelectField.Annotation.AppearanceCharacteristics = new PdfAnnotationAppearanceCharacteristics(document);
            fileSelectField.Annotation.AppearanceCharacteristics.BorderColor = Color.Gray;

            // set text default appearance
            fileSelectField.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // create browse button
            RectangleF browseButtonRect = new RectangleF(fieldCellDrawingBox.X + fieldCellDrawingBox.Width, fieldCellDrawingBox.Y, fontSize * 2, fieldCellDrawingBox.Height);
            PdfInteractiveFormPushButtonField browseButton = new PdfInteractiveFormPushButtonField(document, "browseButton", browseButtonRect);
            browseButton.UserInterfaceName = "Browse file...";

            // set border style
            browseButton.Annotation.BorderStyle = new PdfAnnotationBorderStyle(document);
            browseButton.Annotation.BorderStyleType = PdfAnnotationBorderStyleType.Beveled;

            // set text default appearance
            browseButton.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // set appearance characteristics
            browseButton.Annotation.AppearanceCharacteristics = new PdfAnnotationAppearanceCharacteristics(document);
            browseButton.Annotation.AppearanceCharacteristics.BackgroundColor = Color.LightGray;
            browseButton.Annotation.AppearanceCharacteristics.ButtonNormalCaption = "...";

            // create JavaScript code for file browsing
            javaScriptCode = new StringBuilder();
            javaScriptCode.AppendLine("var f=this.getField('FileSelect');f.browseForFileToSubmit();");

            // set JavaScript action as Activate action
            browseButton.Annotation.ActivateAction = new PdfJavaScriptAction(document, javaScriptCode.ToString());

            // add fields to PDF document
            AddFieldToPdfDocument(document, fileSelectField);
            AddFieldToPdfDocument(document, browseButton);

            #endregion


            #region Calculator - Group of three text fields

            // add table row with information about field
            fieldCellDrawingBox = AddTableRow(
                "Calculator: Group of three text fields. JavaScript program sums Calculator.Left and Calculator.Right field values and puts result to Calculator.Result field. Calculation is performed when page is opened or field values are changed.",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create a rectangle that defines the object (first field) position on PDF page
            RectangleF kidsRect = fieldCellDrawingBox;
            kidsRect.Width /= 5;

            // create calculator field: group of three fields
            PdfInteractiveFormField calculator = new PdfInteractiveFormField(document, "Calculator");
            calculator.SetTextDefaultAppearance(font, fontSize * 1.5f, Color.Black);
            calculator.TextQuadding = TextQuaddingType.Centered;

            // set border style
            PdfAnnotationBorderStyle borderStyle = new PdfAnnotationBorderStyle(document);
            borderStyle.Style = PdfAnnotationBorderStyleType.Inset;
            borderStyle.Width = 1;

            // create appearance characteristics
            PdfAnnotationAppearanceCharacteristics appearanceCharacteristics = new PdfAnnotationAppearanceCharacteristics(document);
            appearanceCharacteristics.BorderColor = Color.Gray;

            // create left text box
            PdfInteractiveFormTextField leftTextField = new PdfInteractiveFormTextField(document, "Left", kidsRect, "2");
            leftTextField.DefaultValue = leftTextField.Value;
            leftTextField.Annotation.BorderStyle = borderStyle;
            leftTextField.Annotation.AppearanceCharacteristics = appearanceCharacteristics;

            // add left text box to the calculator
            calculator.Kids.Add(leftTextField);

            // update rectangle that defines object position on a PDF page
            kidsRect.X += kidsRect.Width;

            // draw '+' symbol on a page
            graphics.DrawString("+", font, fontSize * 1.5f, new PdfBrush(Color.Black), kidsRect, PdfContentAlignment.Center, false);

            // create right text box
            kidsRect.X += kidsRect.Width;

            // create right text box
            PdfInteractiveFormTextField rightTextField = new PdfInteractiveFormTextField(document, "Right", kidsRect, "3");
            rightTextField.DefaultValue = rightTextField.Value;
            rightTextField.Annotation.BorderStyle = borderStyle;
            rightTextField.Annotation.AppearanceCharacteristics = appearanceCharacteristics;

            // add right text box to calculator
            calculator.Kids.Add(rightTextField);

            // update rectangle that defines object position on a PDF page
            kidsRect.X += kidsRect.Width;

            // draw '=' symbol on the page
            graphics.DrawString("=", font, fontSize * 1.5f, new PdfBrush(Color.Black), kidsRect, PdfContentAlignment.Center, false);

            // update rectangle that defines object position on a PDF page
            kidsRect.X += kidsRect.Width;

            // create result text box
            PdfInteractiveFormTextField resultTextField = new PdfInteractiveFormTextField(document, "Result", kidsRect);
            resultTextField.IsReadOnly = true;
            resultTextField.Annotation.BorderStyle = borderStyle;
            resultTextField.Annotation.AppearanceCharacteristics = appearanceCharacteristics;
            // add result text box to calculator
            calculator.Kids.Add(resultTextField);

            // create calculator program written on JavaScript
            javaScriptCode = new StringBuilder();
            javaScriptCode.AppendLine("var left = this.getField('Calculator.Left');");
            javaScriptCode.AppendLine("var right = this.getField('Calculator.Right');");
            javaScriptCode.AppendLine("var result = this.getField('Calculator.Result');");
            javaScriptCode.AppendLine("result.value = left.value + right.value;");
            PdfJavaScriptAction calculatorProgram = new PdfJavaScriptAction(document, javaScriptCode.ToString());

            // set a program that will calculate value of result field
            resultTextField.AdditionalActions = new PdfInteractiveFormFieldAdditionalActions(document);
            resultTextField.AdditionalActions.Calculate = calculatorProgram;

            // specify that calcualtor program must be executed when page is opened
            resultTextField.Annotation.AdditionalActions.PageOpen = calculatorProgram;

            // add result field to calculated fields (calcualtion order) 
            // of the document interactive form fields
            document.InteractiveForm.CalculationOrder = new PdfInteractiveFormFieldList(document);
            document.InteractiveForm.CalculationOrder.Add(resultTextField);


            // add calculator to a PDF document
            AddFieldGroupToPdfDocument(document, calculator);

            #endregion


            #region ResetButton

            // add table row with information about field
            fieldCellDrawingBox = AddTableRow(
                "ResetButton: Resets the form fields to their default values.\n",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create field
            PdfInteractiveFormPushButtonField resetButton = new PdfInteractiveFormPushButtonField(document, "ResetButton", fieldCellDrawingBox);

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

            // add field to a PDF document
            AddFieldToPdfDocument(document, resetButton);

            #endregion
        }

        #endregion

    }
}
