using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using WeatherFocastCommonClassLibrary;
using WeatherForcastLib.BL;
using WeatherForcastLib.Model;

namespace DALMongoDb
{
    public class MongoDbWeatherDataRepo
    {

        public MongoDbWeatherDataRepo()
        {
            var database = _client.GetDatabase(typeof(WeatherData).Name);
            _collection = database.GetCollection<WeatherData>("data");
        }

        private readonly MongoClient _client = new MongoClient(ResourceDB.url);
        private readonly IMongoCollection<WeatherData> _collection;

        public void Add(WeatherData weatherData)

        {
         _collection.InsertOne(weatherData);
            
        }


        public void AddBulk(params WeatherData[] weatherDatas)
        {

          _collection.InsertMany(weatherDatas);

        }



        public void Drop()
        {
           _collection.Database.DropCollection("data");
           _client.DropDatabase(typeof(WeatherData).Name);
           
        }




        public List<WeatherData> GetWeatherDatas()
        {
         
           return _collection.Find(new BsonDocument()).ToList();
        }



        public WeatherStatics GetWeatherStatics()
        {
            
            var bs= _collection.Find(new BsonDocument()).ToList();
           
            WeatherStatics statics=new WeatherStatics();
           

            foreach (var sData in bs)
            {
               statics.Add(sData);
            }

            return statics;
        }


        

    }
}