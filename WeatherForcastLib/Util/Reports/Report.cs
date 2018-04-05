using System;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace WeatherForcastLib.Util.Reports
{
    public abstract class Report
    {
      
        protected IWeatherReport WeatherReport;
        
        public Document Generate()
        {
            return GenerateDocument();
        }

        

        private Document GenerateDocument()
        {
            //Initialize PDF writer
            PdfWriter writer = new PdfWriter(Resources.pdf + "/" + WeatherReport.GetNameReport() + ".pdf");
            //Initialize PDF document
            PdfDocument pdf = new PdfDocument(writer);
            // Initialize document
            Document document = new Document(pdf);
            // Create a PdfFont

            // Add a Paragraph
            WeatherReport.MakeHeather(document);
            WeatherReport.MakBody(document);
            WeatherReport.MakeFooter(document);


            document.Close();
            return document;
        }


        public override string ToString()
        {
            return $"{nameof(WeatherReport)}: {WeatherReport}";
        }
    }
}