using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WeatherFocastCommonClassLibrary;
using WeatherForcastLib.BL;
using WeatherForcastLib.Model;

namespace DALMongoDb
{
   public sealed class MongoService
    {


        private readonly MongoDbWeatherDataRepo _dataRepo=new MongoDbWeatherDataRepo();

        public void Add(WeatherData weatherData)

        {
            _dataRepo.Add(weatherData);
            

        }


        public void AddBulk(params WeatherData[] weatherDatas)
        {

            _dataRepo.AddBulk(weatherDatas);
         

        }


        
        public List<WeatherData> GetWeatherDatas()
        {
            return _dataRepo.GetWeatherDatas();

           
        }



        public WeatherStatics GetWeatherStatics()
        {
            return _dataRepo.GetWeatherStatics();
          
        }
    }
}
