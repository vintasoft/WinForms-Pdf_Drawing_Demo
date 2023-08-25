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
    /// Samples of the interactive form list box and combo box fields.
    /// </summary>
    public class ListBoxComboBoxFieldsSample : InteractiveFormFieldsSample
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ListBoxComboBoxFieldsSample"/> class.
        /// </summary>
        /// <param name="page">The PDF page.</param>
        /// <param name="graphics">The PDF graphics.</param>
        /// <param name="fontSize">The font size.</param>
        /// <param name="showLogo">Indicates whether to show the logo image.</param>
        public ListBoxComboBoxFieldsSample(PdfPage page, PdfGraphics graphics, float fontSize, bool showLogo)
            : base(
            page,
            "class PdfInteractiveFormListBoxField\nclass PdfInteractiveFormComboBoxField",
            graphics,
            fontSize,
            70,
            showLogo)
        {
        }

        #endregion



        #region Methods

        /// <summary>
        /// Adds the content to the report page.
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

            #region ListBox1
            
            // add table row with information about field
            RectangleF cellDrawingBox = AddTableRow(
                "ListBox1: Listbox with dynamic appearance (text; text default appearance; text quadding). Listbox appearance is generated dynamically by the viewer application. \"Item2\" is selected by default.\n",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create list box
            PdfInteractiveFormListBoxField listBox = new PdfInteractiveFormListBoxField(document, "ListBox1", cellDrawingBox, new string[] { "Item1", "Item2", "Item3" });
            listBox.SelectedItem = "Item2";
            listBox.DefaultSelectedItem = listBox.SelectedItem;

            // set border style
            listBox.Annotation.BorderStyleType = PdfAnnotationBorderStyleType.Solid;
            listBox.Annotation.BorderWidth = 1;

            // set appearance characteristics
            listBox.Annotation.AppearanceCharacteristics = new PdfAnnotationAppearanceCharacteristics(document);
            listBox.Annotation.AppearanceCharacteristics.BorderColor = Color.Gray;

            // set text default appearance
            listBox.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // add list box to PDF document
            AddFieldToPdfDocument(document, listBox);

            #endregion


            #region ListBox2

            // add table row with information about field
            cellDrawingBox = AddTableRow(
                "ListBox2: Listbox with ability to select multiple items and with dynamic appearance (text; text default appearance; text quadding). Listbox appearance is generated dynamically by the viewer application. \"Item2\" and \"Item3\" is selected by default.\n",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create list box
            PdfInteractiveFormListBoxField listBox2 = new PdfInteractiveFormListBoxField(
                document, 
                "ListBox2",
                cellDrawingBox,
                new string[] { "Item1", "Item2", "Item3", "Item4", "Item5", "Item6", "Item7", "Item8", "Item9", "Item10" });
            listBox2.IsMultiSelect = true;
            listBox2.SelectedItems = new string[] { "Item2", "Item3" };
            listBox2.DefaultSelectedItems = listBox2.SelectedItems;

            // set border style
            listBox2.Annotation.BorderStyleType = PdfAnnotationBorderStyleType.Solid;
            listBox2.Annotation.BorderWidth = 1;

            // set appearance characteristics
            listBox2.Annotation.AppearanceCharacteristics = new PdfAnnotationAppearanceCharacteristics(document);
            listBox2.Annotation.AppearanceCharacteristics.BorderColor = Color.Gray;

            // set text default appearance
            listBox2.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // add list box to PDF document
            AddFieldToPdfDocument(document, listBox2);

            #endregion


            #region ListBox3

            // add table row with information about field
            cellDrawingBox = AddTableRow(
                "ListBox3: Listbox with custom appearance defined using PDF graphical commands.\n",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);

            // create list box
            PdfInteractiveFormListBoxField listBox3 = new PdfInteractiveFormListBoxField(document, "ListBox3", cellDrawingBox, new string[] { "Item1", "Item2", "Item3", "Item4" });

            // create appearance
            listBox3.Annotation.BorderWidth = 2;
            using (PdfGraphics g = listBox3.CreateAppearanceGraphics())
            {
                RectangleF rect = listBox3.Annotation.Rectangle;
                rect.X = 0;
                rect.Y = 0;
                g.FillRectangle(new PdfBrush(Color.LightBlue), rect);
                g.DrawRectangle(new PdfPen(Color.Black, 2), rect);
                rect.Inflate(-2, -2);
                g.IntersectClip(rect);
            }

            // set text default appearance
            listBox3.SetTextDefaultAppearance(font, fontSize, Color.Red);

            // add list box to PDF document
            AddFieldToPdfDocument(document, listBox3);

            #endregion


            #region ComboBox1

            // add table row with information about field
            cellDrawingBox = AddTableRow(
                "ComboBox1: Combobox with dynamic appearance (text; text default appearance). Combobox appearance is generated dynamically by the viewer application. \"Item2\" is selected by default.",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);
            cellDrawingBox.Height = fontSize * 2;

            // create combo box
            PdfInteractiveFormComboBoxField comboBox1 = new PdfInteractiveFormComboBoxField(document, "ComboBox1", cellDrawingBox, new string[] { "Item1", "Item2", "Item3" });
            comboBox1.SelectedItem = "Item2";
            comboBox1.DefaultSelectedItem = listBox.SelectedItem;

            // set border style
            comboBox1.Annotation.BorderStyleType = PdfAnnotationBorderStyleType.Solid;
            comboBox1.Annotation.BorderWidth = 1;

            // set appearance characteristics
            comboBox1.Annotation.AppearanceCharacteristics = new PdfAnnotationAppearanceCharacteristics(document);
            comboBox1.Annotation.AppearanceCharacteristics.BorderColor = Color.Gray;

            // set text default appearance
            comboBox1.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // add combo box to PDF document
            AddFieldToPdfDocument(document, comboBox1);

            #endregion


            #region ComboBox2

            // add table row with information about field
            cellDrawingBox = AddTableRow(
                "ComboBox2: Combobox with custom appearance defined using PDF graphical commands.\n",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);
            cellDrawingBox.Height = fontSize * 2;

            // create combo box
            PdfInteractiveFormComboBoxField comboBox2 = new PdfInteractiveFormComboBoxField(document, "ComboBox2", cellDrawingBox, new string[] { "Item1", "Item2", "Item3", "Item4" });
            comboBox2.SelectedItem = "Item1";
            comboBox2.DefaultSelectedItem = comboBox2.SelectedItem;

            // create appearance
            comboBox2.Annotation.BorderWidth = 2;
            using (PdfGraphics g = comboBox2.CreateAppearanceGraphics())
            {
                RectangleF rect = comboBox2.Annotation.Rectangle;
                rect.X = 0;
                rect.Y = 0;
                g.FillRectangle(new PdfBrush(Color.LightBlue), rect);
                g.DrawRectangle(new PdfPen(Color.Black, 2), rect);
                rect.Inflate(-2, -2);
                g.IntersectClip(rect);
            }

            // set text default appearance
            comboBox2.SetTextDefaultAppearance(font, fontSize, Color.Red);

            // add combo box to PDF document
            AddFieldToPdfDocument(document, comboBox2);

            #endregion


            #region ComboBox3

            // add table row with information about field
            cellDrawingBox = AddTableRow(
                "ComboBox3: Combobox with editable value.\n",
                graphics, firstColPercent, tablePen, textBoxFactory, fontSize);
            cellDrawingBox.Height = fontSize * 2;

            // create combo box
            PdfInteractiveFormComboBoxField comboBox3 = new PdfInteractiveFormComboBoxField(document, "ComboBox3", cellDrawingBox, new string[] { "Item1", "Item2", "Item3" });
            comboBox3.SelectedItem = "Item2";
            comboBox3.DefaultSelectedItem = comboBox3.SelectedItem;
            comboBox3.IsEdit = true;

            // set border style
            comboBox3.Annotation.BorderStyleType = PdfAnnotationBorderStyleType.Solid;
            comboBox3.Annotation.BorderWidth = 1;

            // set appearance characteristics
            comboBox3.Annotation.AppearanceCharacteristics = new PdfAnnotationAppearanceCharacteristics(document);
            comboBox3.Annotation.AppearanceCharacteristics.BorderColor = Color.Gray;

            // set text default appearance
            comboBox3.SetTextDefaultAppearance(font, fontSize, Color.Black);

            // add combo box to PDF document
            AddFieldToPdfDocument(document, comboBox3);

            #endregion

        }

        #endregion

    }
}
