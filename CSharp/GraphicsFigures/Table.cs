using System.Drawing;

using Vintasoft.Imaging.Pdf.Drawing.GraphicsFigures;
using Vintasoft.Imaging.Pdf.Drawing;

namespace PdfDrawingDemo
{
    /// <summary>
    /// Represent a table as an alignment element.
    /// </summary>
    public class Table : AlignmentPanelElement
    {

        #region Fields

        /// <summary>
        /// Table column width.
        /// </summary>
        float[] _colWidths;

        /// <summary>
        /// Table row height.
        /// </summary>
        float[] _rowHeights;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Table"/> class.
        /// </summary>
        /// <param name="columnsProperties">Table columns properties.</param>
        /// <param name="rowsProperties">Table rows properties.</param>
        public Table(TableCellProperties[] columnsProperties, TableCellProperties[] rowsProperties)
            : base()
        {
            _cells = new RectangleFigure[rowsProperties.Length, columnsProperties.Length];
            _columnsProperties = columnsProperties;
            _rowsProperties = rowsProperties;
            _rowsBackground = new RectangleFigure[_rowsProperties.Length];
            _rowsForeground = new RectangleFigure[_rowsProperties.Length];
            Pen = new PdfPen(Color.Black);
        }

        #endregion



        #region Properties

        TableCellProperties[] _columnsProperties;
        /// <summary>
        /// Gets the table columns properties.
        /// </summary>
        public TableCellProperties[] ColumnsProperties
        {
            get
            {
                return _columnsProperties;
            }
        }

        TableCellProperties[] _rowsProperties;
        /// <summary>
        /// Gets the table rows properties.
        /// </summary>
        public TableCellProperties[] RowsProperties
        {
            get
            {
                return _rowsProperties;
            }
        }

        RectangleFigure[,] _cells;
        /// <summary>
        /// Gets an array of table cells as figures.
        /// </summary>
        public RectangleFigure[,] Cells
        {
            get
            {
                return _cells;
            }
        }

        RectangleFigure[] _rowsBackground;
        /// <summary>
        /// Gets an array of figures representing background of the row.
        /// </summary>
        public RectangleFigure[] RowsBackground
        {
            get
            {
                return _rowsBackground;
            }
        }

        RectangleFigure[] _rowsForeground;
        /// <summary>
        /// Gets an array of figures representing foreground of the row.
        /// </summary>
        public RectangleFigure[] RowsForeground
        {
            get
            {
                return _rowsForeground;
            }
        }

        /// <summary>
        /// Gets a value indicating whether autowidth is supported.
        /// </summary>
        public override bool AutoWidth
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Draws the graphics figure on specified <see cref="PdfGraphics"/>.
        /// </summary>
        /// <param name="graphics">The <see cref="PdfGraphics"/>.</param>
        public override void DrawFigure(PdfGraphics graphics)
        {
            float y;
            int n = _cells.GetLength(0);
            int m = _cells.GetLength(1);

            // draw rows backgroud
            y = Location.Y + Size.Height;
            for (int i = 0; i < n; i++)
            {
                y -= _rowHeights[i];
                // draw row backgroud
                if (_rowsBackground[i] != null)
                {
                    _rowsBackground[i].Location = new PointF(Location.X, y);
                    _rowsBackground[i].Size = new SizeF(Size.Width, _rowHeights[i]);
                    _rowsBackground[i].Draw(graphics);
                }
            }

            // draw cells
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (_cells[i, j] != null)
                        _cells[i, j].DrawFigure(graphics);
                }
            }

            // draw table grid
            base.DrawFigure(graphics);
            DrawTableGrid(graphics);

