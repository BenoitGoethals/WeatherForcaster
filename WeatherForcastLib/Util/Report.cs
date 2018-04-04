using System;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;


namespace WeatherForcastLib.Util
{
    public abstract class Report
    {


        protected const String DEST = "c:/temp/rick_astley.pdf";


        protected ICurrentWeatherReport CurrentWeatherReport;


        /// <exception cref="System.IO.IOException"/>
        protected virtual void CreatePdf(String dest)
        {
           
        }

        protected void Generate()
        {
            
        }

        protected void GenerateSave()
        {

        }

        protected void Save()
        {
            
        }
    }
}