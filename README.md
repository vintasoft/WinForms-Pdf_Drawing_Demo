# VintaSoft WinForms PDF Drawing Demo

This C# project uses <a href="https://www.vintasoft.com/vsimaging-dotnet-index.html">VintaSoft Imaging .NET SDK</a> and demonstrates how to draw graphics on PDF page in WinForms:
* Draw graphic primitives on PDF page.
* Draw graphic figures on PDF page.
* Generate reports on the fly.
* Create PDF documents with interactive forms.


## Screenshot
<img src="vintasoft-pdf-drawing-demo.png" alt="VintaSoft PDF Drawing Demo">


## Usage
1. Get the 30 day free evaluation license for <a href="https://www.vintasoft.com/vsimaging-dotnet-index.html" target="_blank">VintaSoft Imaging .NET SDK</a> as described here: <a href="https://www.vintasoft.com/docs/vsimaging-dotnet/Licensing-Evaluation.html" target="_blank">https://www.vintasoft.com/docs/vsimaging-dotnet/Licensing-Evaluation.html</a>

2. Update the evaluation license in "CSharp\MainForm.cs" file:
   ```
   Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");
   ```

3. Build the project ("PdfDrawingDemo.Net7.csproj" file) in Visual Studio or using .NET CLI:
   ```
   dotnet build PdfDrawingDemo.Net7.csproj
   ```

4. Run compiled application and try to draw graphics on PDF page.


## Documentation
VintaSoft Imaging .NET SDK on-line User Guide and API Reference for .NET developer is available here: https://www.vintasoft.com/docs/vsimaging-dotnet/


## Support
Please visit our <a href="https://myaccount.vintasoft.com/">online support center</a> if you have any question or problem.
