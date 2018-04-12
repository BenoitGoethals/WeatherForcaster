using DALMongoDb;
using System.Collections.Generic;
using WeatherFocastCommonClassLibrary;
using WeatherForcastLib.BL;
using WeatherForcastLib.Model;

namespace WeatherForcastLib.Service
{
    public class WeatherSevice
    {
        private WeatherWebRetrieverService _weatherWebRetrieverService=new WeatherWebRetrieverService();
        private MongoService _dataRepo = new MongoService();


        
        public List<WeatherData> GetWeatherDatas()
        {
            return _dataRepo.GetWeatherDatas();


        }

        
        public WeatherStatics GetWeatherStatics()
        {
            return _dataRepo.GetWeatherStatics();

        }

        
        public void StoreDataWeather(List<string> datas, string country)
        {

            var bulk=_weatherWebRetrieverService.GetWeatherBulkNow(datas, country);
            _dataRepo.AddBulk(bulk.AllWeatherDatas().ToArray());
        }

        public void StoreDataWeather(string postCode, string country)
        {
            var bulk = _weatherWebRetrieverService.GetWeatherDataNow(postCode, country);
            _dataRepo.Add(bulk);
        }


       

    }
}