using System;
using System.Collections.Generic;

namespace WeatherForcastLib.Model
{
    public class WeatherData
    {

        public WeatherData(Current current)
        {
            Id = Guid.NewGuid();
            City = current.City.Name;
            Country = current.City.Country;
            Humidty = Convert.ToInt32(current.Humidity.Value);
            Pressure = Convert.ToInt32(current.Pressure.Value);
            Speed = Convert.ToDouble(current.Wind.Speed.Value.Replace(".",","));
            Temperature = Convert.ToDouble(current.Temperature.Value.Replace(".", ","));
            UpdateWeather = Convert.ToDateTime(current.Lastupdate.Value);
           WindDirection = current.Wind.Direction.Value;
            WindSpeed = Convert.ToDouble(current.Wind.Speed.Value.Replace(".", ","));
        }

        public WeatherData()
        {
        }
           


        public Guid ? Id { get; set; }
        public DateTime UpdateWeather { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public double Temperature { get; set; }
        public int Humidty { get; set; }
        public int Pressure { get; set; }
        public double Speed { get; set; }
        public double WindSpeed { get; set; }
        public string WindDirection { get; set; }


        private sealed class UpdateWeatherRelationalComparer : Comparer<WeatherData>
        {
            public override int Compare(WeatherData x, WeatherData y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (ReferenceEquals(null, y)) return 1;
                if (ReferenceEquals(null, x)) return -1;
                return x.UpdateWeather.CompareTo(y.UpdateWeather);
            }
        }

        public static Comparer<WeatherData> UpdateWeatherComparer { get; } = new UpdateWeatherRelationalComparer();

        protected bool Equals(WeatherData other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WeatherData) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(WeatherData left, WeatherData right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WeatherData left, WeatherData right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(UpdateWeather)}: {UpdateWeather}, {nameof(City)}: {City}, {nameof(Country)}: {Country}, {nameof(Temperature)}: {Temperature}, {nameof(Humidty)}: {Humidty}, {nameof(Pressure)}: {Pressure}, {nameof(Speed)}: {Speed}, {nameof(WindSpeed)}: {WindSpeed}, {nameof(WindDirection)}: {WindDirection}";
        }
    }
}

/*<current>
<city id="230002667" name="Ghent">
<coord lon="3.73" lat="51.05"/>
<country>BE</country>
<sun rise="2018-04-02T05:18:14" set="2018-04-02T18:19:54"/>
</city>
<temperature value="279.82" min="279.15" max="280.15" unit="kelvin"/>
<humidity value="87" unit="%"/>
<pressure value="1007" unit="hPa"/>
<wind>
<speed value="2.1" name="Light breeze"/>
<gusts/>
<direction value="130" code="SE" name="SouthEast"/>
</wind>
<clouds value="90" name="overcast clouds"/>
<visibility value="10000"/>
<precipitation mode="no"/>
<weather number="500" value="light rain" icon="10d"/>
<lastupdate value="2018-04-02T07:30:00"/>
</current>
*/