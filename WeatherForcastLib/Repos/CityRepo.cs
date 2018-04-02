using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForcastLib.Repos
{
   public  abstract class CityRepo
    {


        public static List<String> Cities()
        {
           
            var query = from data in GetDataPerLines("WeatherForcastLib.zip.csv")
                let splitChr = data.Split(";".ToCharArray())

                where splitChr[0]!=null
                        select splitChr[0];
                
            return query.ToList<string>();
        }



        private static IEnumerable<String> GetDataPerLines(string file)
        {
            //FileStream aFile = new FileStream(file, FileMode.Open);
            StreamReader sr = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(file) ?? throw new InvalidOperationException());
            string line;
            sr.ReadLine();
            while ((line = sr.ReadLine()) != null)
            {
                yield return line;
            }
            sr.Close();
        }


    }
}
