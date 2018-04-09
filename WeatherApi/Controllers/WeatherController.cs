using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherFocastCommonClassLibrary;
using WeatherForcastLib.Service;

namespace WeatherApi.Controllers
{
    public class WeatherController : ApiController
    {
        private WeatherSevice _weatherSevice=new WeatherSevice();

        // GET: api/Weather
        public IEnumerable<WeatherData> Get()
        {
            return _weatherSevice.GetWeatherDatas();
        }

        // GET: api/Weather/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Weather
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Weather/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Weather/5
        public void Delete(int id)
        {
        }
    }
}
