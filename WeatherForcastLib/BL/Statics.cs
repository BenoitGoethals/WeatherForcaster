using System;
using System.Collections.Generic;
using System.Diagnostics;
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




        public double GetMaxTemp()
        {
            List<double> doubles=new List<double>();
            foreach (SortedSet<WeatherData> dat in _datas.Values)
            {
               doubles.Add(dat.Max.Temperature);
            }

            return doubles.Max();
        }

        public WeatherData GetMaxTemp(string city)

        {
            SortedSet<WeatherData> dat = _datas?[city];
          

            return  dat?.First(x => x.Temperature == dat.Max(y => y.Temperature));
        }


       


        public double GetAverage(string city)
        {
            SortedSet<WeatherData> dat = _datas?[city];


            Debug.Assert(dat != null, nameof(dat) + " != null");
            return dat.Average(x => x.Temperature);
        }

        public double GetAverage()
        {


            List<double> doubles = new List<double>();
            foreach (SortedSet<WeatherData> dat in _datas.Values)
            {
                doubles.Add(dat.Average(x=>x.Temperature));
            }

            return doubles.Average();
        }


        public WeatherData GetMin(string city)
        {
            SortedSet<WeatherData> dat = _datas?[city];


            return dat?.First(x => x.Temperature == dat.Min(y => y.Temperature));
        }

        public double GetMin()
        {
           var doubles = new List<double>();
            foreach (SortedSet<WeatherData> dat in _datas.Values)
            {
                doubles.Add(dat.Min.Temperature);
            }

            return doubles.Min();
        }




        public List<String> GetAllCity()
        {
            return _datas.Keys.ToList();
        }

    }
}