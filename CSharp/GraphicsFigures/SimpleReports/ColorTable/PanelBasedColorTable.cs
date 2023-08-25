using System.Drawing;

using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Fonts;
using Vintasoft.Imaging.Pdf.Drawing.GraphicsFigures;
using Vintasoft.Imaging.Pdf.Drawing;

namespace PdfDrawingDemo
{
    /// <summary>
    /// Represents a panel based color table.
    /// </summary>
    public class PanelBasedColorTable : ReportTemplate
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PanelBasedColorTable"/> class.
        /// </summary>
        /// <param name="page">The PDF page.</param>
        /// <param name="graphics">The <see cref="PdfGraphics"/>.</param>
        /// <param name="fontSize">The font size.</param>
        /// <param name="colorsCount">The table colors count.</param>
        /// <param name="showLogo">A value indicating whether to show the logo image.</param>
        public PanelBasedColorTable(PdfPage page, PdfGraphics graphics, float fontSize, int colorsCount, bool showLogo)
            : base(
            page,
            page.Document.FontManager.GetStandardFont(PdfStandardFontType.Helvetica),
            fontSize * 2,
            "RED to GREEN Color Table",
            showLogo)
        {
            int i;

            Body.Orientation = PdfContentOrientation.Vertical;

            // set header size in percents
            Header.ElementSizeMode = PdfContentSizeMode.Percent;
            Header.ElementSize = 15;

            // set footer size in percents
            Footer.ElementSizeMode = PdfContentSizeMode.Percent;
            Footer.ElementSize = 10;

            int colorIncrement = 256 / colorsCount;

            PdfPen tablePen = new PdfPen(Color.Black, 1f);
            PdfFont textBoxFont = page.Document.FontManager.GetStandardFont(PdfStandardFontType.TimesRoman);
            TextBoxFigure sourceTextBox = new TextBoxFigure(new PdfBrush(Color.Black), "", textBoxFont, fontSize, PdfContentAlignment.Center);
            TextBoxFactory textBoxFactory = new TextBoxFactory(sourceTextBox);

            // first row
            AlignmentPanel firstRow = new AlignmentPanel(PdfContentSizeMode.Fixed, fontSize * 3);
            AlignmentPanelElement firstRowCol = new AlignmentPanelElement(PdfContentSizeMode.Fixed, fontSize * 3);
            firstRowCol.Pen = tablePen;
            firstRowCol.Content = textBoxFactory.Create("Green\nRed");
            firstRow.Add(firstRowCol);
            AlignmentPanelElement cell;
            for (i = 0; i < 256; i += colorIncrement)
            {
                cell = new AlignmentPanelElement();
                cell.Pen = tablePen;
                cell.Content = textBoxFactory.Create(i.ToString());
                firstRow.Add(cell);
            }
            Body.Add(firstRow);

            // other rows
            for (i = 0; i < 256; i += colorIncrement)
            {
                cell = new AlignmentPanelElement(PdfContentSizeMode.Fixed, fontSize * 3);
                cell.Pen = tablePen;
                cell.Content = textBoxFactory.Create(i.ToString());
                AlignmentPanel row = new AlignmentPanel();
                row.Orientation = PdfContentOrientation.Horizontal;
                row.Add(cell);
                for (int j = 0; j < 256; j += colorIncrement)
                {
                    cell = new AlignmentPanelElement();
                    cell.Pen = tablePen;
                    cell.Brush = new PdfBrush(Color.FromArgb(i, j, 0));
                    row.Add(cell);
                }
                Body.Add(row);
            }
        }

        #endregion

    }
}
