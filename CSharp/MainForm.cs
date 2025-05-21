using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.Text;
using Vintasoft.Imaging.Drawing;
using Vintasoft.Imaging.Drawing.Gdi;
using Vintasoft.Imaging.Fonts;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Drawing;
using Vintasoft.Imaging.Pdf.Drawing.GraphicsFigures;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Fonts;
using Vintasoft.Imaging.Pdf.UI.Annotations;
using Vintasoft.Imaging.Pdf.Tree.OptionalContent;
using Vintasoft.Imaging.Pdf.Tree.Patterns;

using DemosCommonCode;
using DemosCommonCode.Pdf;
using DemosCommonCode.Pdf.JavaScript;
using DemosCommonCode.Imaging;

namespace PdfDrawingDemo
{
    /// <summary>
    /// Main form of PDF Drawing Demo.
    /// </summary>
    public partial class MainForm : Form
    {

        #region Constants

        /// <summary>
        /// The number of primitives of each type.
        /// </summary>
        const int FIGURES_COUNT = 5;

        #endregion



        #region Fields

        /// <summary>
        /// Template of application title.
        /// </summary>
        static string Title = string.Format("VintaSoft PDF Drawing Demo v{0}", ImagingGlobalSettings.ProductVersion);

        /// <summary>
        /// The stream that contains PDF document.
        /// </summary>
        Stream _documentStream;

        /// <summary>
        /// PDF document.
        /// </summary>
        PdfDocument _document;

        /// <summary>
        /// An instance of <see cref="Random"/> to generate different numbers.
        /// </summary>
        Random _random = new Random();

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // register the evaluation license for VintaSoft Imaging .NET SDK
            Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");

            InitializeComponent();

            DemosTools.CatchVisualToolExceptions(imageViewer1);

            // set CustomFontProgramsController for all PDF documents
            CustomFontProgramsController.SetDefaultFontProgramsController();

            Text = Title;

            imageViewer1.SizeMode = ImageSizeMode.BestFit;

            paperSizeToolStripComboBox.Items.Add(PaperSizeKind.A2);
            paperSizeToolStripComboBox.Items.Add(PaperSizeKind.A3);
            paperSizeToolStripComboBox.Items.Add(PaperSizeKind.A4);
            paperSizeToolStripComboBox.Items.Add(PaperSizeKind.A5);
            paperSizeToolStripComboBox.Items.Add(PaperSizeKind.Standard10x11);
            paperSizeToolStripComboBox.Items.Add(PaperSizeKind.Standard10x14);
            paperSizeToolStripComboBox.Items.Add(PaperSizeKind.Standard11x17);
            paperSizeToolStripComboBox.Items.Add(PaperSizeKind.Standard15x11);
            paperSizeToolStripComboBox.Items.Add(PaperSizeKind.Standard9x11);
            paperSizeToolStripComboBox.Items.Add(PaperSizeKind.Letter);
            paperSizeToolStripComboBox.SelectedItem = PaperSizeKind.A4;


            // enable JavaScript
            PdfJavaScriptManager.IsJavaScriptEnabled = true;
            // register image viewer in JavaScript manager
            PdfJavaScriptManager.JsApp.RegisterImageViewer(imageViewer1);

            // create PDF annotation tool
            PdfAnnotationTool annotationTool = new PdfAnnotationTool(PdfJavaScriptManager.JsApp, false);

            // initialize global action executor
            PdfActionExecutorManager.Initialize(imageViewer1, annotationTool);

            // create document-level actions executor
            PdfDocumentLevelActionsExecutor documentLevelActionsExecutor =
                new PdfDocumentLevelActionsExecutor(PdfJavaScriptManager.JsApp);

            // set action executor for PdfDocumentLevelActionsExecutor to application action executor
            documentLevelActionsExecutor.ActionExecutor = PdfActionExecutorManager.ApplicationActionExecutor;

            // set action executor for PdfAnnotationTool to application action executor
            annotationTool.ActionExecutor = PdfActionExecutorManager.ApplicationActionExecutor;

            // create text selection tool
            TextSelectionTool textSelectionTool = new TextSelectionTool();
            textSelectionTool.IsKeyboardSelectionEnabled = true;
            textSelectionTool.IsMouseSelectionEnabled = true;

