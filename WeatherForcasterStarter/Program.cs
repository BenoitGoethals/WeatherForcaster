using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WeatherForcastLib.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace WeatherForcasterStarter
{
    class Program
    {
        static void Main(string[] args)
        {
        
            var urlTemplate = "http://api.openweathermap.org/data/2.5/weather?zip=9000,be&mode=xml&appid={0}";
            var url = string.Format(urlTemplate, "03abf0d0b72e5c8b41d6b4dc9fcdd6c9");

            var request = WebRequest.Create(url);
            var response = request.GetResponse();
        //    Console.WriteLine(response.GetResponseStream().Length);
           var s = new XmlSerializer(typeof(Current));
          var timezoneDbInfo = (Current)s.Deserialize(response.GetResponseStream() ?? throw new InvalidOperationException());

            Console.WriteLine(timezoneDbInfo);
            Document doc = new Document(PageSize.A4);
            var output = new FileStream(("c:/temp/MyFirstPDF.pdf"), FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, output);


            doc.Open();


            var logo = iTextSharp.text.Image.GetInstance("c:/temp/22.jpg");
            logo.SetAbsolutePosition(430, 770);
            logo.ScaleAbsoluteHeight(30);
            logo.ScaleAbsoluteWidth(70);
            doc.Add(logo);

            PdfPTable table1 = new PdfPTable(2);
            table1.DefaultCell.Border = 0;
            table1.WidthPercentage = 80;


            PdfPCell cell11 = new PdfPCell();
            cell11.Colspan = 1;
            cell11.AddElement(new Paragraph("dsfdsf"));

            cell11.AddElement(new Paragraph("ffdgfdg"));


            cell11.VerticalAlignment = Element.ALIGN_LEFT;

            PdfPCell cell12 = new PdfPCell();


            cell12.VerticalAlignment = Element.ALIGN_CENTER;


            table1.AddCell(cell11);

            table1.AddCell(cell12);


            PdfPTable table2 = new PdfPTable(3);

            //One row added

            PdfPCell cell21 = new PdfPCell();

            cell21.AddElement(new Paragraph("Photo Type"));

            PdfPCell cell22 = new PdfPCell();

            cell22.AddElement(new Paragraph("No. of Copies"));

            PdfPCell cell23 = new PdfPCell();

            cell23.AddElement(new Paragraph("Amount"));


            table2.AddCell(cell21);

            table2.AddCell(cell22);

            table2.AddCell(cell23);


            //New Row Added

            PdfPCell cell31 = new PdfPCell();

            cell31.AddElement(new Paragraph("Safe"));

            cell31.FixedHeight = 300.0f;

            PdfPCell cell32 = new PdfPCell();

            cell32.AddElement(new Paragraph("2"));

            cell32.FixedHeight = 300.0f;

            PdfPCell cell33 = new PdfPCell();

            cell33.AddElement(new Paragraph("20.00 * " + "2" + " = " + (20 * Convert.ToInt32("2")) + ".00"));

            cell33.FixedHeight = 300.0f;



            table2.AddCell(cell31);

            table2.AddCell(cell32);

            table2.AddCell(cell33);


            PdfPCell cell2A = new PdfPCell(table2);

            cell2A.Colspan = 2;

            table1.AddCell(cell2A);

            PdfPCell cell41 = new PdfPCell();

            cell41.AddElement(new Paragraph("Name : " + "ABC"));

            cell41.AddElement(new Paragraph("Advance : " + "advance"));

            cell41.VerticalAlignment = Element.ALIGN_LEFT;

            PdfPCell cell42 = new PdfPCell();

            cell42.AddElement(new Paragraph("Customer ID : " + "011"));

            cell42.AddElement(new Paragraph("Balance : " + "3993"));

            cell42.VerticalAlignment = Element.ALIGN_RIGHT;


            table1.AddCell(cell41);

            table1.AddCell(cell42);


            doc.Add(table1);

            doc.Close();

            Console.ReadLine();


        }
    }
}
