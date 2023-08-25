using Vintasoft.Imaging.Pdf.Drawing.GraphicsFigures;

namespace PdfDrawingDemo
{
    /// <summary>
    /// Represents the table cell properties.
    /// </summary>
    public class TableCellProperties
    {

        #region Contructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TableCellProperties"/> class.
        /// </summary>
        public TableCellProperties()
            : this(PdfContentSizeMode.Fill)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableCellProperties"/> class.
        /// </summary>
        /// <param name="sizeMode">PDF content size mode.</param>
        public TableCellProperties(PdfContentSizeMode sizeMode)
            : this(sizeMode, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableCellProperties"/> class.
        /// </summary>
        /// <param name="sizeMode">PDF content size mode.</param>
        /// <param name="size">Table cell size.</param>
        public TableCellProperties(PdfContentSizeMode sizeMode, float size)
        {
            _sizeMode = sizeMode;
            _size = size;
        }

        #endregion



        #region Properties

        float _size;
        /// <summary>
        /// Gets or sets the table cell size.
        /// </summary>
        public float Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }

        PdfContentSizeMode _sizeMode;
        /// <summary>
        /// Gets or sets the PDF content size mode
        /// </summary>
        public PdfContentSizeMode SizeMode
        {
            get
            {
                return _sizeMode;
            }
            set
            {
                _sizeMode = value;
            }
        }

        #endregion

    }
}