            // set viewer tool as composition of PDF annotation tool an PDF text selection tool
            imageViewer1.VisualTool = new CompositeVisualTool(
                annotationTool,
                textSelectionTool);

#if REMOVE_BARCODE_SDK
            barcodeFieldsToolStripMenuItem.Visible = false;
#endif

        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the font size.
        /// </summary>
        public float FontSize
        {
            get
            {
                float result;
                if (float.TryParse(fontSizeToolStripComboBox.Text,
                    NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                {
                    if (result > 0)
                        return result;
                }
                return 12;
            }
        }

        /// <summary>
        /// Gets the page size.
        /// </summary>
        public ImageSize PageSize
        {
            get
            {
                ImageSize pageSize;
                if (rotatedToolStripMenuItem.Checked)
                    pageSize = ImageSize.FromPaperKindRotated((PaperSizeKind)paperSizeToolStripComboBox.SelectedItem, ImagingEnvironment.ScreenResolution);
                else
                    pageSize = ImageSize.FromPaperKind((PaperSizeKind)paperSizeToolStripComboBox.SelectedItem, ImagingEnvironment.ScreenResolution);
                return pageSize;
            }
        }


        #region Random objects

        /// <summary>
        /// Gets a random font size.
        /// </summary>
        private float RandomFontSize
        {
            get
            {
                return 20f + (float)_random.NextDouble() * 20f;
            }
        }

        /// <summary>
        /// Gets a PDF pen with random color and size.
        /// </summary>
        private PdfPen RandomPen
        {
            get
            {
                return new PdfPen(RandomColor, 0.5f + (float)_random.NextDouble() * 6f);
            }
        }

        /// <summary>
        /// Gets a PDF brush with random color.
        /// </summary>
        private PdfBrush RandomBrush
        {
            get
            {
                return new PdfBrush(RandomColor);
            }
        }

        /// <summary>
        /// Gets a random rectangle.
        /// </summary>
        private RectangleF RandomRectangle
        {
            get
            {
                RectangleF bbox = _document.Pages[0].MediaBox;
                return new RectangleF(RandomPoint, new SizeF(10 + (float)_random.NextDouble() * bbox.Width / 4f, 10 + (float)_random.NextDouble() * bbox.Height / 4f));
            }
        }

        /// <summary>
        /// Gets an array of random points.
        /// </summary>
        private PointF[] RandomPoints
        {
            get
            {
                PointF[] result = new PointF[2 + _random.Next(32)];
                for (int i = 0; i < result.Length; i++)
                    result[i] = RandomPoint;
                return result;
            }
        }

        /// <summary>
        /// Gets a random point.
        /// </summary>
        private PointF RandomPoint
        {
            get
            {
                RectangleF bbox = _document.Pages[0].MediaBox;
                return new PointF((float)_random.NextDouble() * bbox.Width, (float)_random.NextDouble() * bbox.Height);
            }
        }

        /// <summary>
        /// Gets a random color.
        /// </summary>
        private Color RandomColor
        {
            get
            {
                byte A = (byte)(128 + _random.Next(127));
                byte R = (byte)_random.Next(255);
                byte G = (byte)_random.Next(255);
                byte B = (byte)_random.Next(255);
                return Color.FromArgb(A, R, G, B);
            }
        }

        #endregion

        #endregion



        #region Methods

        #region UI

        #region 'File' menu

        /// <summary>
        /// Handles the Click event of saveAsToolStripMenuItem object.
        /// </summary>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_documentStream != null)
            {
                if (savePdfFileDialog.ShowDialog() == DialogResult.OK)
                    SaveToFile(savePdfFileDialog.FileName);
            }
        }

        /// <summary>
        /// Handles the Click event of viewInPDFReaderToolStripMenuItem object.
        /// </summary>
        private void viewInPDFReaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_documentStream != null)
            {
                string filename = "temp.pdf";
                try
                {
                    SaveToFile(filename);

                    // open PDF file in default system PDF reader
                    ProcessStartInfo processInfo = new ProcessStartInfo(filename);
                    processInfo.UseShellExecute = true;
                    Process.Start(processInfo);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of exitToolStripMenuItem object.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion


        #region 'PdfGraphics' menu

        /// <summary>
        /// Handles the Click event of randomPrimitivesToolStripMenuItem object.
        /// </summary>
        private void randomPrimitivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // generate new PDF document
            PdfPage page = CreateDocumentPage();

            // draw graphical primitives randomly on PDF page
            using (PdfGraphics g = PdfGraphics.FromPage(page, PdfGraphicsCreationMode.CreateNew))
            {
                DrawPolygon(g);
                DrawRectangles(g);
                DrawEllipses(g);
                DrawLines(g);
                DrawCurves(g);
                DrawVectorString(g);
                DrawGraphicsPath(g);
                DrawTextString(g);
                AlphaTest(g, page);
            }

            OpenDocumentInViewer();
        }

        /// <summary>
        /// Handles the Click event of translateToolStripMenuItem object.
        /// </summary>
        private void translateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfGraphics g = PdfGraphics.FromPage(CreateDocumentPage()))
            {
                g.TranslateTransform(50, 100);
                PdfPen pen = new PdfPen(Color.Red, 5);
                g.DrawRectangle(pen, 0, 0, 50, 50);
            }

            OpenDocumentInViewer();
        }

