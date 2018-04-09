
using MongoDB.Driver;
using WeatherForcastLib.Model;

namespace WeatherFocastCommonClassLibrary
{
    public sealed class MongoDbUtil
    {

        private static MongoDbUtil _instance=new MongoDbUtil();

        private MongoDbUtil()
        {
            var database = _client.GetDatabase(typeof(WeatherData).Name);
            _collection = database.GetCollection<WeatherData>("data");
        }

        private readonly MongoClient _client = new MongoClient(Resource.url);
        private readonly IMongoCollection<WeatherData> _collection;

       



        public void Drop()
        {
            _collection.Database.DropCollection("data");
            _client.DropDatabase(typeof(WeatherData).Name);

        }

        public static MongoDbUtil Instance()
        {
            return _instance;
        }

    }
}