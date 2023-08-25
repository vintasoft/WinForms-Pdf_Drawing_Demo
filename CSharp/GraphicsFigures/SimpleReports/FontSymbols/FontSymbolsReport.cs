using System;
using System.Collections.Generic;
using System.Drawing;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Content.TextExtraction;
using Vintasoft.Imaging.Pdf.Drawing;
using Vintasoft.Imaging.Pdf.Drawing.GraphicsFigures;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Fonts;

using DemosCommonCode;


namespace PdfDrawingDemo
{
    /// <summary>
    /// Creates a report with information about symbols of PDF font.
    /// </summary>
    public class FontSymbolsReport
    {

        #region Constants

        /// <summary>
        /// Margin betwen symbol and cell border, in percents.
        /// </summary>
        /// <value>
        /// Minimum value is 0.0 (0%), maximum value is 1.0 (100%). 
        /// Default value is <b>0.3</b> (30%).
        /// </value>
        const double TEXT_MARGIN = 0.3;

        #endregion



        #region Fields

        /// <summary>
        /// PDF document that will contain pages of report.
        /// </summary>
        PdfDocument _document = null;

        /// <summary>
        /// PDF font to analyze.
        /// </summary>
        PdfFont _font = null;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FontSymbols"/> class.
        /// </summary>
        /// <param name="document">PDF document that will contain pages of report.</param>
        /// <param name="font">PDF font to analyze.</param>        
        public FontSymbolsReport(PdfDocument document, PdfFont font)
        {
            if (document == null)
                throw new ArgumentNullException("document");
            _document = document;

            if (font == null)
                throw new ArgumentNullException("font");
            _font = font;
        }

        #endregion



        #region Properties

        ImageSize _pageSize = ImageSize.FromPaperKind(PaperSizeKind.A4, ImagingEnvironment.ScreenResolution);
        /// <summary>
        /// Gets or sets a page size of single PDF page in report.
        /// </summary>
        public ImageSize PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }

        float _fontSize = 25;
        /// <summary>
        /// Gets or sets a font size.
        /// </summary>
        public float FontSize
        {
            get
            {
                return _fontSize;
            }
            set
            {
                _fontSize = value;
            }
        }

        bool _showLogo = true;
        /// <summary>
        /// Gets or sets a value indicating whether the VintaSoft logo should be drawn on PDF page.
        /// </summary>
        public bool ShowLogo
        {
            get
            {
                return _showLogo;
            }
            set
            {
                _showLogo = value;
            }
        }

        PdfBrush _textBrush = new PdfBrush(Color.Black);
        /// <summary>
        /// Gets or sets a text brush.
        /// </summary>
        public PdfBrush TextBrush
        {
            get
            {
                return _textBrush;
            }
            set
            {
                _textBrush = value;
            }
        }

        PdfFont _textFont;
        /// <summary>
        /// Gets or sets a text font.
        /// </summary>
        public PdfFont TextFont
        {
            get
            {
                return _textFont;
            }
            set
            {
                _textFont = value;
            }
        }

