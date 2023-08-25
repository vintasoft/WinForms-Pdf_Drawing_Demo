using System;
using System.Drawing;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Drawing;
using Vintasoft.Imaging.Pdf.Drawing.GraphicsFigures;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Fonts;
using Vintasoft.Imaging.Utils;
using Vintasoft.Imaging.Pdf.Tree.Annotations;

using DemosCommonCode;

namespace PdfDrawingDemo
{
    /// <summary>
    /// Represents a template of simple report.
    /// </summary>
    public class ReportTemplate : GraphicsFigureGroup
    {

        #region Fields

        /// <summary>
        /// Template of the report footer.
        /// </summary>
        static string _reportFooter = string.Format("VintaSoft PDF Drawing Demo v{0}", ImagingGlobalSettings.ProductVersion);

        /// <summary>
        /// The layout of the page.
        /// </summary>
        AlignmentPanel _rootLayout;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportTemplate"/> class.
        /// </summary>
        /// <param name="page">The PDF page.</param>
        /// <param name="font">The text font.</param>
        /// <param name="fontSize">The font size.</param>
        /// <param name="name">The report name.</param>
        /// <param name="showLogo">Indicates whether to show the logo image.</param>
        public ReportTemplate(
            PdfPage page,
            PdfFont font,
            float fontSize,
            string name,
            bool showLogo)
            : base()
        {
            RectangleF pageMediaBox = page.MediaBox;

            // create the root layout
            _rootLayout = new AlignmentPanel();
            _rootLayout.Location = pageMediaBox.Location;
            _rootLayout.Size = pageMediaBox.Size;
            Add(_rootLayout);

            PdfBrush blackBrush = new PdfBrush(Color.Black);
            _rootLayout.Orientation = PdfContentOrientation.Vertical;

            // create the header
            AlignmentPanel header = new AlignmentPanel(PdfContentSizeMode.Fixed, fontSize * 2.5f);
            header.Orientation = PdfContentOrientation.Vertical;
            // Header text
            AlignmentPanelElement headerTextElement = new AlignmentPanelElement(PdfContentSizeMode.Percent, 60);
            TextBoxFigure headerText = new TextBoxFigure(blackBrush, name, font, fontSize);
            headerText.TextAlignment = PdfContentAlignment.Bottom | PdfContentAlignment.Left | PdfContentAlignment.Right;
            headerTextElement.Content = headerText;
            // Report time
            AlignmentPanelElement reportTimeElement = new AlignmentPanelElement();
            TextBoxFigure reportTimeText = new TextBoxFigure(blackBrush, DateTime.Now.ToString(), font, fontSize * 0.6f);
            reportTimeText.TextAlignment = PdfContentAlignment.Top | PdfContentAlignment.Left | PdfContentAlignment.Right;
            reportTimeText.TextPadding = new PdfContentPadding(fontSize * 0.1);
            reportTimeElement.Content = reportTimeText;
            header.Add(headerTextElement);
            header.Add(reportTimeElement);
            _rootLayout.Add(header);

            // create the body
            AlignmentPanel body = new AlignmentPanel();
            body.Margin = new PdfContentPadding(fontSize * 0.75);
            _rootLayout.Add(body);

            // create the footer
            AlignmentPanelElement footer = new AlignmentPanelElement(PdfContentSizeMode.Fixed, fontSize * 2);
            TextBoxFigure footerText = new TextBoxFigure(blackBrush, _reportFooter, font, fontSize * 0.6f);
            footerText.TextPadding = new PdfContentPadding(fontSize * 0.5);
            footerText.TextAlignment = PdfContentAlignment.Right | PdfContentAlignment.Bottom;
            footer.Content = footerText;
            _rootLayout.Add(footer);

            // create the logo
            if (showLogo)
            {
                using (VintasoftImage logoImage = DemosResourcesManager.GetResourceAsImage("VintasoftLogo.png"))
                {
                    PdfImageResource logoResource = new PdfImageResource(font.Document, logoImage, PdfCompression.Auto);
                    logoResource.Interpolate = true;
                    ImageFigure logoImageFigure = new ImageFigure(logoResource);
                    float width = (float)UnitOfMeasureConverter.ConvertToPoints(logoImage.Width, UnitOfMeasure.Pixels, logoImage.Resolution.Horizontal);
                    float height = (float)UnitOfMeasureConverter.ConvertToPoints(logoImage.Height, UnitOfMeasure.Pixels, logoImage.Resolution.Vertical);
                    width *= fontSize / 20f;
                    height *= fontSize / 20f;
                    logoImageFigure.Size = new SizeF(width, height);
                    logoImageFigure.Location = new PointF(
                        pageMediaBox.Width - width - fontSize * 0.75f,
                        pageMediaBox.Height - height - fontSize * 0.4f);
                    logoImageFigure.Pen = new PdfPen(Color.Black, 0.9f);
                    Add(logoImageFigure);
                    if (page.Annotations == null)
                        page.Annotations = new PdfAnnotationList(page.Document);
                    PdfLinkAnnotation linkAnnotation = new PdfLinkAnnotation(
                        page,
                        new PdfUriAction(page.Document, "https://www.vintasoft.com"));
                    linkAnnotation.Rectangle = new RectangleF(logoImageFigure.Location, logoImageFigure.Size);
                    page.Annotations.Add(linkAnnotation);
                }
            }
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets the report header.
        /// </summary>
        public AlignmentPanelElement Header
        {
            get
            {
                return (AlignmentPanelElement)_rootLayout[0];
            }
            set
            {
                _rootLayout[0] = value;
            }
        }

        /// <summary>
        /// Gets or sets the report body.
        /// </summary>
        public AlignmentPanel Body
        {
            get
            {
                return (AlignmentPanel)_rootLayout[1];
            }
            set
            {
                _rootLayout[1] = value;
            }
        }

        /// <summary>
        /// Gets or sets the report footer.
        /// </summary>
        public AlignmentPanelElement Footer
        {
            get
            {
                return (AlignmentPanelElement)_rootLayout[2];
            }
            set
            {
                _rootLayout[2] = value;
            }
        }

        #endregion

    }
}
