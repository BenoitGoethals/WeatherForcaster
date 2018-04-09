using System;
using System.Net;
using System.Xml.Serialization;
using WeatherForcastLib.Model;

namespace WeatherForcastLib.Util
{
    public sealed class RestWeatherForcastUtil
    {
        private static readonly log4net.ILog Log
            = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static Current GetDataFromUrlByZipCode(string zip, string country, Mode mode=Mode.xml, string key = "")
        {
           var urlTemplate = "{0}?zip={1},{2}&mode={3}&appid={4}";
            var url = string.Format(urlTemplate, Resources.urlCurrent, zip,country, mode.ToString(), Resources.appiKey);
            Current valueCurrent;
          
            try
            {
                var request = WebRequest.Create(url);
                var response = request.GetResponse();
             
                var s = new XmlSerializer(typeof(Current));
                 valueCurrent = (Current)s.Deserialize(response.GetResponseStream() ?? throw new InvalidOperationException());
            }
            catch (WebException e)
            {
                Log.Error(url+"/n"+e.StackTrace);
                return null;
            }
           
            

            return valueCurrent;
        }
    }


    
}