        PdfPen _tablePen = new PdfPen(Color.Black, 1);
        /// <summary>
        /// Gets or sets a pen for drawing the table.
        /// </summary>
        public PdfPen TablePen
        {
            get
            {
                return _tablePen;
            }
            set
            {
                _tablePen = value;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Generates the report with font symbols.
        /// </summary>
        /// <returns>Generated PDF pages.</returns>
        public PdfPage[] GenerateFontSymbolsReport()
        {
            if (TextFont == null)
                TextFont = _document.FontManager.GetStandardFont(PdfStandardFontType.TimesRoman);

            List<PdfPage> pages = new List<PdfPage>();

            TextBoxFigure symbolItemTextBox = new TextBoxFigure(TextBrush, "", _font, _fontSize, PdfContentAlignment.Center);
            symbolItemTextBox.Margin = new PdfContentPadding(_fontSize * TEXT_MARGIN);
            symbolItemTextBox.AutoHeight = true;
            symbolItemTextBox.AutoWidth = true;
            symbolItemTextBox.TextAlignment = PdfContentAlignment.Center;
            TextBoxFactory symbolTextFactory = new TextBoxFactory(symbolItemTextBox);

            // get font symbols
            PdfTextSymbol[] symbols = PdfTextSymbol.GetFontSymbols(_font);
            int symbolsCount = symbols.Length - 1;
            int symbolIndex = 0;

            bool firstPage = true;

            while (symbolIndex < symbolsCount)
            {
                // create new page
                PdfPage page = new PdfPage(_document, PageSize);
                // create main panel on page
                AlignmentPanel mainPanel = CreateMainPanel(page);

                if (firstPage)
                {
                    // create header
                    AlignmentPanelElement header = CreateHeader();
                    // add header to the main panel
                    mainPanel.Add(header);

                    firstPage = false;
                }

                // open graphics
                using (PdfGraphics g = PdfGraphics.FromPage(page))
                {
                    // draw symbols on current page
                    while (symbolIndex < symbolsCount)
                    {
                        if (!AddSymbolsLineToPage(symbols, ref symbolIndex, page, g, mainPanel, symbolTextFactory))
                            break;
                    }

                    mainPanel.Draw(g);
                }

                pages.Add(page);
            }

            return pages.ToArray();
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Creates the main panel on PDF page.
        /// </summary>
        /// <param name="page">PDF page.</param>
        /// <returns>New <see cref="AlignmentPanel"/> that represents the main panel on page.</returns>
        private AlignmentPanel CreateMainPanel(PdfPage page)
        {
            AlignmentPanel mainPanel = new AlignmentPanel();
            mainPanel.Orientation = PdfContentOrientation.Vertical;
            mainPanel.Size = page.MediaBox.Size;
            mainPanel.Margin = new PdfContentPadding(FontSize * 2);
            mainPanel.AutoHeight = true;
            return mainPanel;
        }

        /// <summary>
        /// Creates header for report.
        /// </summary>
        /// <returns><see cref="AlignmentPanelElement"/> that is a report header.</returns>
        private AlignmentPanelElement CreateHeader()
        {
            AlignmentPanel panel = new AlignmentPanel(PdfContentSizeMode.Auto);
            panel.AutoHeight = true;
            panel.AutoWidth = true;
            panel.Orientation = PdfContentOrientation.Vertical;

            float fontSize = FontSize * 0.75f;

            // logo
            if (ShowLogo)
            {
                AlignmentPanelElement logoElement = new AlignmentPanelElement(PdfContentSizeMode.Percent, 50);
                logoElement.ContentAlignment = PdfContentAlignment.Right;
                logoElement.AutoHeight = true;
                logoElement.AutoWidth = true;
                logoElement.Margin = new PdfContentPadding(0, 0, 0, fontSize * 0.2);
                using (VintasoftImage logoImage = DemosResourcesManager.GetResourceAsImage("VintasoftLogo.png"))
                {
                    PdfImageResource logoResource = new PdfImageResource(_document, logoImage, PdfCompression.Auto);
                    logoResource.Interpolate = true;
                    ImageFigure logoImageFigure = new ImageFigure(logoResource);
                    logoImageFigure.Pen = TablePen;
                    logoImageFigure.MaintainAspectRatio = true;
                    logoElement.Content = logoImageFigure;
                }
                panel.Add(logoElement);
            }

            // font name
            PdfContentAlignment textAlignment = PdfContentAlignment.Left | PdfContentAlignment.Right | PdfContentAlignment.Top;
            PdfContentPadding margin = new PdfContentPadding(fontSize);
            AlignmentPanelElement tmpPanelElement = new AlignmentPanelElement(PdfContentSizeMode.Fixed, fontSize);
            tmpPanelElement.Content = new TextBoxFigure(TextBrush,
                string.Format("Font Name: {0}", _font.FontName),
                TextFont, fontSize, textAlignment);
            tmpPanelElement.Margin = margin;
            panel.Add(tmpPanelElement);

            // font size
            tmpPanelElement = new AlignmentPanelElement(PdfContentSizeMode.Fixed, fontSize);
            tmpPanelElement.Content = new TextBoxFigure(TextBrush,
                string.Format("Font Size: {0}", _fontSize),
                TextFont, fontSize, textAlignment);
            tmpPanelElement.Margin = margin;
            panel.Add(tmpPanelElement);

            // time
            tmpPanelElement = new AlignmentPanelElement(PdfContentSizeMode.Fixed, fontSize);
            tmpPanelElement.Content = new TextBoxFigure(TextBrush,
                DateTime.Now.ToString(),
                TextFont, fontSize, textAlignment);
            tmpPanelElement.Margin = margin;
            panel.Add(tmpPanelElement);

            tmpPanelElement = new AlignmentPanelElement(PdfContentSizeMode.Fixed, fontSize);
            tmpPanelElement.Margin = margin;
            panel.Add(tmpPanelElement);

            return panel;
        }

        /// <summary>
        /// Appends new line with symbols to a page.
        /// </summary>
        /// <param name="symbols">Symbols.</param>
        /// <param name="firstSymbolIndex">Index of first symbol in line.</param>
        /// <param name="page">PDF Page</param>
        /// <param name="g">PDF graphics.</param>
        /// <param name="mainPanel">Main panel.</param>
        /// <param name="textFactory">Text factory.</param>
        /// <returns>A value indicating whether a symbols line added to a page.</returns>
        private bool AddSymbolsLineToPage(
            PdfTextSymbol[] symbols,
            ref int firstSymbolIndex,
            PdfPage page,
            PdfGraphics g,
            AlignmentPanel mainPanel,
            TextBoxFactory textFactory)
        {
            mainPanel.RefreshProperties(g);

            Table table = CreateTable(page);
            int columnCount = table.ColumnsProperties.Length;

            TextBoxFigure firstColTextBox = new TextBoxFigure(TextBrush, firstSymbolIndex.ToString(), TextFont, (FontSize * 0.5f), PdfContentAlignment.Center);
            firstColTextBox.AutoWidth = true;
            firstColTextBox.AutoHeight = true;
            firstColTextBox.Margin = new PdfContentPadding((FontSize * 0.5f) * TEXT_MARGIN);
            table.Cells[0, 0] = firstColTextBox;
            int currentIndex = firstSymbolIndex;
            for (int i = 1; (i < columnCount) && (currentIndex < symbols.Length); i++, currentIndex++)
            {
                table.Cells[0, i] = textFactory.Create(symbols[currentIndex].Symbols);
            }

            table.Size = new SizeF(mainPanel.Size.Width, 0);
            table.RefreshProperties(g);

            if ((mainPanel.Count <= 1) || (table.Size.Height < (page.MediaBox.Height - mainPanel.Size.Height)))
            {
                mainPanel.Add(table);
                firstSymbolIndex = currentIndex;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Creates a table.
        /// </summary>
        /// <param name="page">PDF page.</param>
        /// <returns>New table.</returns>
        private Table CreateTable(PdfPage page)
        {
            int columnCount = (int)((page.MediaBox.Width - (_fontSize * 0.5) * 7) / (_fontSize + 2 * TEXT_MARGIN * _fontSize)) + 1;
            Table table = new Table(new TableCellProperties[columnCount], new TableCellProperties[1]);
            table.Pen = TablePen;
            table.ElementSizeMode = PdfContentSizeMode.Auto;
            table.AutoHeight = true;
            table.AutoWidth = true;
            table.RowsProperties[0] = new TableCellProperties(PdfContentSizeMode.Auto);
            table.ColumnsProperties[0] = new TableCellProperties(PdfContentSizeMode.Fixed, (_fontSize * 0.5f) * 3);
            for (int i = 1; i < columnCount; i++)
            {
                table.ColumnsProperties[i] = new TableCellProperties(PdfContentSizeMode.Auto);
            }

            return table;
        }

        #endregion

        #endregion

    }
}
