using System;
using System.Reflection;
using Aspose.Words;
using Aspose.Words.Reporting;
using Newtonsoft.Json;

namespace MyLambdaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectRootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string jsonInputPath = Path.Combine(projectRootPath, "..", "..", "..", "..", "person.json");
            string templatePath = Path.Combine(projectRootPath, "..", "..", "..", "..", "template.docx");
            string pdfOutputPath = CreatePdfFromTemplate(jsonInputPath, templatePath);

           Console.WriteLine($"PDF created at: {pdfOutputPath}");
        }

        static string CreatePdfFromTemplate(string jsonInput, string templatePath)
        {
            Document doc = new Document(templatePath);              // Loading a template document.
            JsonDataSource dataSource = new JsonDataSource(jsonInput); // Loading JSON.

            ReportingEngine engine = new ReportingEngine();
            engine.BuildReport(doc, dataSource);

            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string pdfOutputPath = Path.Combine(Path.GetDirectoryName(templatePath), $"OutputDocument-{timestamp}.pdf");
            doc.Save(pdfOutputPath, SaveFormat.Pdf);

            return pdfOutputPath;
        }
    }
}