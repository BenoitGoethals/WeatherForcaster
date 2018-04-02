using System;
using System.Collections.Generic;
using System.Linq;
using WeatherForcastLib.Model;

namespace WeatherForcastLib.BL
{
    public class Statics
    {

        private Dictionary<string,SortedSet<WeatherData>> _datas = new Dictionary<string, SortedSet<WeatherData>>();
        
        public void Add(WeatherData weatherData)
        {
            string city = weatherData.City;
            if (!_datas.ContainsKey(city))
            {
                    _datas.Add(city,new SortedSet<WeatherData>(WeatherData.UpdateWeatherComparer));
            }
            var set = _datas[city];
            set.Add(weatherData);
           
        }




        public WeatherData GetMaxTemp()
        {
            return new WeatherData();
        }

        public WeatherData GetMaxTemp(string city)

        {
            SortedSet<WeatherData> dat = _datas[city];
         

            return dat.First(x => x.Temperature == dat.Max(y => y.Temperature));
        }


       


        public double GetAverage(string city)
        {
            return 0.0;
        }

        public double GetAverage()
        {
            return 0.0;
        }


        public WeatherData GetMin(string city)
        {
            return new WeatherData();
        }

        public WeatherData GetMin()
        {
            return new WeatherData();
        }




        public List<String> GetAllCity()
        {
            return _datas.Keys.ToList();
        }

    }
}