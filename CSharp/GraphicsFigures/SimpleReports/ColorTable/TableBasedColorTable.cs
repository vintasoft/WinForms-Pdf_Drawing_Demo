using System.Drawing;

using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Fonts;
using Vintasoft.Imaging.Pdf.Drawing.GraphicsFigures;
using Vintasoft.Imaging.Pdf.Drawing;

namespace PdfDrawingDemo
{
    /// <summary>
    /// Represents a table based color table. 
    /// </summary>
    public class TableBasedColorTable : ReportTemplate
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TableBasedColorTable"/> class.
        /// </summary>
        /// <param name="page">The PDF page.</param>
        /// <param name="graphics">The <see cref="PdfGraphics"/>.</param>
        /// <param name="fontSize">The font size.</param>
        /// <param name="colorsCount">The table colors count.</param>
        /// <param name="showLogo">A value indicating whether to show the logo image.</param>
        public TableBasedColorTable(PdfPage page, PdfGraphics graphics, float fontSize, int colorsCount, bool showLogo)
            : base(
            page,
            page.Document.FontManager.GetStandardFont(PdfStandardFontType.Helvetica),
            fontSize * 2,
            "GREEN to BLUE Color Table",
            showLogo)
        {
            // set header size in percents
            Header.ElementSizeMode = PdfContentSizeMode.Percent;
            Header.ElementSize = 15;

            // set footer size in percents
            Footer.ElementSizeMode = PdfContentSizeMode.Percent;
            Footer.ElementSize = 10;

            int colorIncrement = 256 / colorsCount;
            colorsCount = 256 / colorIncrement;

            PdfFont textBoxFont = page.Document.FontManager.GetStandardFont(PdfStandardFontType.TimesRoman);
            TextBoxFigure sourceTextBox = new TextBoxFigure(new PdfBrush(Color.Black), "", textBoxFont, fontSize, PdfContentAlignment.Center);
            TextBoxFactory textBoxFactory = new TextBoxFactory(sourceTextBox);

            // columns properties
            TableCellProperties[] colsProperties = new TableCellProperties[colorsCount + 1];
            colsProperties[0] = new TableCellProperties(PdfContentSizeMode.Fixed, fontSize * 3);
            // other columns use Fill mode

            // rows properties
            TableCellProperties[] rowsProperties = new TableCellProperties[colorsCount + 1];
            rowsProperties[0] = new TableCellProperties(PdfContentSizeMode.Fixed, fontSize * 3);
            // other rows use Fill mode

            // create table
            Table colorTable = new Table(colsProperties, rowsProperties);
            colorTable.Pen = new PdfPen(Color.Black, 1f);

            // cell[0,0]
            colorTable.Cells[0, 0] = textBoxFactory.Create("Blue\nGreen");
            // rows
            for (int i = 0; i < colorsCount; i++)
            {
                int componentValue = i * colorIncrement;
                colorTable.Cells[i + 1, 0] = textBoxFactory.Create(componentValue.ToString());
                colorTable.Cells[0, i + 1] = textBoxFactory.Create(componentValue.ToString());
                // cols
                for (int j = 0; j < colorsCount; j++)
                {
                    colorTable.Cells[i + 1, j + 1] = new RectangleFigure(new PdfBrush(Color.FromArgb(0, componentValue, j * colorIncrement)));
                }
            }

            // set Body content
            Body.Content = colorTable;
        }

        #endregion

    }
}