            // draw rows foreground
            y = Location.Y + Size.Height;
            for (int i = 0; i < n; i++)
            {
                y -= _rowHeights[i];
                // draw row foreground
                if (_rowsForeground[i] != null)
                {
                    _rowsForeground[i].Location = new PointF(Location.X, y);
                    _rowsForeground[i].Size = new SizeF(Size.Width, _rowHeights[i]);
                    _rowsForeground[i].Draw(graphics);
                }
            }
        }

        /// <summary>
        ///  Refreshes the Graphics Figure properties (Size, Location, ...).
        /// </summary>
        /// <param name="graphics">The <see cref="PdfGraphics"/>.</param>
        public override void RefreshProperties(PdfGraphics graphics)
        {
            base.RefreshProperties(graphics);

            int n = _cells.GetLength(0);
            int m = _cells.GetLength(1);

            RectangleF rect = GetDrawRectangle();

            // calculate columns width
            _colWidths = new float[m];
            float freeWidth = rect.Width;
            float fillCols = 0;
            for (int i = 0; i < m; i++)
            {
                if (_columnsProperties[i] != null)
                {
                    switch (_columnsProperties[i].SizeMode)
                    {
                        case PdfContentSizeMode.Auto:
                        case PdfContentSizeMode.Fill:
                            fillCols++;
                            break;
                        case PdfContentSizeMode.Fixed:
                            _colWidths[i] = _columnsProperties[i].Size;
                            freeWidth -= _colWidths[i];
                            break;
                        case PdfContentSizeMode.Percent:
                            _colWidths[i] = rect.Width * _columnsProperties[i].Size / 100f;
                            freeWidth -= _colWidths[i];
                            break;
                    }
                }
                else
                {
                    fillCols++;
                }
            }
            for (int i = 0; i < m; i++)
            {
                if (_columnsProperties[i] == null ||
                    _columnsProperties[i].SizeMode == PdfContentSizeMode.Auto ||
                    _columnsProperties[i].SizeMode == PdfContentSizeMode.Fill)
                    _colWidths[i] = freeWidth / fillCols;
            }

            // calculate rows height
            _rowHeights = new float[n];
            float freeHeight = rect.Height;
            float fillRows = 0;
            for (int i = 0; i < n; i++)
            {
                if (_rowsProperties[i] != null)
                {
                    switch (_rowsProperties[i].SizeMode)
                    {
                        case PdfContentSizeMode.Auto:
                            float maxHeight = 0;
                            for (int j = 0; j < _columnsProperties.Length; j++)
                            {
                                RectangleFigure cell = _cells[i, j];
                                if (cell != null)
                                {
                                    cell.Size = new SizeF(_colWidths[j], cell.Size.Height);
                                    cell.RefreshProperties(graphics);
                                    if (cell.Size.Height > maxHeight)
                                        maxHeight = cell.Size.Height;
                                }
                            }
                            _rowHeights[i] = maxHeight;
                            freeHeight -= _rowHeights[i];
                            break;
                        case PdfContentSizeMode.Fill:
                            fillRows++;
                            break;
                        case PdfContentSizeMode.Fixed:
                            _rowHeights[i] = _rowsProperties[i].Size;
                            freeHeight -= _rowHeights[i];
                            break;
                        case PdfContentSizeMode.Percent:
                            _rowHeights[i] = rect.Height * _rowsProperties[i].Size / 100f;
                            freeHeight -= _rowHeights[i];
                            break;
                    }
                }
                else
                {
                    fillRows++;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (_rowsProperties[i] == null || _rowsProperties[i].SizeMode == PdfContentSizeMode.Fill)
                    _rowHeights[i] = freeHeight / fillRows;
            }

            // update cells size/location
            PointF location = rect.Location;
            location.Y += rect.Height;
            for (int i = 0; i < n; i++)
            {
                location.Y -= _rowHeights[i];
                for (int j = 0; j < m; j++)
                {
                    if (_cells[i, j] != null)
                    {
                        _cells[i, j].RefreshProperties(graphics);
                        _cells[i, j].Location = location;
                        _cells[i, j].Size = new SizeF(_colWidths[j], _rowHeights[i]);
                    }
                    location.X += _colWidths[j];
                }
                location.X = rect.Location.X;
            }


            if (AutoHeight)
            {
                float totalHeight = 0;
                for (int i = 0; i < _rowHeights.Length; i++)
                {
                    totalHeight += _rowHeights[i];
                }

                ReferencePoints[0] = new PointF(ReferencePoints[0].X, ReferencePoints[1].Y - totalHeight);
            }
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Draws the table grid on specified <see cref="PdfGraphics"/>.
        /// </summary>
        /// <param name="graphics">The <see cref="PdfGraphics"/>.</param>
        private void DrawTableGrid(PdfGraphics graphics)
        {
            if (Pen != null)
            {
                int n = _cells.GetLength(0);
                int m = _cells.GetLength(1);
                float x, y;

                RectangleF rect = GetDrawRectangle();
                x = rect.X;
                y = rect.Y;
                for (int i = 0; i < m - 1; i++)
                {
                    x += _colWidths[i];
                    graphics.DrawLine(Pen, x, y, x, y + rect.Height);
                }
                x = rect.X;
                y = rect.Y + rect.Height;
                for (int i = 0; i < n - 1; i++)
                {
                    y -= _rowHeights[i];
                    graphics.DrawLine(Pen, x, y, x + rect.Width, y);
                }
            }
        }

        #endregion

        #endregion

    }
}
