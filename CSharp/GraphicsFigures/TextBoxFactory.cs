using Vintasoft.Imaging;
using Vintasoft.Imaging.Utils;

using Vintasoft.Imaging.Pdf.Drawing.GraphicsFigures;
using Vintasoft.Imaging.Pdf.Drawing;

namespace PdfDrawingDemo
{
    /// <summary> 
    /// Represents the factory of text boxes.
    /// </summary>
    public class TextBoxFactory : ObjectsFactory<TextBoxFigure>
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBoxFactory"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public TextBoxFactory(TextBoxFigure source)
        {
            _source = source;
        }

        #endregion



        #region Properties

        TextBoxFigure _source;
        /// <summary>
        /// Gets the source text box.
        /// </summary>
        public TextBoxFigure Source
        {
            get
            {
                return _source;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Creates a copy of source text box and sets a specified text.
        /// </summary>
        /// <param name="text">Text to set.</param>
        public TextBoxFigure Create(string text)
        {
            TextBoxFigure textBox = CreateCopy(_source);
            textBox.Text = text;
            return textBox;
        }

        /// <summary>
        /// Creates a copy of source text box and sets a specified text and font size.
        /// </summary>
        /// <param name="text">Textbox text.</param>
        /// <param name="fontSize">Textbox size.</param>
        public TextBoxFigure Create(string text, float fontSize)
        {
            TextBoxFigure textBox = CreateCopy(_source);
            textBox.Text = text;
            textBox.FontSize = fontSize;
            return textBox;
        }

        /// <summary>
        /// Creates a copy of source text box and sets a specified text and alignment.
        /// </summary>
        /// <param name="text">Textbox text.</param>
        /// <param name="textAlignment">Text alignment.</param>
        public TextBoxFigure Create(string text, PdfContentAlignment textAlignment)
        {
            TextBoxFigure textBox = CreateCopy(_source);
            textBox.Text = text;
            textBox.TextAlignment = textAlignment;
            return textBox;
        }

        #endregion

    }
}