        /// <summary>
        /// Handles the Click event of scaleToolStripMenuItem object.
        /// </summary>
        private void scaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfGraphics g = PdfGraphics.FromPage(CreateDocumentPage()))
            {
                g.TranslateTransform(50, 100);
                g.ScaleTransform(2, 4);
                PdfPen pen = new PdfPen(Color.Red, 5);
                g.DrawRectangle(pen, 0, 0, 50, 50);
            }

            OpenDocumentInViewer();
        }

        /// <summary>
        /// Handles the Click event of rotateToolStripMenuItem object.
        /// </summary>
        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfGraphics g = PdfGraphics.FromPage(CreateDocumentPage()))
            {
                PdfPen redPen = new PdfPen(Color.Red, 5);
                PdfPen greenPen = new PdfPen(Color.Green, 5);
                PdfPen bluePen = new PdfPen(Color.Blue, 5);

                g.TranslateTransform(100, 100);
                g.DrawLine(bluePen, 0, 0, 0, 200);
                g.DrawLine(bluePen, 0, 0, 200, 0);

                g.DrawRectangle(greenPen, 50, 100, 50, 50);

                g.RotateTransform(-20);
                g.DrawRectangle(redPen, 50, 100, 50, 50);
            }

            OpenDocumentInViewer();
        }

        /// <summary>
        /// Handles the Click event of rotateAtToolStripMenuItem object.
        /// </summary>
        private void rotateAtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfGraphics g = PdfGraphics.FromPage(CreateDocumentPage()))
            {
                PdfPen redPen = new PdfPen(Color.Red, 5);
                PdfPen greenPen = new PdfPen(Color.Green, 5);
                PdfPen bluePen = new PdfPen(Color.Blue, 5);

                g.TranslateTransform(100, 100);
                g.DrawLine(bluePen, 0, 0, 0, 200);
                g.DrawLine(bluePen, 0, 0, 200, 0);

                g.DrawRectangle(greenPen, 50, 100, 50, 50);

                g.TranslateTransform(50, 100);
                g.RotateTransform(-20);
                g.DrawRectangle(redPen, 0, 0, 50, 50);
            }

            OpenDocumentInViewer();
        }

        /// <summary>
        /// Handles the Click event of graphicsStateToolStripMenuItem object.
        /// </summary>
        private void graphicsStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfGraphics g = PdfGraphics.FromPage(CreateDocumentPage()))
            {
                PdfPen pen = new PdfPen(Color.Green, 5);

                g.SaveGraphicsState();
                g.TranslateTransform(100, 100);
                g.DrawRectangle(pen, 0, 0, 50, 50);
                for (int i = 0; i < 3; i++)
                {
                    g.SaveGraphicsState();
                    g.TranslateTransform(100, 0);
                    g.ScaleTransform(0.5f, 0.5f);
                    g.DrawRectangle(pen, 0, 0, 50, 50);
                }

                pen = new PdfPen(Color.Red, 5);

                for (int i = 0; i < 4; i++)
                {
                    g.TranslateTransform(0, 100);
                    g.DrawRectangle(pen, 0, 0, 50, 50);
                    g.RestoreGraphicsState();
                }
            }

            OpenDocumentInViewer();
        }

        /// <summary>
        /// Handles the Click event of setClipToolStripMenuItem object.
        /// </summary>
        private void setClipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfGraphics g = PdfGraphics.FromPage(CreateDocumentPage()))
            {
                PdfBrush brush1 = new PdfBrush(Color.Green);
                PdfBrush brush2 = new PdfBrush(Color.Red);

                g.SaveGraphicsState();
                g.IntersectClip(new RectangleF(0, 000, 200, 200));
                g.FillEllipse(brush1, _document.Pages[0].MediaBox);
                g.RestoreGraphicsState();

                g.SaveGraphicsState();
                g.IntersectClip(new RectangleF(200, 0, 200, 200));
                g.FillEllipse(brush2, _document.Pages[0].MediaBox);
                g.RestoreGraphicsState();
            }

            OpenDocumentInViewer();
        }

        /// <summary>
        /// Handles the Click event of drawStringToolStripMenuItem object.
        /// </summary>
        private void drawStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfPage page = CreateDocumentPage();
            using (PdfGraphics g = PdfGraphics.FromPage(page))
            {
                PdfBrush brush = new PdfBrush(Color.Black);
                PointF location = new PointF(10, 300);

                PdfFont arialFont = null;
                using (FontProgramSearchResult fontProgramSearchResult = CustomFontProgramsController.Default.GetTrueTypeFontProgram(new FontInfo("Arial")))
                {
                    Stream fontProgramStream = null;
                    if (fontProgramSearchResult != null)
                        fontProgramStream = fontProgramSearchResult.FontProgramStream;

                    if (fontProgramStream != null)
                        arialFont = _document.FontManager.CreateCIDFontFromTrueTypeFont(fontProgramStream);
                }

                if (arialFont == null)
                    DemosTools.ShowErrorMessage("Arial font is not found in system.");

                if (arialFont != null)
                {
                    string testSymbols = "Arial font, test symbols: € ü ö ¾ ɱ ₱ č ć š đ ž Ѱ﷼ ";
                    g.DrawString(testSymbols, arialFont, 20, brush, location.X, location.Y - 60);
                }
            }
            OpenDocumentInViewer();
        }

        /// <summary>
        /// Handles the Click event of drawStringAlignmentTestToolStripMenuItem object.
        /// </summary>
        private void drawStringAlignmentTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfPage page = CreateDocumentPage();
            CreateFontForm createFont = new CreateFontForm(page.Document);
            if (createFont.ShowDialog() == DialogResult.OK)
            {
                PdfFont font = createFont.SelectedFont;
                float fontSize = 12;
                PdfBrush brush = new PdfBrush(Color.Black);
                string text = "line1word1of1\nline2word1of2 line2word2of2\nline3word1of1";
                RectangleF rect = page.MediaBox;
                rect.Inflate(-rect.Width / 10, -rect.Height / 10);

                using (PdfGraphics g = PdfGraphics.FromPage(page))
                {
                    PdfPen pen = new PdfPen(Color.Red);
                    g.DrawRectangle(pen, rect);

                    DrawTestString(g, font, fontSize, rect, brush, text, PdfContentAlignment.Left | PdfContentAlignment.Top);
                    DrawTestString(g, font, fontSize, rect, brush, text, PdfContentAlignment.CenterTop);
                    DrawTestString(g, font, fontSize, rect, brush, text, PdfContentAlignment.Right | PdfContentAlignment.Top);

                    DrawTestString(g, font, fontSize, rect, brush, text, PdfContentAlignment.CenterLeft);
                    DrawTestString(g, font, fontSize, rect, brush, text, PdfContentAlignment.Center);
                    DrawTestString(g, font, fontSize, rect, brush, text, PdfContentAlignment.CenterRight);

                    DrawTestString(g, font, fontSize, rect, brush, text, PdfContentAlignment.Left | PdfContentAlignment.Bottom);
                    DrawTestString(g, font, fontSize, rect, brush, text, PdfContentAlignment.CenterBottom);
                    DrawTestString(g, font, fontSize, rect, brush, text, PdfContentAlignment.Right | PdfContentAlignment.Bottom);
                }
            }
            OpenDocumentInViewer();
        }

        /// <summary>
        /// Handles the Click event of measureStringToolStripMenuItem object.
        /// </summary>
        private void measureStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfPage page = CreateDocumentPage();
            using (PdfGraphics g = PdfGraphics.FromPage(page))
            {
                PdfFont font = page.Document.FontManager.GetStandardFont(PdfStandardFontType.Helvetica);
                PdfPen pen = new PdfPen(Color.Red);
                PdfBrush brush = new PdfBrush(Color.Black);
                float fontSize = 12;

                string simpleTestString = "MeasureString simple test";
                string multiLineTestString = "MeasureString multi line test:\nLine 1!\nLine2\nLine3 Line3";
                string wordWrapTestString = "MeasureString and WordWrap test:\n" + "VintaSoft Imaging .NET SDK is the impressive and easy-to-use .NET imaging toolkit for software developer. The program allows you to load, view, process, print and save digital images, convert them to different image file formats, possess enhanced work with multipage TIFF and animated GIF files.";

                float width, height;
                PointF location = new PointF(10, 300);

                g.MeasureString(simpleTestString, font, fontSize, out width, out height);
                g.DrawRectangle(pen, location.X, location.Y, width, height);
                g.DrawString(simpleTestString, font, fontSize, brush, location.X, location.Y);

                location.X += 150;
                g.MeasureString(multiLineTestString, font, fontSize, float.MaxValue, false, out width, out height);
                g.DrawRectangle(pen, location.X, location.Y, width, height);
                g.DrawString(multiLineTestString, font, fontSize, brush, location.X, location.Y, width, height, PdfContentAlignment.Left, false);
                location.Y -= height + 20;
                g.DrawRectangle(pen, location.X, location.Y, width, height);
                g.DrawString(multiLineTestString, font, fontSize, brush, location.X, location.Y, width, height, PdfContentAlignment.Center, false);
                location.Y -= height + 20;
                g.DrawRectangle(pen, location.X, location.Y, width, height);
                g.DrawString(multiLineTestString, font, fontSize, brush, location.X, location.Y, width, height, PdfContentAlignment.Right, false);

                location.X += 170;
                location.Y = 250;
                g.MeasureString(wordWrapTestString, font, fontSize, 250, true, out width, out height);
                g.DrawRectangle(pen, location.X, location.Y, width, height);
                g.DrawString(wordWrapTestString, font, fontSize, brush, location.X, location.Y, width, height, PdfContentAlignment.Left, true);
                location.Y -= height + 20;
                g.DrawRectangle(pen, location.X, location.Y, width, height);
                g.DrawString(wordWrapTestString, font, fontSize, brush, location.X, location.Y, width, height, PdfContentAlignment.Center, true);
                location.Y -= height + 20;
                g.DrawRectangle(pen, location.X, location.Y, width, height);
                g.DrawString(wordWrapTestString, font, fontSize, brush, location.X, location.Y, width, height, PdfContentAlignment.Right, true);
            }

            OpenDocumentInViewer();
        }

        /// <summary>
        /// Handles the Click event of tcTwTsToolStripMenuItem object.
        /// </summary>
        private void tcTwTsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfPage page = CreateDocumentPage();
            using (PdfGraphics g = PdfGraphics.FromPage(page))
            {
                PdfFont font = page.Document.FontManager.GetStandardFont(PdfStandardFontType.Helvetica);
                PdfPen pen = new PdfPen(Color.Red);
                PdfBrush brush = new PdfBrush(Color.Black);
                float fontSize = 12;

                string testString = "Multi-line test string:\nLine 1\nLine 2\nLine 3";

                PointF location = new PointF(10, 300);

                g.DrawString("Normal text", font, fontSize, brush, location.X, location.Y - 20);
                DrawTestString(g, font, fontSize, testString, location, 0);

                location.X += 150;
                g.DrawString("Tc: SetCharacterSpacing(3)", font, fontSize, brush, location.X, location.Y - 20);
                g.SaveGraphicsState();
                g.SetCharacterSpacing(3);
                DrawTestString(g, font, fontSize, testString, location, 0);
                g.RestoreGraphicsState();

                location.X += 200;
                g.DrawString("Tw: SetWordSpacing(10)", font, fontSize, brush, location.X, location.Y - 20);
                g.SaveGraphicsState();
                g.SetWordSpacing(10);
                DrawTestString(g, font, fontSize, testString, location, 0);
                g.RestoreGraphicsState();

                location.X = 10;
                location.Y -= 150;
                g.DrawString("Ts: SetTextRise(4)", font, fontSize, brush, location.X, location.Y - 20);
                g.SaveGraphicsState();
                g.SetTextRise(4);
                DrawTestString(g, font, fontSize, testString, location, 0);
                g.RestoreGraphicsState();


                location.X += 150;
                g.DrawString("Tz: SetHorizontalTextScaling(180) %", font, fontSize, brush, location.X, location.Y - 20);
                g.SaveGraphicsState();
                g.SetHorizontalTextScaling(180);
                DrawTestString(g, font, fontSize, testString, location, 0);
                g.RestoreGraphicsState();

                location.X += 230;
                g.DrawString("LineSpacing(8)", font, fontSize, brush, location.X, location.Y - 20);
                DrawTestString(g, font, fontSize, testString, location, 8);
            }
            OpenDocumentInViewer();
        }

        /// <summary>
        /// Handles the Click event of tilingPatternToolStripMenuItem object.
        /// </summary>
        private void tilingPatternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfPage page = CreateDocumentPage();

            // create pattern
            float cellWidth = (int)(10 + 10 * _random.NextDouble());
            float cellHeight = (int)(10 + 10 * _random.NextDouble());
            TilingPattern pattern = new TilingPattern(page.Document, cellWidth, cellHeight);
            using (PdfGraphics g = pattern.GetGraphics())
            {
                PdfPen pen = new PdfPen(Color.Blue);
                PdfBrush brush = new PdfBrush(Color.LightGreen);
                g.FillAndDrawEllipse(pen, brush, pattern.BoundingBox);
            }

            // fill polygon and ellipse use Tiling Pattern
            using (PdfGraphics g = page.GetGraphics())
            {
                PdfPen pen = new PdfPen(Color.Red);
                PdfBrush brush = new PdfBrush(pattern);

                g.FillAndDrawPolygon(pen, brush, RandomPoints);

                g.FillAndDrawEllipse(pen, brush, RandomRectangle);
            }

            OpenDocumentInViewer();
        }

        /// <summary>
        /// Handles the Click event of linearGradientToolStripMenuItem object.
        /// </summary>
        private void linearGradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfPage page = CreateDocumentPage();

            // fill rectangles use LinearGradientBrush
            using (PdfGraphics g = page.GetGraphics(PdfGraphicsCreationMode.CreateNew))
            {
                using (PdfDrawingEngine drawingEngine = new PdfDrawingEngine(g, new Resolution(96), page.MediaBox))
                {
                    float width = page.MediaBox.Width;
                    float height = 100;
                    GradientStop[] gradientColors = new GradientStop[] {
                    new GradientStop(Color.Red, 0),
                    new GradientStop(Color.Green, 0.5f),
                    new GradientStop(Color.Blue, 1) };

                    IDrawingLinearGradientBrush brush = drawingEngine.DrawingFactory.CreateLinearGradientBrush(new RectangleF(0, 0, width, height), 0, false, gradientColors);
                    drawingEngine.FillRectangle(brush, new RectangleF(0, 0, width, height));

                    brush.GradientStops = new GradientStop[] {
                    new GradientStop(Color.Red, 0),
                    new GradientStop(Color.LightGreen, 0.33f),
                    new GradientStop(Color.Pink, 0.5f),
                    new GradientStop(Color.Yellow, 0.66f),
                    new GradientStop(Color.Blue, 1)
                };
                    drawingEngine.FillRectangle(brush, new RectangleF(0, 1 * (height + 10), width, height));

                    brush = drawingEngine.DrawingFactory.CreateLinearGradientBrush(new RectangleF(0, 0, width / 5, height / 5), 45, false, gradientColors);
                    drawingEngine.FillRectangle(brush, new RectangleF(0, 2 * (height + 10), width, height * 2));
                }
            }

            OpenDocumentInViewer();
        }


        #endregion


        #region 'Interactive Form Fields' menu

        /// <summary>
        /// Handles the Click event of buttonToolStripMenuItem object.
        /// </summary>
        private void buttonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfDocument document = CreateSinglePageDocument())
            {
                using (PdfGraphics g = document.Pages[0].GetGraphics())
                {
                    GraphicsFigure report = new ButtonFieldsSample(document.Pages[0], g, FontSize, showLogoToolStripMenuItem.Checked);
                    report.Draw(g);
                }
                document.SaveChanges();
            }
            imageViewer1.Images.Clear();
            imageViewer1.Images.Add(_documentStream);
        }

        /// <summary>
        /// Handles the Click event of textToolStripMenuItem object.
        /// </summary>
        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfDocument document = CreateSinglePageDocument())
            {
                using (PdfGraphics g = document.Pages[0].GetGraphics())
                {
                    GraphicsFigure report = new TextFieldsSample(document.Pages[0], g, FontSize, showLogoToolStripMenuItem.Checked);
                    report.Draw(g);
                }
                document.SaveChanges();
            }
            imageViewer1.Images.Clear();
            imageViewer1.Images.Add(_documentStream);
        }

        /// <summary>
        /// Handles the Click event of listBoxToolStripMenuItem object.
        /// </summary>
        private void listBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfDocument document = CreateSinglePageDocument())
            {
                using (PdfGraphics g = document.Pages[0].GetGraphics())
                {
                    GraphicsFigure report = new ListBoxComboBoxFieldsSample(document.Pages[0], g, FontSize, showLogoToolStripMenuItem.Checked);
                    report.Draw(g);
                }
                document.SaveChanges();
            }
            imageViewer1.Images.Clear();
            imageViewer1.Images.Add(_documentStream);
        }

        /// <summary>
        /// Handles the Click event of checkBoxRadioButtonsToolStripMenuItem object.
        /// </summary>
        private void checkBoxRadioButtonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfDocument document = CreateSinglePageDocument())
            {
                using (PdfGraphics g = document.Pages[0].GetGraphics())
                {
                    GraphicsFigure report = new CheckBoxRadioButtonFieldsSample(document.Pages[0], g, FontSize, showLogoToolStripMenuItem.Checked);
                    report.Draw(g);
                }
                document.SaveChanges();
            }
            imageViewer1.Images.Clear();
            imageViewer1.Images.Add(_documentStream);
        }

        /// <summary>
        /// Handles the Click event of digitalSignatureToolStripMenuItem object.
        /// </summary>
        private void digitalSignatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfDocument document = CreateSinglePageDocument())
            {
                using (PdfGraphics g = document.Pages[0].GetGraphics())
                {
                    GraphicsFigure report = new SignatureFieldsSample(document.Pages[0], g, FontSize, showLogoToolStripMenuItem.Checked);
                    report.Draw(g);
                }
                document.SaveChanges();
            }
            imageViewer1.Images.Clear();
            imageViewer1.Images.Add(_documentStream);
        }

        /// <summary>
        /// Handles the Click event of barcodeFieldsToolStripMenuItem object.
        /// </summary>
        private void barcodeFieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_BARCODE_SDK
            try
            {
                using (PdfDocument document = CreateSinglePageDocument())
                {
                    using (PdfGraphics g = document.Pages[0].GetGraphics())
                    {
                        GraphicsFigure report = new BarcodeFieldsSample(document.Pages[0], g, FontSize, showLogoToolStripMenuItem.Checked);
                        report.Draw(g);
                    }
                    document.SaveChanges();
                }
                imageViewer1.Images.Clear();
                imageViewer1.Images.Add(_documentStream);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
#endif
        }

        /// <summary>
        /// Handles the Click event of testActionsToolStripMenuItem object.
        /// </summary>
        private void testActionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (PdfDocument document = CreateSinglePageDocument())
                {
                    // add second page
                    PdfPage secondPage = document.Pages.Add(PaperSizeKind.A4);
                    using (PdfGraphics g = PdfGraphics.FromPage(secondPage))
                    {
                        PdfFont font = document.FontManager.GetStandardFont(PdfStandardFontType.TimesRoman);
                        g.DrawString("Test Page", font, 30, new PdfBrush(Color.Black), secondPage.MediaBox, PdfContentAlignment.Center, false);
                    }

                    using (PdfGraphics g = document.Pages[0].GetGraphics())
                    {
                        ActionsSample sample = new ActionsSample(document.Pages[0], g, FontSize, showLogoToolStripMenuItem.Checked);
                        sample.Draw(g);
                    }
                    document.SaveChanges();
                }
                imageViewer1.Images.Clear();
                imageViewer1.Images.Add(_documentStream);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        #endregion

        
        #region 'Table' menu

        /// <summary>
        /// Handles the Click event of colorTableToolStripMenuItem object.
        /// </summary>
        private void colorTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfDocument document = CreateSinglePageDocument())
            {
                using (PdfGraphics g = document.Pages[0].GetGraphics())
                {
                    GraphicsFigure report = new TableBasedColorTable(document.Pages[0], g, FontSize, 25, showLogoToolStripMenuItem.Checked);
                    report.Draw(g);
                }
                document.SaveChanges();
            }
            imageViewer1.Images.Clear();
            imageViewer1.Images.Add(_documentStream);
        }

        /// <summary>
        /// Handles the Click event of fontSymbolsToolStripMenuItem1 object.
        /// </summary>
        private void fontSymbolsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (PdfDocument document = CreateEmptyDocument())
            {
                CreateFontForm dialog = new CreateFontForm(document);
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    _documentStream.Dispose();
                    _documentStream = null;
                    return;
                }

                FontSymbolsReport fontSymbols = new FontSymbolsReport(document, dialog.SelectedFont);
                fontSymbols.ShowLogo = showLogoToolStripMenuItem.Checked;
                fontSymbols.FontSize = FontSize;
                fontSymbols.PageSize = PageSize;

                // generate pages
                PdfPage[] pages = fontSymbols.GenerateFontSymbolsReport();

                // add pages to PDF document
                document.Pages.AddRange(pages);

                document.SaveChanges();
            }
            imageViewer1.Images.Clear();
            imageViewer1.Images.Add(_documentStream);
        }

        #endregion


        #region 'Test' menu

        /// <summary>
        /// Handles the Click event of alignmentPanelElementContentAlignmentToolStripMenuItem object.
        /// </summary>
        private void alignmentPanelElementContentAlignmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfDocument document = CreateSinglePageDocument())
            {
                TextBoxFigure sourceTextBox = new TextBoxFigure(new PdfBrush(Color.Black), "", document.FontManager.GetStandardFont(PdfStandardFontType.Courier), FontSize);
                sourceTextBox.AutoHeight = true;
                sourceTextBox.AutoWidth = true;
                sourceTextBox.Pen = new PdfPen(Color.DarkRed);
                sourceTextBox.Margin = new PdfContentPadding(FontSize);
                sourceTextBox.TextPadding = new PdfContentPadding(FontSize / 3);
                TextBoxFactory textFactory = new TextBoxFactory(sourceTextBox);

                SizeF pageSize = document.Pages[0].MediaBox.Size;
                using (PdfGraphics g = document.Pages[0].GetGraphics())
                {
                    DrawTestPanel(textFactory, g, pageSize, PdfContentAlignment.Center);

                    DrawTestPanel(textFactory, g, pageSize, PdfContentAlignment.Left);
                    DrawTestPanel(textFactory, g, pageSize, PdfContentAlignment.Right);
                    DrawTestPanel(textFactory, g, pageSize, PdfContentAlignment.Top);

                    DrawTestPanel(textFactory, g, pageSize, PdfContentAlignment.Top | PdfContentAlignment.Right);

                    DrawTestPanel(textFactory, g, pageSize, PdfContentAlignment.Top | PdfContentAlignment.Bottom | PdfContentAlignment.Left);
                    DrawTestPanel(textFactory, g, pageSize, PdfContentAlignment.Top | PdfContentAlignment.Bottom | PdfContentAlignment.Right);

                    DrawTestPanel(textFactory, g, pageSize, PdfContentAlignment.Left | PdfContentAlignment.Right | PdfContentAlignment.Top);
                    DrawTestPanel(textFactory, g, pageSize, PdfContentAlignment.Left | PdfContentAlignment.Right | PdfContentAlignment.Bottom);
                }
                document.SaveChanges();
            }
            imageViewer1.Images.Clear();
            imageViewer1.Images.Add(_documentStream);
        }

        /// <summary>
        /// Handles the Click event of optionalContentToolStripMenuItem object.
        /// </summary>
        private void optionalContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PdfDocument document = CreateSinglePageDocument())
            {
                // create optional content groups (layers)
                PdfOptionalContentGroup logoLayer = new PdfOptionalContentGroup(document, "Logo");
                PdfOptionalContentGroup layer1 = new PdfOptionalContentGroup(document, "Layer1");
                PdfOptionalContentGroup layer2 = new PdfOptionalContentGroup(document, "Layer2");

                // add optional content groups (layers) to OptionalContentProperties
                document.OptionalContentProperties = new PdfOptionalContentProperties(document);
                document.OptionalContentProperties.OptionalContentGroups.Add(logoLayer);
                document.OptionalContentProperties.OptionalContentGroups.Add(layer1);
                document.OptionalContentProperties.OptionalContentGroups.Add(layer2);

                // get PdfGraphics of PDF page
                using (PdfGraphics g = document.Pages[0].GetGraphics())
                {
                    PdfFont font = document.FontManager.GetStandardFont(PdfStandardFontType.TimesRoman);
                    PdfBrush brush = new PdfBrush(Color.Black);
                    PdfBrush brush1 = new PdfBrush(Color.Green);
                    PdfBrush brush2 = new PdfBrush(Color.Red);

                    // get media box of PDF page
                    RectangleF bbox = document.Pages[0].MediaBox;

                    // load logo image
                    using (VintasoftImage logoImage = DemosResourcesManager.GetResourceAsImage("VintasoftLogo.png"))
                    {
                        // create PDF image-resource based on logo image
                        PdfImageResource logoResource = new PdfImageResource(font.Document, logoImage, PdfCompression.Auto);
                        logoResource.Interpolate = true;
                        // add logoResource to the "Logo" layer
                        logoResource.OptionalContentGroup = logoLayer;
                        // draw logo on PDF page
                        g.DrawImage(logoResource, new RectangleF((bbox.Width - logoResource.Width) / 2, bbox.Height - logoResource.Height * 2, logoResource.Width, logoResource.Height));
                    }

                    // draw not optional content
                    g.DrawString("Not optional content", font, 20, brush, new PointF(50, 650));

                    // draw an optional content on "Layer1"
                    g.BeginOptionalContent(layer1);
                    g.DrawString(string.Format("Optional content '{0}'", layer1.Name),
                        font, 25, brush1, new PointF(50, 550));
                    g.EndOptionalContent();

                    // draw not optional content
                    g.DrawString("Not optional content", font, 30, brush, new PointF(50, 450));

                    // draw an optional content on "Layer2"
                    g.BeginOptionalContent(layer2);
                    g.DrawString(string.Format("Optional content '{0}'", layer2.Name),
                        font, 35, brush2, new PointF(50, 350));
                    g.EndOptionalContent();

                    // draw not optional content
                    g.DrawString("Not optional content", font, 40, brush, new PointF(50, 250));
                }

                // create optional content configurations

                PdfOptionalContentConfiguration configuration1 =
                    new PdfOptionalContentConfiguration(document, "Layer1 and Layer2");
                configuration1.SetGroupVisibility(logoLayer, true);
                configuration1.SetGroupVisibility(layer1, true);
                configuration1.SetGroupVisibility(layer2, true);

                PdfOptionalContentConfiguration configuration2 =
                    new PdfOptionalContentConfiguration(document, "Layer1");
                configuration2.SetGroupVisibility(logoLayer, true);
                configuration2.SetGroupVisibility(layer1, true);
                configuration2.SetGroupVisibility(layer2, false);

                PdfOptionalContentConfiguration configuration3 =
                    new PdfOptionalContentConfiguration(document, "Layer2");
                configuration3.SetGroupVisibility(logoLayer, true);
                configuration3.SetGroupVisibility(layer1, false);
                configuration3.SetGroupVisibility(layer2, true);

                PdfOptionalContentConfiguration configuration4 =
                    new PdfOptionalContentConfiguration(document, "No Layers");
                configuration4.SetGroupVisibility(logoLayer, true);
                configuration4.SetGroupVisibility(layer1, false);
                configuration4.SetGroupVisibility(layer2, false);

                // create list of optional content configurations
                document.OptionalContentProperties.Configurations =
                    new PdfOptionalContentConfigurationList(document);

                // add configurations to the list
                document.OptionalContentProperties.Configurations.Add(configuration1);
                document.OptionalContentProperties.Configurations.Add(configuration2);
                document.OptionalContentProperties.Configurations.Add(configuration3);
                document.OptionalContentProperties.Configurations.Add(configuration4);

                // set default configuration
                document.OptionalContentProperties.DefaultConfiguration = configuration1;

                // set presentation order
                configuration1.PresentationOrder =
                    new PdfOptionalContentPresentationOrder(document, logoLayer, layer1, layer2);

                // specify that optional content panel must be visible when document is opened
                document.DocumentViewMode = PdfDocumentViewMode.UseOC;

                // save changes in PDF document
                document.SaveChanges();
            }
            imageViewer1.Images.Clear();
            imageViewer1.Images.Add(_documentStream);
        }

        #endregion


        #region 'Help' menu

        /// <summary>
        /// Handles the Click event of aboutToolStripMenuItem object.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBoxForm aboutDialog = new AboutBoxForm())
            {
                aboutDialog.ShowDialog();
            }
        }

        #endregion

        #endregion


        #region Primitives drawing

        /// <summary>
        /// Draws multiple lines of primitives with different values of alpha channel.
        /// </summary>
        /// <param name="g">An instance of <see cref="PdfGraphics"/>.</param>
        /// <param name="page">The PDF page.</param>
        private void AlphaTest(PdfGraphics g, PdfPage page)
        {
            float x = 10;
            float y = 10;
            int cellAlphaLength = 3;
            float cellW = (page.MediaBox.Width - x * 2) / (256 / cellAlphaLength);
            float cellH = page.MediaBox.Height / 40;
            AlphaTest(g, Color.Black, x, y, cellW, cellH, 4);
            y += cellH + 1;
            AlphaTest(g, Color.Red, x, y, cellW, cellH, 4);
            y += cellH + 1;
            AlphaTest(g, Color.Green, x, y, cellW, cellH, 4);
            y += cellH + 1;
            AlphaTest(g, Color.Blue, x, y, cellW, cellH, 4);
        }

        /// <summary>
        /// Draws a line of rectangles with different value of alpha channel.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="alphaColor">Color of the rectangle.</param>
        /// <param name="x">Start point x coordinate.</param>
        /// <param name="y">Start point y coordinate..</param>
        /// <param name="width">Single rectangle width.</param>
        /// <param name="height">Single rectangle height.</param>
        /// <param name="alphaStep">The alpha value step.</param>
        private void AlphaTest(
            PdfGraphics g,
            Color alphaColor,
            float x,
            float y,
            float width,
            float height,
            int alphaStep)
        {
            int currentAlpha = 255;
            PdfBrush brush = new PdfBrush(alphaColor);
            while (currentAlpha > 0)
            {
                brush.Color = Color.FromArgb(currentAlpha, alphaColor);
                g.FillRectangle(brush, x, y, width, height);
                x += width + 1;
                currentAlpha -= alphaStep;
            }
        }

        /// <summary>
        /// Draws the string.
        /// </summary>
        /// <param name="g">An instance of <see cref="PdfGraphics"/>.</param>
        private void DrawTextString(PdfGraphics g)
        {
            PdfStandardFontType fontType = (PdfStandardFontType)(1 + _random.Next(10));
            PdfFont font = _document.FontManager.GetStandardFont(fontType);

            g.DrawString("Text string (fill)", font, RandomFontSize, RandomBrush, RandomPoint);

            g.SaveGraphicsState();

            g.SetTextRenderingMode(TextRenderingMode.Stroke);
            g.SetPen(new PdfPen(Color.Green, 1));
            g.DrawString("Text string (stroke)", font, RandomFontSize, null, RandomPoint);

            g.SetTextRenderingMode(TextRenderingMode.FillAndStroke);
            g.SetPen(new PdfPen(Color.Green, 2));
            g.SetBrush(new PdfBrush(Color.Red));
            g.DrawString("Text string (fill & stroke)", font, RandomFontSize, null, RandomPoint);

            g.RestoreGraphicsState();
        }

        /// <summary>
        /// Draws a vector string.
        /// </summary>
        /// <param name="g">An instance of <see cref="PdfGraphics"/>.</param>
        private void DrawVectorString(PdfGraphics g)
        {
            using (IGraphicsPath path = DrawingFactory.Default.CreateGraphicsPath())
            using (GdiFont font = new GdiFont(new Font(Font.FontFamily, RandomFontSize), true))
            {
                g.DrawString("Vector string", font, RandomBrush, RandomPoint);
            }            
        }

        /// <summary>
        /// Draws random curves.
        /// </summary>
        /// <param name="g">An instance of <see cref="PdfGraphics"/>.</param>
        private void DrawCurves(PdfGraphics g)
        {
            for (int i = 0; i < FIGURES_COUNT; i++)
                g.DrawCurve(RandomPen, RandomPoint, RandomPoint, RandomPoint, RandomPoint);
        }

        /// <summary>
        /// Draws random ellipses.
        /// </summary>
        /// <param name="g">An instance of <see cref="PdfGraphics"/>.</param>
        private void DrawEllipses(PdfGraphics g)
        {
            for (int i = 0; i < FIGURES_COUNT; i++)
                if (_random.Next(2) == 1)
                    g.DrawEllipse(RandomPen, RandomRectangle);
                else
                    g.FillEllipse(RandomBrush, RandomRectangle);
        }

        /// <summary>
        /// Draws random graphics paths.
        /// </summary>
        /// <param name="g">An instance of <see cref="PdfGraphics"/>.</param>
        private void DrawGraphicsPath(PdfGraphics g)
        {
            using (IGraphicsPath gp = DrawingFactory.Default.CreateGraphicsPath())
            {
                gp.AddEllipse(RandomRectangle);
                gp.AddRectangle(RandomRectangle);
                gp.AddString("Graphics Path", new GdiFont(Font, false), RandomPoint, 0);

                AffineMatrix rotate45 = AffineMatrix.CreateRotation(_random.NextDouble() * 45f);
                gp.Transform(rotate45);

                g.FillPath(RandomBrush, gp);
            }
        }

        /// <summary>
        /// Draws a random polygon.
        /// </summary>
        /// <param name="g">An instance of <see cref="PdfGraphics"/>.</param>
        private void DrawPolygon(PdfGraphics g)
        {
            PdfPen pen = RandomPen;
            pen.Width = 1;
            g.DrawPolygon(pen, RandomPoints);
        }

        /// <summary>
        /// Draws random rectangles.
        /// </summary>
        /// <param name="g">An instance of <see cref="PdfGraphics"/>.</param>
        private void DrawRectangles(PdfGraphics g)
        {
            for (int i = 0; i < FIGURES_COUNT; i++)
            {
                if (_random.Next(2) == 1)
                    g.DrawRectangle(RandomPen, RandomRectangle);
                else
                    g.FillRectangle(RandomBrush, RandomRectangle);
            }
        }

        /// <summary>
        /// Draws random lines.
        /// </summary>
        /// <param name="g">An instance of <see cref="PdfGraphics"/>.</param>
        private void DrawLines(PdfGraphics g)
        {
            for (int i = 0; i < FIGURES_COUNT; i++)
                g.DrawLine(RandomPen, RandomPoint, RandomPoint);
        }

        /// <summary>
        /// Draws the specified text string in the specified rectangle.
        /// </summary>
        /// <param name="g">Instance of <see cref="PdfGraphics"/>.</param>
        /// <param name="font">The text font.</param>
        /// <param name="fontSize">Font size.</param>
        /// <param name="rect"><see cref="RectangleF"/> that specifies the location of the drawn text.</param>
        /// <param name="brush"><see cref="PdfBrush"/> that determines the color of the drawn text.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="contentAlignment">The content alignment.</param>
        private void DrawTestString(PdfGraphics g, PdfFont font, float fontSize, RectangleF rect, PdfBrush brush, string text, PdfContentAlignment contentAlignment)
        {
            g.DrawString(text, font, fontSize, brush, rect, contentAlignment, true);
        }

        /// <summary>
        /// Draws the specified text string in the specified location.
        /// </summary>
        /// <param name="g">Instance of <see cref="PdfGraphics"/>.</param>
        /// <param name="font">The text font.</param>
        /// <param name="fontSize">Font size.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="location">The location.</param>
        /// <param name="lineSpacing">The line spacing.</param>
        private void DrawTestString(PdfGraphics g, PdfFont font, float fontSize, string text, PointF location, float lineSpacing)
        {
            float width, height;
            PdfPen pen = new PdfPen(Color.Red);
            PdfBrush brush = new PdfBrush(Color.Black);
            g.MeasureString(text, font, fontSize, 1000, false, lineSpacing, out width, out height);
            g.DrawRectangle(pen, location.X, location.Y, width, height);
            g.DrawString(text, font, fontSize, brush, location.X, location.Y, width, height, PdfContentAlignment.Left | PdfContentAlignment.Top, false, lineSpacing);
        }

        #endregion


        #region Common

        /// <summary>
        /// Creates the PDF document page.
        /// </summary>
        /// <returns>New <see cref="PdfPage"/>.</returns>
        private PdfPage CreateDocumentPage()
        {
            PdfDocument document = CreateSinglePageDocument();

            return document.Pages[0];
        }

        /// <summary>
        /// Renders the PDF page.
        /// </summary>
        private void OpenDocumentInViewer()
        {
            _document.SaveChanges();
            imageViewer1.Images.Clear();
            imageViewer1.Images.Add(_documentStream);
        }


        #endregion


        /// <summary>
        /// Draws a panel with elements alignment.
        /// </summary>
        /// <param name="textFactory">The factory of textboxes.</param>
        /// <param name="g">An instance of <see cref="PdfGraphics"/>.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="alignment">Content alignment mode.</param>
        private void DrawTestPanel(TextBoxFactory textFactory, PdfGraphics g, SizeF pageSize, PdfContentAlignment alignment)
        {
            AlignmentPanel panel = new AlignmentPanel();
            panel.Size = pageSize;
            panel.ContentAlignment = alignment;
            panel.Content = textFactory.Create(alignment.ToString());
            panel.Pen = new PdfPen(Color.Black);
            panel.Margin = new PdfContentPadding(FontSize);
            panel.Draw(g);
        }

        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the window message to process. </param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process. </param>
        /// <returns>
        /// <b>true</b> if the character was processed by the control; otherwise, <b>false</b>.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (imageViewer1.Focused && imageViewer1.VisualTool != null)
            {
                if (keyData == Keys.Tab)
                {
                    if (imageViewer1.VisualTool.PerformNextItemSelection(true))
                        return true;
                }
                else if (keyData == (Keys.Shift | Keys.Tab))
                {
                    if (imageViewer1.VisualTool.PerformNextItemSelection(false))
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Saves generated report to PDF file. 
        /// </summary>
        /// <param name="filename">Saving file name.</param>
        private void SaveToFile(string filename)
        {
            using (Stream stream = File.Create(filename))
            {
                lock (_document)
                {
                    _documentStream.Position = 0;
                    byte[] buffer = new byte[Math.Min(8192, (int)_documentStream.Length)];
                    while (true)
                    {
                        int count = _documentStream.Read(buffer, 0, buffer.Length);
                        if (count > 0)
                            stream.Write(buffer, 0, count);
                        else
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Creates a single page PDF document.
        /// </summary>
        /// <returns>New single page PDF document.</returns>
        private PdfDocument CreateSinglePageDocument()
        {
            PdfDocument document = CreateEmptyDocument();
            document.Pages.Add(PageSize);
            return document;
        }

        /// <summary>
        /// Creates an empty PDF document.
        /// </summary>
        /// <returns>New empty PDF document.</returns>
        private PdfDocument CreateEmptyDocument()
        {
            if (_documentStream != null)
                _documentStream.Dispose();
            _documentStream = new MemoryStream();
            _document = new PdfDocument(_documentStream, PdfFormat.Pdf_14);
            return _document;
        }

        #endregion
    }
}
