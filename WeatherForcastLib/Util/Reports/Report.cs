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
        
        protected const String DEST = "c:/temp/rick_astley.pdf";


        protected ICurrentWeatherReport CurrentWeatherReport;


        /// <exception cref="System.IO.IOException"/>
        protected virtual void CreatePdf(String dest)
        {
           
        }

        public void Generate()
        {
            CurrentWeatherReport.MakeHeather();
            CurrentWeatherReport.MakBody();
            CurrentWeatherReport.MakeFooter();
            CurrentWeatherReport.MakeHeather();
            //Initialize PDF writer
            PdfWriter writer = new PdfWriter(DEST);
            //Initialize PDF document
            PdfDocument pdf = new PdfDocument(writer);
            // Initialize document
            Document document = new Document(pdf);
            // Create a PdfFont
            PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);
            // Add a Paragraph
            document.Add(new Paragraph("iText is:").SetFont(font));
            // Create a List
            List list = new List().SetSymbolIndent(12).SetListSymbol("\u2022").SetFont(font);
            // Add ListItem objects
            list.Add(new ListItem("Never gonna give you up")).Add(new ListItem("Never gonna let you down")).Add(new ListItem
                ("Never gonna run around and desert you")).Add(new ListItem("Never gonna make you cry")).Add(new ListItem
                ("Never gonna say goodbye")).Add(new ListItem("Never gonna tell a lie and hurt you"));
            // Add the list
            document.Add(list);
            //Close document
            document.Close();
        }

        protected void GenerateSave()
        {

        }

        protected void Save()
        {
            
        }
    }
}